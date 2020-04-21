using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace p4_lab_8_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int allAnswerCount = 0;
        Dictionary<string, int> answers = new Dictionary<string, int>()
        {
            {"A",0 },
            {"B",0 },
            {"C",0 },
            {"D",0 },
        };
        public MainWindow()
        {
            InitializeComponent();
            QuestionTextblock.Text = "Wolisz A, B, C, czy D?";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var choice = button.Content.ToString();

            answers[choice]++;
            allAnswerCount++;

            AllAnswers.Text = allAnswerCount.ToString();

            RedrawGraph();
        }

        private void RedrawGraph()
        {
            var maxHeight = canvas.ActualHeight;
            RA.Height = maxHeight * (answers["A"] / (double)allAnswerCount);
            RB.Height = maxHeight * (answers["B"] / (double)allAnswerCount);
            RC.Height = maxHeight * (answers["C"] / (double)allAnswerCount);
            RD.Height = maxHeight * (answers["D"] / (double)allAnswerCount);


            Stat2.Text = answers.Max(x => x.Value).ToString();
        }
    }
}
