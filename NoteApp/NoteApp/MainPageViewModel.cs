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
            AllNotes = new ObservableCollection<string>();

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });

            DeleteCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SelectedNoteChangedCommand = new Command(async () =>
            {
                //new up view model for Detail Page
                var detailVM = new DetailPageViewModel(SelectedNote);
                //new up the page
                var detailPage = new DetailPage();

                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> AllNotes { get; set; }

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


        string selectedNote;
        public string SelectedNote
        {
            get => selectedNote;
            set 
            {
                selectedNote = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedNote));

                PropertyChanged?.Invoke(this, args);
            }
        }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }
        public Command SelectedNoteChangedCommand { get; }
    }
}
