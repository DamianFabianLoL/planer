using PlanMenager.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PlanMenager
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Subject> Subjects { get; } = new ObservableCollection<Subject>();

        private Subject? _selectedSubject;
        public Subject? SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                if (_selectedSubject == value) return;
                _selectedSubject = value;
                OnPropertyChanged();
                _deleteCommand?.RaiseCanExecuteChanged();
            }
        }

        private readonly RelayCommand _addCommand;
        private readonly RelayCommand _deleteCommand;

        public ICommand AddCommand => _addCommand;
        public ICommand DeleteCommand => _deleteCommand;

        public MainViewModel()
        {
            // initialize commands first so RaiseCanExecuteChanged is available
            _addCommand = new RelayCommand(AddSubject);
            _deleteCommand = new RelayCommand(DeleteSubject, () => SelectedSubject != null && Subjects.Contains(SelectedSubject));

            // optional sample item
            Subjects.Add(new Subject { Name = "Matematyka", Subname = "Algebra", Room = "101", Note = "Ćwiczenia co drugi tydzień" });
        }

        private void AddSubject()
        {
            var s = new Subject
            {
                Name = "Nowy przedmiot",
                Subname = "Podtytuł",
                Room = "101",
                Note = string.Empty
            };

            Subjects.Add(s);
            SelectedSubject = s;
            _deleteCommand?.RaiseCanExecuteChanged();
        }

        private void DeleteSubject()
        {
            if (SelectedSubject != null && Subjects.Contains(SelectedSubject))
            {
                Subjects.Remove(SelectedSubject);
                SelectedSubject = null;
                _deleteCommand?.RaiseCanExecuteChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
