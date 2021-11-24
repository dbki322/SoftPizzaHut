using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPizzaHut.ViewModel
{
    public class MessageViewModel
    {
        public string Message { get; }

        public MessageViewModel(string message)
        {
            Message = message;
        }
    }

}
