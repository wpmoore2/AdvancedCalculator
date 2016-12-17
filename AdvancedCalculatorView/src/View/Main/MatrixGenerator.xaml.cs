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
using System.Windows.Shapes;
using static AdvancedCalculatorView.MainWindow;

namespace AdvancedCalculatorView.src.View.Main
{
    /// <summary>
    /// Interaction logic for MatrixGenerator.xaml
    /// </summary>
    public partial class MatrixGenerator : Window
    {
        private int numMatrices;
        private enum Operation { MULTIPLY, INVERSE };


        /**
         * Starts the matrix generator by determining the operation.
         * It will prompt for the number of matrices, or not, then 
         * prompt for the values of the matrix. 
         * */
        public MatrixGenerator(MatrixOperation op)
        {
            InitializeComponent();
            disableAll();

            int operation = (int) op;
            switch (operation)
            {
                case (int)Operation.MULTIPLY:
                    getNumMatrices();
                    break;

                case (int)Operation.INVERSE:
                    numMatrices = 1;
                    inputMatrices(numMatrices);
                    break;
            }
            
        }

        /**
         * Makes all of the content for this window hidden.
         * */
        private void disableAll()
        {
            numInputErrorLabel.Visibility = Visibility.Hidden;
            numSubmitButton.Visibility = Visibility.Hidden;
            numberPrompt.Visibility = Visibility.Hidden;
            numberInput.Visibility = Visibility.Hidden;
        }

        /**
         * 
         * 
         * */
        private void inputMatrices(int num)
        {
            MessageBox.Show("yaya");
        }

        /**
         * Displays the view, allowing input for the number of matrices (to multiply)
         * */
        private void getNumMatrices()
        {
            numSubmitButton.Visibility = Visibility.Visible;
            numberPrompt.Visibility = Visibility.Visible;
            numberInput.Visibility = Visibility.Visible;
        }

        /**
         *  Allows the user to press enter when inputting the number of matrices.
         * */
        private void numberInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                numSubmitButton_Click(sender, e);
            }
        }

        private void numSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            uint ret = 0;
            if (UInt32.TryParse(numberInput.Text, out ret))
            {
                this.numMatrices = (int)ret;
                inputMatrices(this.numMatrices);
            }
            else
                numInputErrorLabel.Visibility = Visibility.Visible;
          
        }
    }
}