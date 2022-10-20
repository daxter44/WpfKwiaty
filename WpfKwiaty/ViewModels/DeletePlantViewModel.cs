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
    class DeletePlantViewModel : ViewModelBase
    {
        private Plant _plantToDelete;
        public Plant PlantToDelete
        {
            get
            {
                return _plantToDelete;
            }
            set
            {
                _plantToDelete = value;
            }

        }
        public DeletePlantViewModel(Plant PlantToDelete)
        {
            this.PlantToDelete = PlantToDelete;
        }
        public RelayCommand DeletePlantCommand { get; private set; }


    }

}
