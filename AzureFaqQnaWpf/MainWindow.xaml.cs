using AzureQnaService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AzureFaqQnaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AzureFaqQuestion _client;

        public MainWindow()
        {
            InitializeComponent();
            _client = new AzureFaqQuestion();
        }

        private async void AskQuestion_Click(object sender, RoutedEventArgs e)
        {
            AskQuestion.IsEnabled = false;
            AskQuestionLabel.Visibility = Visibility.Hidden;
            AskQuestionProgress.Visibility = Visibility.Visible;
            AskQuestionProgress.IsIndeterminate = true;
            try
            {

                //await GetOneAnswer();
                await Get3Answers();
            }
            catch (Exception exception)
            {
                Response.Children.Insert(0,
                    new TextBlock
                    {
                        Text = exception.Message,
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = new SolidColorBrush(Colors.Red)
                    });
            }
            AskQuestion.IsEnabled = true;
            AskQuestionLabel.Visibility = Visibility.Visible;
            AskQuestionProgress.Visibility = Visibility.Hidden;
            AskQuestionProgress.IsIndeterminate = false;
        }

        private async Task GetOneAnswer()
        {
            Response.Children.Insert(0, new TextBlock { Text = await _client.GetOneAnswer(SearchQuery.Text), TextWrapping = TextWrapping.Wrap });
        }

        private async Task Get3Answers()
        {
            var response = await _client.GetTopXAnswer(SearchQuery.Text, 3);
            foreach (var answer in response.Answers)
            {
                Response.Children.Insert(0, new TextBlock { Text = answer.Answer, TextWrapping = TextWrapping.Wrap });
            }
        }
    }
}
