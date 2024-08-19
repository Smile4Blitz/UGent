## Application structure
```
- ui
	- NewsViewModel => ViewModel
	- screens
		- ScreenA => Composable screen
		- ScreenB => Composable screen
	- theme
		- Type
		- Theme
		- Shape
		- Color
- network
	- NewsApiServer => API-interface
	- NetworkNewsItem => API-implementatie
	- NetworkCategory => API-implementatie
- navigation
	- NewsScreens => Enum-class with route names
	- NewsNavHost => NavHost & routes
- data
	- AppContainer => Maakt/bevat repository
	- NewsRepository => Is Repository, maakt API-calls
	- NewsItem => Database entity
	- Category => Database entity
	- NewsDatabase => Lokale SQLite proxy
	- NewsDao => Database Access Object (proxy naar SQLite db)
	- NewsConverts => Converteert SQL-datatypes naar Kotlin-datatypes
- MainActivity => Roept NewsApp
- NewsApp => Root -composable
- NewsApplication => ...
```
## MainActivity
- Roept de root -composable (NewsApp)

```kotlin
class MainActivity : ComponentActivity() {  
    override fun onCreate(savedInstanceState: Bundle?) {  
        super.onCreate(savedInstanceState)  
        setContent {  
            NewsAppTheme {  
                // A surface container using the 'background' color from the theme  
                Surface(  
                    modifier = Modifier.fillMaxSize(),  
                    color = MaterialTheme.colors.background  
                ) {  
                    NewsApp()  
                }  
            }  
        }  
    }  
}
```
## NewsApplication
```kotlin
class NewsApplication : Application() {  
    lateinit var container: AppContainer  
    override fun onCreate() {  
        super.onCreate()  
        this.container = DefaultAppContainer(this)  
    }  
}
```
## NewsApp
- Request de viewmodel van de factory
- Krijgt of maakt de NavHostController
```kotlin
@Composable  
fun NewsApp(navController: NavHostController = rememberNavController()) {  
    val newsViewModel: NewsViewModel =  
        viewModel(factory = NewsViewModel.Factory)  
  
    NewsNavHost(  
        navController = navController,  
        newsViewModel = newsViewModel  
    )  
}  
  
@Composable  
fun NewsTopAppBar(  
    title: String,  
    canNavigateBack: Boolean,  
    modifier: Modifier = Modifier,  
    navigateUp: () -> Unit = {}  
) {  
    if (canNavigateBack) {  
        TopAppBar(  
            title = {  
                Text(  
                    text = title,  
                    maxLines = 1,  
                    overflow = TextOverflow.Ellipsis,  
                    textAlign = TextAlign.Left  
                )  
            },  
            elevation = 4.dp,  
            modifier = modifier,  
            navigationIcon = {  
                IconButton(onClick = navigateUp) {  
                    Icon(  
                        imageVector = Icons.Filled.ArrowBack,  
                        contentDescription = stringResource(R.string.back_button)  
                    )  
                }  
            }  
        )  
    } else {  
        TopAppBar(title = { Text(title) }, modifier = modifier)  
    }  
}
```
## UI
### Theme
#### Type
```kotlin
// Set of Material typography styles to start with  
val Typography = Typography(  
    body1 = TextStyle(  
        fontFamily = FontFamily.Default,  
        fontWeight = FontWeight.Normal,  
        fontSize = 16.sp  
    )  
)
```
#### Color
```kotlin
val Purple200 = Color(0xFFBB86FC)  
val Purple500 = Color(0xFF6200EE)  
val Purple700 = Color(0xFF3700B3)  
val Teal200 = Color(0xFF03DAC5)
```
#### Theme
```kotlin
private val DarkColorPalette = darkColors(  
    primary = Purple200,  
    primaryVariant = Purple700,  
    secondary = Teal200  
)  
  
private val LightColorPalette = lightColors(  
    primary = Purple500,  
    primaryVariant = Purple700,  
    secondary = Teal200  
)  
  
@Composable  
fun NewsAppTheme(darkTheme: Boolean = isSystemInDarkTheme(), 
				 content: @Composable () -> Unit
				 ) {  
    val colors = if (darkTheme) {  
        DarkColorPalette  
    } else {  
        LightColorPalette  
    }  
  
    MaterialTheme(  
        colors = colors,  
        typography = Typography,  
        shapes = Shapes,  
        content = content  
    )  
}
```
#### Shape
```kotlin
val Shapes = Shapes(  
    small = RoundedCornerShape(4.dp),  
    medium = RoundedCornerShape(4.dp),  
    large = RoundedCornerShape(0.dp)  
)
```
### Screens
#### ScreenA
```kotlin
@SuppressLint("UnusedMaterialScaffoldPaddingParameter")  
@Composable  
fun CategoryScreen(  
    viewModel: NewsViewModel,  
    onCategorySelected: () -> Unit,  
    modifier: Modifier = Modifier  
) {  
    val uiState by viewModel.uiState.collectAsState()  
  
    Scaffold(  
        topBar = {  
            NewsTopAppBar(  
                title = stringResource(R.string.categories),  
                canNavigateBack = false  
            )  
        }  
    ) {  
        when (uiState.dataLoadState) {  
            DataLoadState.Loading -> LoadingScreen(modifier)  
            DataLoadState.Success -> CategoryListScreen(  
                uiState.categories,  
                { category: Category ->  
                    viewModel.selectCategory(category = category)  
                    onCategorySelected()  
                },  
                modifier  
            )  
            DataLoadState.Error -> ErrorScreen({ viewModel.getData() }, modifier)  
        }  
    }  
}  
  
@Composable  
fun CategoryListScreen(  
    categories: List<Category>,  
    categorySelectedHandler: (category: Category) -> Unit,  
    modifier: Modifier = Modifier  
) {  
    LazyColumn {  
        items(categories) {  
            CategoryCard(  
                category = it,  
                categorySelectedHandler = categorySelectedHandler,  
                modifier = modifier  
            )  
        }  
    }  
}  
  
@Composable  
fun CategoryCard(  
    category: Category,  
    categorySelectedHandler: (category: Category) -> Unit,  
    modifier: Modifier  
) {  
    Card(  
        modifier = modifier.padding(8.dp), elevation = 4.dp  
    ) {  
        Row {  
            Box(  
                modifier = modifier  
                    .fillMaxHeight()  
                    .align(Alignment.CenterVertically)  
                    .padding(2.dp)  
                    .clickable {  
                        categorySelectedHandler(category)  
                    }  
            ) {  
                Text(  
                    text = category.title,  
                    textAlign = TextAlign.Left,  
                    style = MaterialTheme.typography.h4,  
                    modifier = modifier.fillMaxWidth()  
                )  
            }  
        }  
    }  
}  
  
@Composable  
fun LoadingScreen(modifier: Modifier = Modifier) {  
    Box(  
        contentAlignment = Alignment.Center,  
        modifier = modifier.fillMaxSize()  
    ) {  
        Image(  
            modifier = Modifier.size(200.dp),  
            painter = painterResource(R.drawable.loading_img),  
            contentDescription = stringResource(R.string.loading_img)  
        )  
    }  
}  
  
@Composable  
fun ErrorScreen(retryAction: () -> Unit, modifier: Modifier = Modifier) {  
    Column(  
        modifier = modifier.fillMaxSize(),  
        verticalArrangement = Arrangement.Center,  
        horizontalAlignment = Alignment.CenterHorizontally  
    ) {  
        Text(stringResource(R.string.loading_failed))  
        Button(onClick = retryAction) {  
            Text(stringResource(R.string.retry))  
        }  
    }  
}
```
#### ScreenB
```kotlin
@SuppressLint("UnusedMaterialScaffoldPaddingParameter")  
@Composable  
fun SubCategoryScreen(  
    viewModel: NewsViewModel,  
    onSubCategorySelected: () -> Unit,  
    navigateUp: () -> Unit,  
    modifier: Modifier = Modifier  
) {  
    val uiState by viewModel.uiState.collectAsState()  
  
    val selectedCategoryIndex: Int =  
        uiState.categories.indexOf(uiState.selectedCategory)  
  
    Scaffold(  
        topBar = {  
            NewsTopAppBar(  
                title = uiState.selectedCategory?.title ?: "",  
                canNavigateBack = true,  
                navigateUp = navigateUp  
            )  
        }  
    ) {  
        SubCategoryListScreen(  
            subCategories = uiState.categories[selectedCategoryIndex].subcategories,  
            subCategorySelectedHandler = {  
                viewModel.selectSubCategory(it)  
                onSubCategorySelected()  
            },  
            modifier  
        )  
    }  
}  
  
@Composable  
fun SubCategoryListScreen(  
    subCategories: List<String>,  
    subCategorySelectedHandler: (subCategory: String) -> Unit,  
  
    modifier: Modifier = Modifier  
) {  
    LazyColumn {  
        items(subCategories) {  
            SubCategoryCard(  
                subCategory = it,  
                subCategorySelectedHandler = subCategorySelectedHandler,  
                modifier = modifier  
            )  
        }  
    }  
}  
  
@Composable  
fun SubCategoryCard(  
    subCategory: String,  
    subCategorySelectedHandler: (subCategory: String) -> Unit,  
    modifier: Modifier  
) {  
    Card(  
        modifier = modifier.padding(8.dp), elevation = 4.dp  
    ) {  
        Row {  
            Box(  
                modifier = modifier  
                    .fillMaxHeight()  
                    .align(Alignment.CenterVertically)  
                    .padding(2.dp)  
                    .clickable {  
                        subCategorySelectedHandler(subCategory)  
                    }  
            ) {  
                Text(  
                    text = subCategory,  
                    textAlign = TextAlign.Left,  
                    style = MaterialTheme.typography.h4,  
                    modifier = modifier.fillMaxWidth()  
                )  
            }  
        }  
    }  
}
```
### ViewModel
```kotlin
enum class DataLoadState() {  
    Success, Error, Loading  
}  
  
data class GlobalState(  
    val selectedCategory: Category? = null,  
    val selectedSubCategory: String = "",  
    val articles: List<NewsItem> = listOf(),  
    val articlesToShow: List<NewsItem> = listOf(),  
    val dataLoadState: DataLoadState = DataLoadState.Loading,  
    val categories: List<Category> = listOf(),  
    val selectedArticle: NewsItem? = null,  
    val searchText: String = ""  
)  
  
class NewsViewModel(  
    private val newsRepository: NewsRepository, private val savedStateHandle: SavedStateHandle  
) : ViewModel() {  
  
    private val _uiState = MutableStateFlow(GlobalState())  
    val uiState: StateFlow<GlobalState> = _uiState.asStateFlow()  
  
    companion object {  
        val Factory: ViewModelProvider.Factory = viewModelFactory {  
            initializer {  
                val savedStateHandle = createSavedStateHandle()  
                val categoryRepository =  
                    (this[APPLICATION_KEY] as NewsApplication).container.newsRepository  
                NewsViewModel(  
                    newsRepository = categoryRepository,  
                    savedStateHandle = savedStateHandle  
                )  
            }  
        }  
    }  
  
    init {  
        getData()  
    }  
  
  
    fun getData() {  
        viewModelScope.launch {  
            try {  
                newsRepository.fetchCategories()  
                newsRepository.fetchNewsItems()  
            } catch (e: IOException) {  
                _uiState.update { currentState ->  
                    currentState.copy(  
                        dataLoadState = DataLoadState.Error  
                    )  
                }  
            } catch (e: HttpException) {  
                _uiState.update { currentState ->  
                    currentState.copy(  
                        dataLoadState = DataLoadState.Error  
                    )  
                }  
            }  
  
            newsRepository.getAllCategoriesStream().collect { _categories ->  
                _uiState.update { currentState ->  
                    currentState.copy(  
                        dataLoadState = DataLoadState.Success,  
                        categories = _categories  
                    )  
                }  
            }  
        }  
    }  
  
    fun selectCategory(category: Category): Unit {  
        _uiState.update { currentState ->  
            currentState.copy(  
                selectedCategory = category  
            )  
        }  
    }  
  
    fun selectSubCategory(subCategory: String) {  
        _uiState.update { currentState ->  
            currentState.copy(  
                selectedSubCategory = subCategory  
            )  
        }  
  
        viewModelScope.launch {  
            updateArticles()  
        }  
    }  
  
    private suspend fun updateArticles() {  
        newsRepository.getallNewsItemsStream(uiState.value.selectedSubCategory)  
            .collect { newsItems ->  
                _uiState.update { currentState ->  
                    currentState.copy(  
                        articles = newsItems  
                    )  
                }  
                filterArticles()  
            }  
    }  
  
    fun selectArticle(article: NewsItem) {  
        _uiState.update { currentState ->  
            currentState.copy(  
                selectedArticle = article  
            )  
        }  
    }  
  
    fun updateSearchText(text: String) {  
        _uiState.update { currentState ->  
            currentState.copy(  
                searchText = text  
            )  
        }  
    }  
  
    fun filterArticles(){  
        _uiState.update { currentState ->  
            currentState.copy(  
                articlesToShow = currentState.articles.filter { newsItem ->  
                    newsItem.title.contains(currentState.searchText)  
                }  
            )  
        }  
    }  
}
```
## Network
### NewsApiService
- Interface met API-calls/methodes

```kotlin
interface NewsApiService {  
    @GET("onderwerpen")  
    suspend fun getCategories(): List<NetworkCategory>  
  
    @GET("items")  
    suspend fun getNewsItems(): List<NetworkNewsItem>  
}
```
### NetworkNewsItem
```kotlin
@Serializable  
data class NetworkNewsItem(  
    val id: String,  
    val category: String,  
    @SerialName("subcategory")  
    val subCategory: String,  
    val title: String,  
    val content: String  
)
```
### NetworkCategory
```kotlin
@Serializable  
data class NetworkCategory(  
    val id: String,  
    val title: String,  
    @SerialName(value = "subcategorieen")  
    val subcategories: List<String>  
)
```
## Navigation
### NewsNavHost
```kotlin
@Composable  
fun NewsNavHost(  
    navController: NavHostController,  
    newsViewModel: NewsViewModel,  
    modifier: Modifier = Modifier  
) {  
    NavHost(  
        navController = navController,  
        startDestination = NavigationDestination.Categories.name,  
        modifier = modifier  
    ) {  
        composable(route = NavigationDestination.Categories.name) {  
            CategoryScreen(  
                viewModel = newsViewModel,  
                onCategorySelected = {  
                    navController.navigate(NavigationDestination.SubCategories.name)  
                }  
            )  
        }  
        composable(route = NavigationDestination.SubCategories.name) {  
            SubCategoryScreen(  
                viewModel = newsViewModel,  
                onSubCategorySelected = {  
                    navController.navigate(NavigationDestination.Articles.name)  
                },  
                navigateUp = {  
                    navController.navigateUp()  
                }  
            )  
        }  
        composable(route = NavigationDestination.Articles.name) {  
            ArticlesScreen(  
                viewModel = newsViewModel,  
                onArticleSelected = {  
                    navController.navigate(NavigationDestination.Details.name)  
                },  
                navigateUp = {  
                    navController.navigateUp()  
                }  
            )  
        }  
        composable(route = NavigationDestination.Details.name) {  
            DetailScreen(  
                viewModel = newsViewModel,  
                navigateUp = {  
                    navController.navigateUp()  
                }  
            )  
        }  
    }  
}
```
### NavigationDestination
```kotlin
enum class NavigationDestination {  
    Categories,  
    SubCategories,  
    Articles,  
    Details  
}
```

## Data
### AppContainer
```kotlin
interface AppContainer {  
    val newsRepository: NewsRepository  
  
}  
  
class DefaultAppContainer(private val context: Context) : AppContainer {  
    private val BASE_URL = "https://623b4a952e056d1037f0689b.mockapi.io/"  
  
    @OptIn(ExperimentalSerializationApi::class)  
    private val retrofit: Retrofit = Retrofit.Builder()  
        .addConverterFactory(Json.asConverterFactory("application/json".toMediaType()))  
        .baseUrl(BASE_URL)  
        .build()  
  
    private val retrofitService: NewsApiService by lazy {  
        retrofit.create(NewsApiService::class.java)  
    }  
  
    override val newsRepository: NewsRepository by lazy {  
        NewsRepository(  
            NewsDatabase.getDatabase(context).newsDao(),  
            retrofitService  
        )  
    }  
}
```
### NewsRepository
```kotlin
class NewsRepository(  
    private val newsDao: NewsDao,  
    private val service: NewsApiService  
) {  
    suspend fun fetchCategories() {  
        service.getCategories().map {  
            Category(it.id, it.title, it.subcategories)  
        }.forEach {  
            insertCategory(it)  
        }  
    }  
  
    suspend fun insertCategory(category: Category) = newsDao.insertCategory(category)  
  
    fun getAllCategoriesStream(): Flow<List<Category>> = newsDao.getAllCategories()  
  
    suspend fun fetchNewsItems() {  
        service.getNewsItems().map {  
            NewsItem(it.id, it.category, it.subCategory, it.title, it.content)  
        }.forEach {  
            insertNewsItem(it)  
        }  
    }  
  
    suspend fun insertNewsItem(item: NewsItem) = newsDao.insertNewsItem(item)  
  
    fun getAllNewsItemsStream(): Flow<List<NewsItem>> = newsDao.getAllNewsItems()  
  
    fun getallNewsItemsStream(subCategory: String): Flow<List<NewsItem>> =  
        newsDao.getAllNewsItems(subCategory)  
  
}
```
### NewsItem
```kotlin
@Entity(tableName = "news_items")  
data class NewsItem (  
    @PrimaryKey  
    val id: String,  
    @ColumnInfo(name = "category")  
    val category: String,  
    @ColumnInfo(name = "subcategory")  
    val subCategory: String,  
    @ColumnInfo(name = "title")  
    val title: String,  
    @ColumnInfo(name = "content")  
    val content: String  
)
```
### Category
```kotlin
@Entity(tableName = "categories")  
data class Category (  
    @PrimaryKey  
    val id: String,  
    @ColumnInfo(name = "title")  
    val title: String,  
    @ColumnInfo(name = "subcategories")  
    val subcategories: List<String>  
)
```
### NewsDatabase
```kotlin
@Database(entities = [Category::class, NewsItem::class], version = 2, exportSchema = false)  
@TypeConverters(NewsConverters::class)  
abstract class NewsDatabase : RoomDatabase() {  
    abstract fun newsDao(): NewsDao  
  
    companion object{  
        @Volatile  
        private var Instance: NewsDatabase? = null  
  
        fun getDatabase(context: Context): NewsDatabase {  
            return Instance ?: synchronized(this) {  
                Room.databaseBuilder(context, NewsDatabase::class.java, "news_database")  
                    .fallbackToDestructiveMigration()  
                    .build()  
                    .also { Instance = it }  
            }  
        }  
    }  
}
```
### NewsDao
```kotlin
@Dao  
interface NewsDao {  
    @Insert(onConflict = OnConflictStrategy.IGNORE)  
    suspend fun insertCategory(category: Category)  
  
    @Query("SELECT * from categories")  
    fun getAllCategories(): Flow<List<Category>>  
  
    @Insert(onConflict = OnConflictStrategy.IGNORE)  
    suspend fun insertNewsItem(newsItem: NewsItem)  
  
    @Query("SELECT * from news_items")  
    fun getAllNewsItems(): Flow<List<NewsItem>>  
  
    @Query("SELECT * from news_items where subcategory = :subCategory")  
    fun getAllNewsItems(subCategory: String): Flow<List<NewsItem>>  
}
```
### NewsConvert
```kotlin
class NewsConverters {  
    @TypeConverter  
    fun fromStringList(value: List<String>): String {  
        val gson = Gson()  
        val type = object : TypeToken<List<String>>() {}.type  
        return gson.toJson(value, type)  
    }  
  
    @TypeConverter  
    fun toStringList(value: String): List<String> {  
        val gson = Gson()  
        val type = object : TypeToken<List<String>>() {}.type  
        return gson.fromJson(value, type)  
    }  
}
```
