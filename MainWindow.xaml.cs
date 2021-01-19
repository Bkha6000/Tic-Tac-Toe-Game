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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region PrivateMembers
        private MarkType[] res;
        private Boolean gameEnded;
        private Boolean player1Turn;
        private int[] wins;
        private int[] wins1;

        #endregion
        #region Constructor for the window.
        /*
         * 
         * 
         */
        public MainWindow()
        {
            System.Diagnostics.Debug.WriteLine("SADDD");
            res = new MarkType[9];
            wins = new int[8];
            wins1 = new int[8];
            InitializeComponent();
            newGame();
        }
        #endregion
        /// <summary>
        /// Function that gets called when a new game starts. 
        /// </summary>
        private void newGame()
        {
            player1Turn = true;
            gameEnded = false;
            for (int i = 0; i < res.Length; i++)
                res[i] = MarkType.Free;
            for (int i = 0; i < wins.Length; i++)
                wins[i] = 0;
            for (int i = 0; i < wins.Length; i++)
                wins1[i] = 0;
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });
            gameEnded = false;
        }
       
        /// <summary>
        /// The method that gets called when a button is clicked.
        /// </summary>
        /// <param name="sender"></param> Object that was clicked.
        /// <param name="e"></param>Parameters for the object that was clicked.
        private void Butt_Click(object sender, RoutedEventArgs e)
        {

            var Butt = (Button)sender;
            var column = Grid.GetColumn(Butt);
            var row = Grid.GetRow(Butt);
            var ind = row * 3 + column;
            Boolean added = false;
            if (gameEnded)
            {
                newGame();
                return;
            }
           

                Butt = (Button)sender;
                column = Grid.GetColumn(Butt);
                row = Grid.GetRow(Butt);
                ind = row * 3 + column;
                if (player1Turn)
                {
                    if (res[ind] == 0)
                    {
                        added = true;
                        Butt.Content = "X";
                        res[ind] = MarkType.Cross;
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {

                    if (res[ind] == 0)
                    {
                        added=true;
                        Butt.Content = "O";
                        res[ind] = MarkType.Circle;
                    }
                    else
                    {
                        return;
                    }

                }

            
            if (player1Turn)
            {
                Butt.Foreground = Brushes.Red;
                if (checkWin(wins, ind))
                {
                    gameEnded = true;
                }
                else
                {
                    gameEnded = false;
                }
            }
            else
            {
                if (checkWin(wins1, ind))
                {
                    gameEnded = true;
                }
                else
                {
                    gameEnded = false;
                }
            }
            

            player1Turn = !player1Turn;

        }

        /// <summary>
        /// Checks board to see if a 3-straight occured.
        /// </summary>
        /// <param name="arr"></param>The array that tracks which rows, columns, and diagonals have
        /// been marked.
        /// <param name="inde"></param>The index for the button that got marked.
        /// <returns></returns> True if there is a winner and false if there is no winner.
        private Boolean checkWin(int [] arr, int inde)
        {
            if ((inde % 3)==(inde/3))
            {
                arr[6]++;

            }
            if (((inde % 3) + (inde / 3))==(2))
            {
                arr[7]++;

            }
            if (inde % 3 == 0)
            {
                
                arr[3]++;
            }
            else if (inde % 3 == 1)
            {
                
                arr[4]++;
            }
            else if (inde % 3 == 2)
            {
                arr[5]++;
            }
            if (inde/  3 == 0)
            {
                arr[0]++;
            }
            else if (inde / 3 == 1)
            {
                arr[1]++;
            }
            else if (inde / 3 == 2)
            {
                arr[2]++;
            }
            for(int aa=0; aa < arr.Length; aa++)
            {
                System.Diagnostics.Debug.Write(aa);
                if (arr[aa] == 3)
                {
                    ShowWin(aa);
                    System.Diagnostics.Debug.WriteLine("Whatt");
                    return true;
                }
                
            }
            System.Diagnostics.Debug.WriteLine("");

            return false;

        }
        /// <summary>
        /// Function that highlights the row, column or diagonal where a three-straight ocurred.
        /// </summary>
        /// <param name="aa"></param>The number that represents the three-straight that occurred.
        public void ShowWin(int aa)
        {
            switch(aa)
            { 
                case 0:
                    Butt0_0.Background = Butt0_1.Background = Butt0_2.Background = Brushes.Orange;
                    break;
                case 1:
                    Butt1_0.Background = Butt1_1.Background = Butt1_2.Background = Brushes.Orange;
                    break;
                case 2:
                    Butt2_0.Background = Butt2_1.Background = Butt2_2.Background = Brushes.Orange;
                    break;
                case 3:
                    Butt0_0.Background = Butt1_0.Background = Butt2_0.Background = Brushes.Orange;
                    break;
                case 4:
                    Butt0_1.Background = Butt1_1.Background = Butt2_1.Background = Brushes.Orange;
                    break;
                case 5:
                    Butt0_2.Background = Butt1_2.Background = Butt2_2.Background = Brushes.Orange;
                    break;
                case 6:
                    Butt0_0.Background = Butt1_1.Background = Butt2_2.Background = Brushes.Orange;
                    break;
                case 7:
                    Butt0_2.Background = Butt1_1.Background = Butt2_2.Background = Brushes.Orange;
                    break;
            }

        }
        
        
    }
}
