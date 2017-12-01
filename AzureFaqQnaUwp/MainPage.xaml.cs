using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using AzureQnaService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AzureFaqQnaUwp
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Fields

        private readonly AzureFaqQuestion _client;

        #endregion

        public MainPage()
        {
            InitializeComponent();
            _client = new AzureFaqQuestion();
            Loaded += (sender, args) => VisualStateManager.GoToState(this, nameof(ReadyToAsk), false);
        }


        private async void AskQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VisualStateManager.GoToState(this, nameof(Asking), true);

                await GetOneAnswer();
                // await Get3Answers();
            }
            catch (Exception exception)
            {
                Response.Children.Insert(0,
                    new TextBlock
                    {
                        Text = exception.Message,
                        TextWrapping = TextWrapping.Wrap,
                        Foreground = new SolidColorBrush(Colors.Red),
                        Margin = new Thickness(4)
                    });
            }
            finally
            {
                VisualStateManager.GoToState(this, nameof(ReadyToAsk), true);
            }
        }

        private async Task Get3Answers()
        {
            var response = await _client.GetTopXAnswer(SearchQuery.Text, 3);
            foreach (var answer in response.Answers)
                Response.Children.Insert(0,
                    new TextBlock {Text = answer.Answer, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(4)});
        }

        private async Task GetOneAnswer()
        {
            Response.Children.Insert(0,
                new TextBlock
                {
                    Text = await _client.GetOneAnswer(SearchQuery.Text),
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(4)
                });
        }
    }
}