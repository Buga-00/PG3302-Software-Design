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

            WinCheck();
        }

        private void WinCheck()
        {

            #region Row wins

            //Checking for the row wins
            //First row
            if ((theResults[0] & theResults[1] & theResults[2]) == theResults[0] && theResults[0] != Type.Free)
            {
                endedGame = true;

                Btn0_0.Background = Btn1_0.Background = Btn2_0.Background = Brushes.Pink;
            }

            //Second Row
            if ((theResults[3] & theResults[4] & theResults[5]) == theResults[3] && theResults[3] != Type.Free)
            {
                endedGame = true;

                Btn0_1.Background = Btn1_1.Background = Btn2_1.Background = Brushes.Pink;
            }

            //Third row
            if ((theResults[6] & theResults[7] & theResults[8]) == theResults[6] && theResults[6] != Type.Free)
            {
                endedGame = true;

                Btn0_2.Background = Btn1_2.Background = Btn2_2.Background = Brushes.Pink;
            }

            #endregion

            #region Column wins

            //Checking for the column wins
            //First column
            if ((theResults[0] & theResults[3] & theResults[6]) == theResults[0] && theResults[0] != Type.Free)
            {
                endedGame = true;

                Btn0_0.Background = Btn0_1.Background = Btn0_2.Background = Brushes.Pink;
            }

            //Second column
            if ((theResults[1] & theResults[4] & theResults[7]) == theResults[1] && theResults[1] != Type.Free)
            {
                endedGame = true;

                Btn1_0.Background = Btn1_1.Background = Btn1_2.Background = Brushes.Pink;
            }

            //Third column
            if ((theResults[2] & theResults[5] & theResults[8]) == theResults[2] && theResults[2] != Type.Free)
            {
                endedGame = true;

                Btn2_0.Background = Btn2_1.Background = Btn2_2.Background = Brushes.Pink;
            }

            #endregion

            #region cross wins

            //Top right to bottom left
            if ((theResults[2] & theResults[4] & theResults[6]) == theResults[2] && theResults[2] != Type.Free)
            {
                endedGame = true;

                Btn2_0.Background = Btn1_1.Background = Btn0_2.Background = Brushes.Pink;
            }

            //Top left to bottom right
            if ((theResults[0] & theResults[4] & theResults[8]) == theResults[0] && theResults[0] != Type.Free)
            {
                endedGame = true;

                Btn0_0.Background = Btn1_1.Background = Btn2_2.Background = Brushes.Pink;
            }

            #endregion

            #region No one wins

            if (!theResults.Any(r => r == Type.Free))
            {
                endedGame = true;

                GridUI.Children.Cast<Button>().ToList().ForEach(btn =>
                {
                    btn.Background = Brushes.Gold;
                });
            }

            #endregion


        }
    }
}
