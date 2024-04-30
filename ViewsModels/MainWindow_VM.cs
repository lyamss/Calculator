using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace Calculator.ViewsModels
{
    public class MainWindow_VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _DisplayResultCalcul;
        public string DisplayResultCalcul
        {
            get { return _DisplayResultCalcul; }
            set
            {
                _DisplayResultCalcul = value;
                OnPropertyChanged(); // update Front
            }
        }

        private double _currentValue;
        private double _storedValue;
        private char _selectedOperator;

        public ICommand NumberCommand { get; set; }
        public ICommand OperatorCommand { get; set; }
        public ICommand EqualCommand { get; set; }

        public MainWindow_VM()
        {
            NumberCommand = new RelayCommand<string>(Number_Click);
            OperatorCommand = new RelayCommand<string>(Operator_Click);
            EqualCommand = new RelayCommand<string>(Equal_Click);
        }

        private void Number_Click(string number)
        {
            if (_selectedOperator == '\0')
            {
                _currentValue = double.Parse(DisplayResultCalcul + number);
                DisplayResultCalcul = _currentValue.ToString();
            }
            else
            {
                _currentValue = double.Parse(DisplayResultCalcul + number);
                DisplayResultCalcul = _currentValue.ToString();
            }
        }

        private void Operator_Click(string @operator)
        {
            switch (@operator)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    _storedValue = _currentValue;
                    _selectedOperator = char.Parse(@operator);
                    DisplayResultCalcul = string.Empty;
                    break;
            }
        }

        private void Equal_Click(string obj)
        {
            switch (_selectedOperator)
            {
                case '+':
                    _currentValue += _storedValue;
                    break;
                case '-':
                    _currentValue = _storedValue - _currentValue;
                    break;
                case '*':
                    _currentValue *= _storedValue;
                    break;
                case '/':
                    _currentValue = _storedValue / _currentValue;
                    break;
            }

            DisplayResultCalcul = _currentValue.ToString();
            // reset All first Number (storedValue) AND Second Number (currentValue) AND Selected Operator
            _selectedOperator = '\0';
            _currentValue = 0;
            _storedValue = 0;
        }
    }
}