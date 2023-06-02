using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace HouseBuilderWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_CountOfFloor_Click(object sender, RoutedEventArgs e)
        {
            Builder builder = new Builder();
            Window1 window1 = new Window1(builder);
            
            bool success = byte.TryParse(this.TextBox_CountOfFloor.Text, out byte result);
            if (success)
            {
                if (result <= 5 && result > 0) {builder.CountOfFloor = result; window1.Show(); }
                    else { MessageBox.Show("Parse exception, try use numbers ", "exception", MessageBoxButton.OK, MessageBoxImage.Warning); }
            } 
            else { MessageBox.Show("Parse exception, try use numbers ", "exception", MessageBoxButton.OK, MessageBoxImage.Warning); }

            if (builder.CountOfFloor == 1)
            {
                window1.TextBox_FifthFloorArea.Visibility = Visibility.Hidden;
                window1.label5.Visibility = Visibility.Hidden;
                window1.TextBox_FourthFloorArea.Visibility = Visibility.Hidden;
                window1.label4.Visibility = Visibility.Hidden;
                window1.TextBox_ThirdFloorArea.Visibility = Visibility.Hidden;
                window1.label3.Visibility = Visibility.Hidden;
                window1.TextBox_SecondFloorArea.Visibility = Visibility.Hidden;
                window1.label2.Visibility = Visibility.Hidden;
            }
            else
            if (builder.CountOfFloor == 2)
            {
                window1.TextBox_FifthFloorArea.Visibility = Visibility.Hidden;
                window1.label5.Visibility = Visibility.Hidden;
                window1.TextBox_FourthFloorArea.Visibility = Visibility.Hidden;
                window1.label4.Visibility = Visibility.Hidden;
                window1.TextBox_ThirdFloorArea.Visibility = Visibility.Hidden;
                window1.label3.Visibility = Visibility.Hidden;
            }
            else
            if (builder.CountOfFloor == 3)
            {
                window1.TextBox_FifthFloorArea.Visibility = Visibility.Hidden;
                window1.label5.Visibility = Visibility.Hidden;
                window1.TextBox_FourthFloorArea.Visibility = Visibility.Hidden;
                window1.label4.Visibility = Visibility.Hidden;
            }
            else
            if (builder.CountOfFloor == 4)
            {
                window1.TextBox_FifthFloorArea.Visibility = Visibility.Hidden;
                window1.label5.Visibility = Visibility.Hidden;
            }
            else
            if (builder.CountOfFloor == 5)
            {
            }else
            {
                window1.TextBox_FifthFloorArea.Visibility = Visibility.Hidden;
                window1.label5.Visibility = Visibility.Hidden;
                window1.TextBox_FourthFloorArea.Visibility = Visibility.Hidden;
                window1.label4.Visibility = Visibility.Hidden;
                window1.TextBox_ThirdFloorArea.Visibility = Visibility.Hidden;
                window1.label3.Visibility = Visibility.Hidden;
                window1.TextBox_SecondFloorArea.Visibility = Visibility.Hidden;
                window1.label2.Visibility = Visibility.Hidden;
            }
        }//если найдешь время - сделай метод который будет прописывать Visibility для подписи и текстбокса, чтобы сократить код в два раза, просто вызывая функцию
    }
}