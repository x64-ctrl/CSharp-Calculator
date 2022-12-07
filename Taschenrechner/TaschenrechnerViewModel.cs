using System;
using System.Dynamic;
using Netco.Infrastructure;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace Taschenrechner


{

    public class TaschenrechnerViewModel : BaseViewModel
    {
        #region Fields

        private string _input;
        private int _lastOperand;
        private string _lastOperator;

        public ICommand TaschenrechnerInput { get; set; }

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged(_input);
            }
        }


        #endregion
        #region Properties

        int _ergebnis;
		public int Ergebnis
		{
			get { return _ergebnis; }
			set
			{
				if (value != _ergebnis)
				{
					_ergebnis = value;
					OnPropertyChanged("Ergebnis");
				}
			}
		}

		public ICommand ButtonCommand { get; private set; }

		#endregion

		#region Constructor

		public TaschenrechnerViewModel()
		{
			ButtonCommand = new RelayCommand<string>(OnButtonCommand);
		}

        #endregion

        #region Methods

        private void OnButtonCommand(string parameter)
        {
            string tmp = Input;
            switch (parameter)
            {
                
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    
                    tmp = tmp + parameter;
                    if (int.TryParse(tmp, out int result))
                    {
                        Input = tmp;
                        Ergebnis = result;
                    }
                    
                    break;



                // Operatoren
                case "+":
                case "-":
                case "*":
                case "/":
                    
                    _lastOperator = parameter;
                    _lastOperand = Ergebnis;
                    Input = "";
                    break;



                case "AC":
                    Input = "";
                    Ergebnis = 0;
                    break;

                case "=":
                    switch (_lastOperator)
                    {
                        case "+":
                            Ergebnis = _lastOperand + Ergebnis;
                            break;
                        case "-":
                            Ergebnis = _lastOperand - Ergebnis;
                            break;
                        case "*":
                            Ergebnis = _lastOperand * Ergebnis;
                            break;
                        case "/":
                            if (_lastOperand != 0) ;
                            return;
                            Ergebnis = _lastOperand / Ergebnis;
                            break;
                        
                    }
                    #endregion
                    break;

               // DEL KEY
                case "DEL":
                    if (tmp.Length > 0)
                    {
                        tmp = tmp.Substring(0, tmp.Length - 1);
                        Input = tmp;
                        if (int.TryParse(tmp, out int result2))
                        {
                            Ergebnis = result2;
                        }
                    }

                    break;

                   
                    




                /* case "NumPad1":
                 case "NumPad2":
                 case "NumPad3":
                 case "NumPad4":
                 case "NumPad5":
                 case "NumPad6":
                 case "NumPad7":
                 case "NumPad8":
                 case "NumPad9":
                 case "NumPad0":
                     tmp = tmp + parameter.Substring(6);
                     if (int.TryParse(tmp, out int result2))
                     {
                         Input = tmp;
                         Ergebnis = result;
                     }
                     break; */

            }
        }
    }
}