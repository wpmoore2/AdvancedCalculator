using AdvancedCalculator;
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
        private MatrixController mc;
        private TextBox[] matrixMap;
        private MatrixOperation op;
        private enum Page { NUMMATRICES, MATRIXDIM, MATRIXINPUT };
        private Page currPage;
        private const uint MAX_NUM_MATRICES = 10;

        private int numRow;
        private int numCol;
        private int totalMatrices;
        private int currMatrix;


        /**
         * Starts the matrix generator by determining the operation.
         * It will prompt for the number of matrices, or not, then 
         * prompt for the values of the matrix. 
         * */
        public MatrixGenerator(MatrixOperation op)
        {
            InitializeComponent();

            mc = new MatrixController();
            matrixMap = new TextBox[100];
            fillMatrixMap();
            disableAll();

            this.op = op;
            switch (this.op)
            {
                case MatrixOperation.MULTIPLY:
                    currPage = Page.NUMMATRICES;
                    viewGetNumMatrices();
                    break;

                case MatrixOperation.INVERSE:
                    currPage = Page.MATRIXDIM;
                    inputMatrices();
                    break;
            }
            
        }
        #region fill matrix map

        private void fillMatrixMap()
        {
            matrixMap[0] = cell00;
            matrixMap[1] = cell01;
            matrixMap[2] = cell02;
            matrixMap[3] = cell03;
            matrixMap[4] = cell04;
            matrixMap[5] = cell05;
            matrixMap[6] = cell06;
            matrixMap[7] = cell07;
            matrixMap[8] = cell08;
            matrixMap[9] = cell09;

            matrixMap[10] = cell10;
            matrixMap[11] = cell11;
            matrixMap[12] = cell12;
            matrixMap[13] = cell13;
            matrixMap[14] = cell14;
            matrixMap[15] = cell15;
            matrixMap[16] = cell16;
            matrixMap[17] = cell17;
            matrixMap[18] = cell18;
            matrixMap[19] = cell19;

            matrixMap[20] = cell20;
            matrixMap[21] = cell21;
            matrixMap[22] = cell22;
            matrixMap[23] = cell23;
            matrixMap[24] = cell24;
            matrixMap[25] = cell25;
            matrixMap[26] = cell26;
            matrixMap[27] = cell27;
            matrixMap[28] = cell28;
            matrixMap[29] = cell29;

            matrixMap[30] = cell30;
            matrixMap[31] = cell31;
            matrixMap[32] = cell32;
            matrixMap[33] = cell33;
            matrixMap[34] = cell34;
            matrixMap[35] = cell35;
            matrixMap[36] = cell36;
            matrixMap[37] = cell37;
            matrixMap[38] = cell38;
            matrixMap[39] = cell39;

            matrixMap[40] = cell40;
            matrixMap[41] = cell41;
            matrixMap[42] = cell42;
            matrixMap[43] = cell43;
            matrixMap[44] = cell44;
            matrixMap[45] = cell45;
            matrixMap[46] = cell46;
            matrixMap[47] = cell47;
            matrixMap[48] = cell48;
            matrixMap[49] = cell49;

            matrixMap[50] = cell50;
            matrixMap[51] = cell51;
            matrixMap[52] = cell52;
            matrixMap[53] = cell53;
            matrixMap[54] = cell54;
            matrixMap[55] = cell55;
            matrixMap[56] = cell56;
            matrixMap[57] = cell57;
            matrixMap[58] = cell58;
            matrixMap[59] = cell59;

            matrixMap[60] = cell60;
            matrixMap[61] = cell61;
            matrixMap[62] = cell62;
            matrixMap[63] = cell63;
            matrixMap[64] = cell64;
            matrixMap[65] = cell65;
            matrixMap[66] = cell66;
            matrixMap[67] = cell67;
            matrixMap[68] = cell68;
            matrixMap[69] = cell69;

            matrixMap[70] = cell70;
            matrixMap[71] = cell71;
            matrixMap[72] = cell72;
            matrixMap[73] = cell73;
            matrixMap[74] = cell74;
            matrixMap[75] = cell75;
            matrixMap[76] = cell76;
            matrixMap[77] = cell77;
            matrixMap[78] = cell78;
            matrixMap[79] = cell79;

            matrixMap[80] = cell80;
            matrixMap[81] = cell81;
            matrixMap[82] = cell82;
            matrixMap[83] = cell83;
            matrixMap[84] = cell84;
            matrixMap[85] = cell85;
            matrixMap[86] = cell86;
            matrixMap[87] = cell87;
            matrixMap[88] = cell88;
            matrixMap[89] = cell89;

            matrixMap[90] = cell90;
            matrixMap[91] = cell91;
            matrixMap[92] = cell92;
            matrixMap[93] = cell93;
            matrixMap[94] = cell94;
            matrixMap[95] = cell95;
            matrixMap[96] = cell96;
            matrixMap[97] = cell97;
            matrixMap[98] = cell98;
            matrixMap[99] = cell99;

        }

        #endregion

        #region disable view
        /**
         * Makes all of the content for this window hidden.
         * */
        private void disableAll()
        {
            disableNumMatricesView();
            disableDimView();
            disableMatrixGrid();

        }

        private void disableMatrixGrid()
        {
            for ( int i = 0; i < 100; i++ )
            {
                matrixMap[i].Visibility = Visibility.Hidden;
            }
            matrixSubmitButton.Visibility = Visibility.Hidden;
            matrixInputErrorLabel.Visibility = Visibility.Hidden;

            leftBracket2.Visibility = Visibility.Hidden;
            leftBracket4.Visibility = Visibility.Hidden;
            leftBracket6.Visibility = Visibility.Hidden;
            leftBracket8.Visibility = Visibility.Hidden;
            leftBracket10.Visibility = Visibility.Hidden;

            rightBracket2.Visibility = Visibility.Hidden;
            rightBracket4.Visibility = Visibility.Hidden;
            rightBracket6.Visibility = Visibility.Hidden;
            rightBracket8.Visibility = Visibility.Hidden;
            rightBracket10.Visibility = Visibility.Hidden;
        }

        private void disableNumMatricesView()
        {
            //Number of matrices prompt
            numInputErrorLabel.Visibility = Visibility.Hidden;
            numSubmitButton.Visibility = Visibility.Hidden;
            numberPrompt.Visibility = Visibility.Hidden;
            numberInput.Visibility = Visibility.Hidden;
        }

        private void disableDimView()
        {
            //Dimensions for matrix prompt
            dimensionsPrompt.Visibility = Visibility.Hidden;
            dimPromptMax.Visibility = Visibility.Hidden;
            dimInputCol.Visibility = Visibility.Hidden;
            dimInputRow.Visibility = Visibility.Hidden;
            rowLabel.Visibility = Visibility.Hidden;
            colLable.Visibility = Visibility.Hidden;
            xLabel.Visibility = Visibility.Hidden;
            dimSubmitButton.Visibility = Visibility.Hidden;
            dimInputErrorLabel.Visibility = Visibility.Hidden;
            dimInputErrorLabel2.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Number of Matrices
        /**
         * Displays the view, allowing input for the number of matrices (to multiply)
         * */
        private void viewGetNumMatrices()
        {
            currPage = Page.NUMMATRICES;
            disableAll();

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
                if (dimensionsPrompt.Visibility == Visibility.Visible)
                    dimSubmitButton_Click(sender, e);
                else if (numberPrompt.Visibility == Visibility.Visible)
                    numSubmitButton_Click(sender, e);
            }
        }

        private void numSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            uint ret = 0;
            if (UInt32.TryParse(numberInput.Text, out ret) && ret > 1 && ret < MAX_NUM_MATRICES)
            {
                mc.setNumMatrices((int)ret);
                this.totalMatrices = (int)ret;
                this.currMatrix = 1;
                inputMatrices();
            }
            else
                numInputErrorLabel.Visibility = Visibility.Visible;

        }

        #endregion


        /**
         * 
         * 
         * */
        private void inputMatrices()
        {
            inputDimensions();
        }


        private void inputDimensions()
        {
            viewGetDimensions();
        }

        private void inputMatrix()
        {
            viewMatrixGrid();
        }

        /**
         *      DISPLAY - for Matrix input
         * */
        private void viewMatrixGrid()
        {
            currPage = Page.MATRIXINPUT;
            disableAll();
            matrixSubmitButton.Visibility = Visibility.Visible;

            //Start creating the matrix from the most center point (startPos)
            int startPos = 10 * (4 - (numRow / 2) + ((numRow + 1) % 2)) + (4 - (numCol / 2) + ((numCol + 1) % 2));

            for (int r = 0; r < numRow * 10; r += 10)
            {
                for (int c = 0; c < numCol; c++)
                {
                    matrixMap[startPos + r + c].Visibility = Visibility.Visible;
                }
            }

            #region brackets view

            int leftOffset = 72 * (5 - ((numCol + 1) / 2));
            int rightOffset = 72 * (5 - (numCol  / 2));

            switch (numRow)
            {
                case 1:
                    leftBracket2.Visibility = Visibility.Visible;
                    rightBracket2.Visibility = Visibility.Visible;

                    leftBracket2.Margin = new Thickness(50 + leftOffset, 240, 0, 0);
                    rightBracket2.Margin = new Thickness(0, 240, 50 + rightOffset, 0);

                    break;

                case 2:
                    leftBracket2.Visibility = Visibility.Visible;
                    rightBracket2.Visibility = Visibility.Visible;

                    leftBracket2.Margin = new Thickness(50 + leftOffset, 270, 0, 0);
                    rightBracket2.Margin = new Thickness(0, 270, 50 + rightOffset, 0);
                    break;

                case 3:
                    leftBracket4.Visibility = Visibility.Visible;
                    rightBracket4.Visibility = Visibility.Visible;

                    leftBracket4.Margin = new Thickness(50 + leftOffset, 190, 0, 0);
                    rightBracket4.Margin = new Thickness(0, 190, 50 + rightOffset, 0);
                    break;

                case 4:
                    leftBracket4.Visibility = Visibility.Visible;
                    rightBracket4.Visibility = Visibility.Visible;

                    leftBracket4.Margin = new Thickness(50 + leftOffset, 215, 0, 0);
                    rightBracket4.Margin = new Thickness(0, 215, 50 + rightOffset, 0);
                    break;

                case 5:
                    leftBracket6.Visibility = Visibility.Visible;
                    rightBracket6.Visibility = Visibility.Visible;

                    leftBracket6.Margin = new Thickness(50 + leftOffset, 130, 0, 0);
                    rightBracket6.Margin = new Thickness(0, 130, 50 + rightOffset, 0);
                    break;

                case 6:
                    leftBracket6.Visibility = Visibility.Visible;
                    rightBracket6.Visibility = Visibility.Visible;

                    leftBracket6.Margin = new Thickness(50 + leftOffset, 160, 0, 0);
                    rightBracket6.Margin = new Thickness(0, 160, 50 + rightOffset, 0);
                    break;

                case 7:
                    leftBracket8.Visibility = Visibility.Visible;
                    rightBracket8.Visibility = Visibility.Visible;

                    leftBracket8.Margin = new Thickness(-120 + leftOffset, 280, 0, 0);
                    rightBracket8.Margin = new Thickness(0, 280, -120 + rightOffset, 0);
                    break;

                case 8:
                    leftBracket8.Visibility = Visibility.Visible;
                    rightBracket8.Visibility = Visibility.Visible;

                    leftBracket8.Margin = new Thickness(-120 + leftOffset, 305, 0, 0);
                    rightBracket8.Margin = new Thickness(0, 305, -120 + rightOffset, 0);
                    break;

                case 9:
                    subTitle.Margin = new Thickness(0, 5, 0, 0);

                    leftBracket10.Visibility = Visibility.Visible;
                    rightBracket10.Visibility = Visibility.Visible;

                    leftBracket10.Margin = new Thickness(-180 + leftOffset, 295, 0, 0);
                    rightBracket10.Margin = new Thickness(0, 295, -180 + rightOffset, 0);
                    break;

                case 10:
                    leftBracket10.Visibility = Visibility.Visible;
                    rightBracket10.Visibility = Visibility.Visible;


                    leftBracket10.Margin = new Thickness(-180 + leftOffset, 295, 0, 0);
                    rightBracket10.Margin = new Thickness(0, 295, -180 + rightOffset, 0);
                    break;
            }

            #endregion
        }


        /**
         *      DISPLAY - for Dimensions
         * */
        private void viewGetDimensions()
        {
            currPage = Page.MATRIXDIM;
            disableAll();

            dimensionsPrompt.Visibility = Visibility.Visible;
            dimPromptMax.Visibility = Visibility.Visible;
            dimInputCol.Visibility = Visibility.Visible;
            dimInputRow.Visibility = Visibility.Visible;
            dimSubmitButton.Visibility = Visibility.Visible;
            xLabel.Visibility = Visibility.Visible;
            rowLabel.Visibility = Visibility.Visible;
            colLable.Visibility = Visibility.Visible;
        }

        private void dimSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            uint row = 0;
            uint col = 0;
            if (UInt32.TryParse(dimInputCol.Text, out col) && UInt32.TryParse(dimInputRow.Text, out row))
            {
                if ((row > 1 || col > 1) && row <= 10 && col <= 10)
                {
                    this.numRow = (int)row;
                    this.numCol = (int)col;
                    inputMatrix();
                }
                else
                {
                    dimInputErrorLabel.Visibility = Visibility.Hidden;
                    dimInputErrorLabel2.Visibility = Visibility.Visible;
                }
            }
            else
            {
                dimInputErrorLabel2.Visibility = Visibility.Hidden;
                dimInputErrorLabel.Visibility = Visibility.Visible;
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e )
        {
            disableAll();
            if (currPage == Page.MATRIXDIM && op == MatrixOperation.MULTIPLY)
                viewGetNumMatrices();
            else if (currPage == Page.MATRIXDIM && op != MatrixOperation.MULTIPLY)
                this.Close();
            else if (currPage == Page.MATRIXINPUT)
                viewGetDimensions();
            else if (currPage == Page.NUMMATRICES)
                this.Close();
        }

        private void matrixSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int startPos = 10 * (4 - (numRow / 2) + ((numRow + 1) % 2)) + (4 - (numCol / 2) + ((numCol + 1) % 2));
            int[][] mat = new int[numRow][];
            int next;
            
            int i = 0, j = 0;
            for (int r = 0; r < numRow * 10; r += 10)
            {
                for (int c = 0; c < numCol; c++)
                {
                    if (Int32.TryParse(matrixMap[startPos + r + c].Text, out next))
                        mat[i][j] = next;
                    else
                    {
                        matrixInputErrorLabel.Visibility = Visibility.Visible;
                        return;
                    }
                    j++;
                }
                i++;
            }

            AdvancedCalculator.Matrix newMat = new AdvancedCalculator.Matrix(mat);
            mc.addMatrix(newMat);

            if (currMatrix == totalMatrices)
                //Finishing page and close
                this.Close();
            else
            {
                currMatrix++;
                viewGetDimensions();
            }
        }


        /**
         *     Highlights text when a TextBox is selected.
         * */
        private void textBox_GotMouseCapture(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        
    }
}