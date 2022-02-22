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

namespace Game
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Resources

        private Type[] theResults;

        private bool p1Turn;

        private bool endedGame;

        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            newGame();
        }

        #endregion

        private void newGame()
        {
            theResults = new Type[9];

            for (var i = 0; i < theResults.Length; i++)
            {
                theResults[i] = Type.Free;
            }

            p1Turn = true;

            GridUI.Children.Cast<Button>().ToList().ForEach(btn =>
            {
                btn.Content = string.Empty;
                btn.Background = Brushes.White;
            });

            endedGame = false;

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (endedGame)
            {
                newGame();
                return;
            }

            var btn = (Button)sender;

            var row = Grid.GetRow(btn);
            var column = Grid.GetColumn(btn);

            var index = column + (row * 3);

            if (theResults[index] != Type.Free)
            {
                return;
            }

            if (p1Turn)
            {
                theResults[index] = Type.Cross;
            }
            else
            {
                theResults[index] = Type.Zero;
            }

            if (p1Turn)
            {
                btn.Content = "X";
            }
            else
            {
                btn.Content = "O";
            }

            if (p1Turn)
            {
                p1Turn = false;
            }
            else
            {
                p1Turn = true;
            }

            if (!p1Turn)
            {
                btn.Foreground = Brushes.BlueViolet;
            }
            else
            {
                btn.Foreground = Brushes.Cyan;
            }

        }


    }
}
