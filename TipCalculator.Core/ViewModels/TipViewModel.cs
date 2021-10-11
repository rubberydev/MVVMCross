using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TipCalculator.Core.Services;

namespace TipCalculator.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        public ObservableCollection<string> OperationItems { get; set; }

        private readonly ICalculationService _calculationService;
        private int _firstValue;
        private string _operationValue;
        private int _secondValue;
        private double _result;
        private string _resultText;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
            
            
        }

        public string SelectedOperation
        {
            get
            {
                return SelectedOperation;
            }
            set
            {
                 SelectedOperation = value;
                RaisePropertyChanged(() => SelectedOperation);
            }
        }

        public int FirstValue
        {
             get => _firstValue;
            set
            {
                _firstValue = value;
                RaisePropertyChanged(() => FirstValue);
            }
        }
        public int SecondValue
        {
            get => _secondValue;
            set
            {
                _secondValue = value;
                RaisePropertyChanged(() => SecondValue);
            }
        }

        public string OperationValue
        {
            get => _operationValue;
            set
            {
                _operationValue = value;
                RaisePropertyChanged(() => OperationValue);
                Calculate(value);
            }
        }
        public double Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        public string ResultText
        {
            get => _resultText;
            set => SetProperty(ref _resultText, value);
        }


        public override async Task Initialize()
        {
            await base.Initialize();

            FirstValue = 0;
            ResultText = "OK";
        }

        private void Calculate(string operation)
        {
            
            switch (operation.ToLower())
            {

                case "tip":
                    Result = (double)_calculationService.TipAmount(FirstValue, SecondValue);
                    break;
                case "sum":
                    Result = _calculationService.Sum(FirstValue, SecondValue);
                    break;
                case "subst":
                    Result = _calculationService.Substraction(FirstValue, SecondValue);
                    break;
                case "div":
                    {

                        Result = (double)_calculationService.Division(FirstValue, SecondValue);
                        if (Result == 0)
                            ResultText = "Division by Zero is not permited";
                        break;
                    }
                case "mult":
                    Result = _calculationService.Multiplication(FirstValue, SecondValue);
                    break;
                case "pow":
                    Result = (double)_calculationService.Pow(FirstValue);
                    break;
                case "sqrt":
                    Result = _calculationService.Sqrt(FirstValue);
                    break;
                default:
                    return;

            }
        }
    }

    
}
