using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatbotCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = UserInput.Text;
            DisplayMessage("User: " + message);

            string bot_message = getResponse(message);
            DisplayMessage("" + bot_message);

            UserInput.Clear();
            
        }

        private void DisplayMessage(string m) 
        { 
            ChatTextBox.AppendText(m+ "\n");
            ChatTextBox.ScrollToEnd();
        }

        private String getResponse(string m) 
        {
            return "You just said: " + m;

        }

        private void UserInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ChatTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}