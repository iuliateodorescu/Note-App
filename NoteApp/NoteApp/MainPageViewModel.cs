using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Text;
using Xamarin.Forms;


namespace NoteApp.ViewModel
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });
            DeleteCommand = new Command(() => TheNote = string.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> AllNotes { get; set; } = new ObservableCollection<string>();

        string theNote;
        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
    }
}
