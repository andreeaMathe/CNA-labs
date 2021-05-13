using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace QuizWPF.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IList<T> input)
        {
            return new ObservableCollection<T>(input);
        }
    }
}
