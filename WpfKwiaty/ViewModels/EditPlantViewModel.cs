using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfKwiaty.Models;
using MvvmArchitecture;

namespace WpfKwiaty.ViewModels
{
    public class EditPlantViewModel : ViewModelBase

    {
        public Plant plantToEdit { get; set; }
        public string? mychoriza
        {
            get
            {
                return plantToEdit.mycorrhiza ? "Tak" : "Nie";
            }
            set
            {
                plantToEdit.mycorrhiza = (value == "Tak");
            }
        }
        public DateTime? nutrition
        {
            get
            {
                return plantToEdit.nutrition;
            }
            set
            {
                plantToEdit.nutrition = value;
            }
        }
        public ObservableCollection<string> CmbContent { get; private set; }

        public string micorhyze { get; set; }
        public EditPlantViewModel(Plant plantToEdit)
        {
            this.plantToEdit = plantToEdit;
            CmbContent = new ObservableCollection<string>
            {
                "Tak",
                "Nie"
            };

        }
    }
}
