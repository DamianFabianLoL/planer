using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlanMenager.Models
{
    public class Subject : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _subname = string.Empty;
        private string _room = string.Empty;
        private string _note = string.Empty;

        public string Name
        {
            get => _name;
            set { if (_name == value) return; _name = value; OnPropertyChanged(); }
        }

        public string Subname
        {
            get => _subname;
            set { if (_subname == value) return; _subname = value; OnPropertyChanged(); }
        }

        public string Room
        {
            get => _room;
            set { if (_room == value) return; _room = value; OnPropertyChanged(); }
        }

        public string Note
        {
            get => _note;
            set { if (_note == value) return; _note = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
