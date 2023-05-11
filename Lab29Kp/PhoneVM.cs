﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab29Kp
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        private Phone phone;

        public PhoneViewModel(Phone p)
        {
            phone = p;
        }

        public string Title
        {
            get { return phone.Title; }
            set
            {
                phone.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Company
        {
            get { return phone.Company; }
            set
            {
                phone.Company = value;
                OnPropertyChanged("Company");
            }
        }
        public int Price
        {
            get { return phone.Price; }
            set
            {
                phone.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
