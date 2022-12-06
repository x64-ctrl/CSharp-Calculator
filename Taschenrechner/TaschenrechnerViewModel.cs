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

        public ICommand OnPropertyChanged { get; set; }

        // send information from numbers to frontend when buttons pressed
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
                OnPropertyChanged();
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
            switch (parameter + _input)
            {
                case "1":
                    MessageBox.Show("\t1");  
                    break;

                case "2":
                    MessageBox.Show("\t2");
                    break;

                case "3":
                    MessageBox.Show("\t3"); 
                    break;

                case "4":
                    MessageBox.Show("\t4");
                    break;

                case "5":
                    MessageBox.Show("\t5");
                    break;
            
                case "6":
                    MessageBox.Show("\t6");
                    break;
            
                case "7":
                    MessageBox.Show("\t7");
                    break;

                case "8": 
                    MessageBox.Show("\t8");
                    break;
            
                case "9":
                    MessageBox.Show("\t9");
                    break;
            
                case "0":
                    MessageBox.Show("\t0");
                    break;


                // Operatoren
                case "+":
                    MessageBox.Show("\t+");
                    break;

                case "-":
                    MessageBox.Show("\t-");
                    break;
                case "*":
                    MessageBox.Show("\t*");
                    break;
                case "/":
                    MessageBox.Show("\t/");
                    break;
                case "=":
                    MessageBox.Show("\t=");
                    break;
                case "C":
                    MessageBox.Show("\tC");
                    break;


                    // build functions for operators



                    #endregion
            }
        }
    }
}