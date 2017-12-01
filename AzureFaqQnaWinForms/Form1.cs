using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzureQnaService;

namespace AzureFaqQnaWinForms
{
    public partial class Form1 : Form
    {
        private readonly AzureFaqQuestion _client;

        public Form1()
        {
            InitializeComponent();
            _client = new AzureFaqQuestion();
        }

        private async void AskQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                AskQuestion.Visible = false;
                AskQuestionProgress.Visible = true;
                AskQuestionProgress.Style = ProgressBarStyle.Marquee;
                var text = await _client.GetOneAnswer(SearchQuery.Text);
                ResponseList.Text = text + Environment.NewLine + Environment.NewLine + ResponseList.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                AskQuestion.Visible = true;
                AskQuestionProgress.Visible = false;
                AskQuestionProgress.Style = ProgressBarStyle.Blocks;
            }
        }
    }
}
