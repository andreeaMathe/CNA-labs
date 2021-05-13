using QuizWPF.Commands;
using QuizWPF.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace QuizWPF.ViewModel
{
    public class HomeViewModel : BasePropertyChanged
    {
        private ICommand startQuiz;
        public ICommand StartQuiz
        {
            get
            {
                if (startQuiz == null)
                {
                    var homeOperations = new HomeOperations();
                    startQuiz = new RelayCommand(homeOperations.StartQuiz);
                }
                return startQuiz;
            }
        }

        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    var homeOperations = new HomeOperations();
                    exit = new RelayCommand(homeOperations.Exit);
                }
                return exit;
            }
        }
    }
}
