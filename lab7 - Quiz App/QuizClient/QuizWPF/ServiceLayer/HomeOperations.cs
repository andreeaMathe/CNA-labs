using QuizWPF.ViewModel;
using QuizWPF.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace QuizWPF.ServiceLayer
{
    class HomeOperations
    {
        public void StartQuiz(object param)
        {
            var questionVM = new QuestionViewModel();
            var window = new QuizMainWindow() { DataContext = questionVM };
            window.ShowDialog();

            //var homeWindow = param as Window;
            //homeWindow.Close();
        }

        public void Exit(object param)
        {
            Application.Current.Shutdown();
            //Application.Current.Dispatcher.Invoke(Application.Current.Shutdown);
        }
    }
}
