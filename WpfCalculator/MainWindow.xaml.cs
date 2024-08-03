using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _input = string.Empty;
        private List<double> _numbers = new List<double>();
        private List<string> _operators = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                _input += button.Content.ToString();
                textBox.Text = _input;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && !string.IsNullOrEmpty(_input))
            {
                _numbers.Add(double.Parse(_input));
                _operators.Add(button.Content.ToString());
                _input = string.Empty;
            }
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_input))
            {
                _numbers.Add(double.Parse(_input));
            }

            double result = _numbers[0];

            for (int i = 0; i < _operators.Count; i++)
            {
                switch (_operators[i])
                {
                    case "+":
                        result += _numbers[i + 1];
                        break;
                    case "-":
                        result -= _numbers[i + 1];
                        break;
                    case "*":
                        result *= _numbers[i + 1];
                        break;
                    case "/":
                        result /= _numbers[i + 1];
                        break;
                }
            }

            textBox.Text = result.ToString();
            _input = string.Empty;
            _numbers.Clear();
            _operators.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _input = string.Empty;
            _numbers.Clear();
            _operators.Clear();
            textBox.Text = "0";
        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_input.Contains("."))
            {
                _input += ".";
                textBox.Text = _input;
            }
        }
    }
}