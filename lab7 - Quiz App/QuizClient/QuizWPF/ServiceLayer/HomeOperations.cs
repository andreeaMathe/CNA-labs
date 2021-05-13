using QuizWPF.ViewModel;
using QuizWPF.Views;
using System.Windows;

namespace QuizWPF.ServiceLayer
{
    class HomeOperations
    {
        public void StartQuiz(object param)
        {
            var homeWindow = param as Window;
            homeWindow.Hide();

            var questionVM = new QuestionViewModel();
            var questionWindow = new QuizMainWindow() { DataContext = questionVM };
            questionWindow.ShowDialog();
            homeWindow.Owner = questionWindow;
        }

        public void Exit(object param)
        {
            Application.Current.Shutdown();
        }
    }
}
