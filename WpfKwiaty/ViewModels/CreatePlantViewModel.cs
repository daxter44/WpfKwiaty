using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Windows;
using WpfKwiaty.Models;
using MvvmArchitecture;

namespace WpfKwiaty.ViewModels
{
    class CreatePlantViewModel : ViewModelBase
    {
        public RelayCommand CreatePlantCommand { get; private set; }

        private Plant _newPlant;
        public Plant NewPlant
        {
            get
            {
                return _newPlant;
            }
            set
            {
                _newPlant = value;
            }

        }
        public string name
        {
            get
            {
                return NewPlant.name;
            }
            set
            {
                NewPlant.name = value;
            }
        }
        public string type
        {
            get
            {
                return NewPlant.type;
            }
            set
            {
                NewPlant.type = value;
            }
        }
        public DateTime date
        {
            get
            {
                return NewPlant.dateOfBirth;
            }
            set
            {
                NewPlant.dateOfBirth = value;
            }
        }
        public string? mychoriza
        {
            get
            {
                return NewPlant.mycorrhiza ? "Tak" : "Nie";
            }
            set
            {
                NewPlant.mycorrhiza = (value == "Tak");
            }
        }
        public CreatePlantViewModel(Plant NewPlant)
        {
            this.NewPlant = NewPlant;
        }
    }
}
