## Android API permissions
- Defined in **AndroidManifest.xml**
```kotlin
<?xml version="1.0" encoding="utf-8"?>  
<manifest xmlns:android="http://schemas.android.com/apk/res/android"  
    xmlns:tools="http://schemas.android.com/tools">  
  
    <uses-permission android:name="android.permission.INTERNET" />  
    <application 
		android:allowBackup="true"
		android:icon="@mipmap/ic_launcher">
	</application>
</manifest>
```
## Lifecycle methods
![[InstanceStates.png]]
### Exercise:
Always include the step we are currently in before we perform the operation described.

1. What steps are taken when we launch an app
2. What steps are taken when we are within the app & we keep clicking the Android-back button?
3. What steps are taken when we change app by clicking on the home button?
4. What steps are taken when we open the app from the back stack?
	1. What state is the app in before we open it from the back stack?

![[InstanceStates.gif]]
## Logging

```kotlin
Log.i("TAG","Message")
```

Setting a tag allows you to filter log messages in the Logcat.
