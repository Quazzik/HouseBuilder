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

namespace HouseBuilderWindow
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Builder _builder = new Builder();
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(Builder builder): this()
        {
            builder = _builder;
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            _builder.FirstFloorArea = TextBox_FirstFloorArea.Text != "" ? Convert.ToDouble(TextBox_FirstFloorArea.Text) : 0;
            _builder.SecondFloorArea = TextBox_SecondFloorArea.Text != "" ? Convert.ToDouble(TextBox_SecondFloorArea.Text) : 0;
            _builder.ThirdFloorArea = TextBox_ThirdFloorArea.Text != "" ? Convert.ToDouble(TextBox_ThirdFloorArea.Text) : 0;
            _builder.FourthFloorArea = TextBox_FourthFloorArea.Text != "" ? Convert.ToDouble(TextBox_FourthFloorArea.Text) : 0;
            _builder.FifthFloorArea = TextBox_FifthFloorArea.Text != "" ? Convert.ToDouble(TextBox_FifthFloorArea.Text) : 0;
            _builder.NumberOfOptions = TextBox_NumberOfOptions.Text != "" ? Convert.ToInt32(TextBox_NumberOfOptions.Text) : 0;
            Window2 window2 = new Window2(_builder);
            window2.Show();
            if (_builder.CountOfFloor.ToString() == "1")
            {
                _builder.FirstFloorArea = Convert.ToDouble(TextBox_FirstFloorArea.Text);
            }
            if (_builder.CountOfFloor.ToString() == "2")
            {
                _builder.SecondFloorArea = Convert.ToDouble(TextBox_SecondFloorArea.Text);
                _builder.FirstFloorArea = Convert.ToDouble(TextBox_FirstFloorArea.Text);
            }
            if (_builder.CountOfFloor.ToString() == "3")
            {
                _builder.SecondFloorArea = Convert.ToDouble(TextBox_SecondFloorArea.Text);
                _builder.FirstFloorArea = Convert.ToDouble(TextBox_FirstFloorArea.Text);
                _builder.ThirdFloorArea = Convert.ToDouble(TextBox_ThirdFloorArea.Text);
            }
            if (_builder.CountOfFloor.ToString() == "4")
            {
                _builder.SecondFloorArea = Convert.ToDouble(TextBox_SecondFloorArea.Text);
                _builder.FirstFloorArea = Convert.ToDouble(TextBox_FirstFloorArea.Text);
                _builder.ThirdFloorArea = Convert.ToDouble(TextBox_ThirdFloorArea.Text);
                _builder.FourthFloorArea = Convert.ToDouble(TextBox_FourthFloorArea.Text);
            }
            if (_builder.CountOfFloor.ToString() == "5")
            {
                _builder.FifthFloorArea = Convert.ToDouble(TextBox_FifthFloorArea.Text);
                _builder.SecondFloorArea = Convert.ToDouble(TextBox_SecondFloorArea.Text);
                _builder.FirstFloorArea = Convert.ToDouble(TextBox_FirstFloorArea.Text);
                _builder.ThirdFloorArea = Convert.ToDouble(TextBox_ThirdFloorArea.Text);
                _builder.FourthFloorArea = Convert.ToDouble(TextBox_FourthFloorArea.Text);
            }
        }
    }
}