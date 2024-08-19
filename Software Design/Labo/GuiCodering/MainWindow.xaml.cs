using System.Windows;
using System.Windows.Controls;

namespace GuiCodering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RadioButton activeRadioButton;
        public MainWindow()
        {
            InitializeComponent();
            GetActiveRadioButton();
        }

        private void GetActiveRadioButton()
        {
            UIElementCollection buttons = CoderingGrid.Children;
            foreach (UIElement button in buttons)
            {
                if (button is RadioButton radioButton)
                {
                    bool? active = radioButton.IsChecked;
                    if (active is null)
                    {
                        throw new Exception($"Can't check if button '{radioButton.Name}' is checked.");
                    }
                    else if ((bool)active)
                    {
                        activeRadioButton = radioButton;
                    }
                }
            }
            if( activeRadioButton is null ) throw new Exception("No (active) radio buttons were found.");
        }

        private void UpdateOutput()
        {
            string? TypeOfEncoding = activeRadioButton.Content.ToString() ?? throw new Exception($"Active radiobutton value is invalid: {activeRadioButton.Content}");
            Codeer codeer;
            if (TypeOfEncoding.Equals("Blok"))
            {
                codeer = new Blok(InputTextField.Text.ToString());
            }
            else if (TypeOfEncoding.Equals("Wissel"))
            {
                codeer = new Wissel(InputTextField.Text.ToString());
            }
            else if (TypeOfEncoding.Equals("Cijfer"))
            {
                codeer = new Cijfer(InputTextField.Text.ToString());
            }
            else
            {
                throw new Exception($"Couldn't find encoder for type: {TypeOfEncoding}");
            }
            OutputWindowLabel.Text = codeer.EncodedMsg;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            GetActiveRadioButton();
            UpdateOutput();
        }

        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateOutput();
        }
    }
}