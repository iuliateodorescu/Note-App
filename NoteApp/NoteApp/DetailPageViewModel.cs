using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Text;
using Xamarin.Forms;


namespace NoteApp.ViewModel
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel( string note )
        {
            DismissPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            });

            NoteText = note;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                var args = new PropertyChangedEventArgs(nameof(NoteText));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command DismissPageCommand { get; }
    }
}
