using QuizWPF.Commands;
using QuizWPF.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace QuizWPF.ViewModel
{
    class QuestionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string question;
        public string Question
        {
            get { return question; }
            set
            { 
                question = value;
                NotifyPropertyChanged(nameof(Question));
            }
        }

        private ObservableCollection<string> answers;
        public ObservableCollection<string> Answers
        {
            get { return answers; }
            set
            {
                answers = value;
                NotifyPropertyChanged(nameof(Answers));
            }
        }

        private ICommand submitPressed;
        public ICommand SubmitPressed
        {
            get 
            {
                if(submitPressed == null)
                {
                    var operations = new Operations();
                    submitPressed = new RelayCommand(operations.Submit);
                }
                return submitPressed; 
            }
        }
    }
}
