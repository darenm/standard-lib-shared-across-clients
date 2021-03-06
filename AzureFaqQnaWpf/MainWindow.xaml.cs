﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AzureQnaService;

namespace AzureFaqQnaWpf
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly AzureFaqQuestion _client;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _client = new AzureFaqQuestion();
            Loaded += (sender, args) => VisualStateManager.GoToElementState(RootGrid, nameof(ReadyToAsk), false);
        }

        private async void AskQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VisualStateManager.GoToElementState(RootGrid, nameof(Asking), true);

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
                VisualStateManager.GoToElementState(RootGrid, nameof(ReadyToAsk), true);
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