using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMementoWpf.Services
{
    public class User
    {
        public ObservableCollection<string> Messages { get; set; }

        public User()
        {
            Messages = new ObservableCollection<string>();
        }

        public void AddUser(string name)
        {
            string texts = "";
            texts = $"{name}:joined";
            Messages.Add(texts);
        }

        public void UserSend(string name, string message)
        {
            string texts = "";
            texts = $"{name}:{message}";
            Messages.Add(texts);
        }

        public void UserLeft(string name)
        {
            string texts = "";
            texts = $"{name}:left";
            Messages.Add(texts);
        }
    }
}
