using MessengerMementoWpf.Commands;
using MessengerMementoWpf.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMementoWpf.ViewModels
{
    public class MessengerViewModel: INotifyPropertyChanged
    {
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(); }
        }

        public User User { get; set; }
        public string Nickname { get; set; }
        public RelayCommand SendCommand { get; set; }

        public RelayCommand LeftCommand { get; set; }
        public MessengerViewModel(User user, string nickname)
        {
            User = user;
            Nickname = nickname;
            SendCommand = new RelayCommand(e =>
            {
                User.UserSend(nickname, Message);

            });

            LeftCommand = new RelayCommand(e =>
            {
                User.UserLeft(nickname);
                //MessengerView messengerView = new MessengerView
                //{
                //    DataContext = new MessengerViewModel(user, nickname)
                //};
                //messengerView.Close();
            });

        }

      


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
