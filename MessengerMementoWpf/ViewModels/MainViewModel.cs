using MessengerMementoWpf.Commands;
using MessengerMementoWpf.Services;
using MessengerMementoWpf.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMementoWpf.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; OnPropertyChanged(); }
        }


        public RelayCommand LoginCommand { get; set; }
        public User User { get; set; }

        public MainViewModel()
        {
            User = new User();
            LoginCommand = new RelayCommand(e =>
            {
                User.AddUser(Nickname);
                MessengerView messengerView = new MessengerView
                {
                    DataContext = new MessengerViewModel(User, Nickname)
                };
                Nickname = string.Empty;
                messengerView.Show();

            });
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
