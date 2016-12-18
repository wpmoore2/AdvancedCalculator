using AdvancedCalculatorView.src.View.Main;
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

namespace AdvancedCalculatorView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum MatrixOperation { MULTIPLY, INVERSE};


        public MainWindow()
        {
            InitializeComponent();
            disableAll();
            viewMainMenu();
        }

        private void disableAll()
        {
            disableMainMenu();
            disableMatrixMenu();
        }

        private void viewMainMenu()
        {
            Title = "Advanced Calculator - Home";
            mainSubTitle.Visibility = Visibility.Visible;
            mainMatrixButton.Visibility = Visibility.Visible;

        }

        private void disableMainMenu()
        {
            mainMatrixButton.Visibility = Visibility.Hidden;
            mainSubTitle.Visibility = Visibility.Hidden;
        }

        private void viewMatrixOptions()
        {
            Title = "Advanced Calculator - Matrix Operations";
            multiplyButton.Visibility = Visibility.Visible;
            matrixTitle.Visibility = Visibility.Visible;
            inverseButton.Visibility = Visibility.Visible;
        }

        private void disableMatrixMenu()
        {
            matrixTitle.Visibility = Visibility.Hidden;
            multiplyButton.Visibility = Visibility.Hidden;
            inverseButton.Visibility = Visibility.Hidden;
        }


        //Buttons

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            disableAll();
            viewMainMenu();
        }

        private void MatrixButton_Click(object sender, RoutedEventArgs e)
        {
            disableMainMenu();
            viewMatrixOptions();
        }

        private void MatrixMultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            MatrixGenerator mg = new MatrixGenerator(MatrixOperation.MULTIPLY);
            mg.Show();
        }

    }
}
