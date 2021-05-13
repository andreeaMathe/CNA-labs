using QuizLibrary.Model;
using QuizLibrary.Requests;
using QuizWPF.Commands;
using QuizWPF.Extensions;
using QuizWPF.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizWPF.ViewModel
{
    class QuestionViewModel : BasePropertyChanged
    {
        public QuestionViewModel()
        {
            InitializeQuestion();
        }

        private async void InitializeQuestion()
        {
            var clientRequest = new ClientRequest();
            var receivedQuestion = await clientRequest.RequestCurrentQuestion(1);

            Answers = receivedQuestion.Answers/*.Select(a => a.Description)*/.ToObservableCollection();
            QuestionDescription = receivedQuestion.Description;
        }

        private string questionDescription;
        public string QuestionDescription
        {
            get { return questionDescription; }
            set
            {
                questionDescription = value;
                NotifyPropertyChanged(nameof(QuestionDescription));
            }
        }

        private Answer selectedAnswer;
        public Answer SelectedAnswer
        {
            get { return selectedAnswer; }
            set
            {
                selectedAnswer = value;
                NotifyPropertyChanged(nameof(SelectedAnswer));
            }
        }

        private ObservableCollection<Answer> answers;
        public ObservableCollection<Answer> Answers
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
                    var operations = new QuestionOperations();
                    submitPressed = new RelayCommand(operations.Submit);
                }
                return submitPressed; 
            }
        }
    }
}
