using ChatbotCSharp.Service;
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
        private ChatService chatService;

        public MainWindow()
        {
            InitializeComponent();
            chatService = new ChatService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = UserInput.Text;
            DisplayMessage("User: " + message);

            try
            {
                // Await the response from the OpenAI service
                //string bot_message = getResponse(message);
                string bot_message = await chatService.GetReponseFromOpenAI(message);

                // Display the bot's response
                DisplayMessage("Bot: " + bot_message);
            }
            catch (Exception ex)
            {
                // Handle exceptions and display an error message
                DisplayMessage($"Error: {ex.Message}");
            }

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