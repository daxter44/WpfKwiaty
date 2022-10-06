using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows;
using WpfKwiaty.Models;
using WpfKwiaty.MvvmTools;

namespace WpfKwiaty.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Plant> _plants = new ObservableCollection<Plant>();
        public ObservableCollection<Plant> Plants { 
            get
            {
                return _plants; 
            }
            set
            {
                _plants = value;
            }
        }

        private Plant _selectedPlant; 
        public Plant SelectedPlant
        {
            get
            {
                return _selectedPlant;
            }
            set
            {
                _selectedPlant = value;
            }
        }

        public RelayCommand CreatePlantCommand { get; private set; }
        public RelayCommand DeletePlantCommand { get; private set; }

        public MainWindowViewModel()
        {
            seedPlantList();
            CreatePlantCommand = new RelayCommand(createPlant);
            DeletePlantCommand = new RelayCommand(deletePlant);
        }

        public void seedPlantList()
        {
            Plant plant1 = new Plant();
            plant1.id = 1;
            plant1.name = "Jabłoń";
            plant1.type = "drzewo";
            plant1.dateOfBirth = new DateTime(2020, 1, 1);
            plant1.nutrition = new DateTime(2022, 02, 03);
            Plant plant2 = new Plant();
            plant2.id = 2;
            plant2.name = "Grusza";
            plant2.type = "drzewo";
            plant2.dateOfBirth = new DateTime(2019, 3, 1);
            Plant plant3 = new Plant();
            plant3.id = 3;
            plant3.name = "Róża";
            plant3.type = "krzew";
            plant3.dateOfBirth = new DateTime(2021, 4, 1);
            Plants.Add(plant1);
            Plants.Add(plant2);
            Plants.Add(plant3);
        }

        private int lastPlantId()
        {
            return Plants.Last().id;
        }

        public void createPlant(object obj)
        {
            CreatePlant cp = new CreatePlant();
            cp.ShowDialog();

            Plant newPlant = new Plant();
            newPlant.name = cp.plantNme.Text;
            newPlant.type = cp.typeList.Text;
            newPlant.id = lastPlantId() + 1;
            //newPlant.dateOfBirth = cp.;

            Plants.Add(newPlant);
        }

        private void deletePlant(object obj)
        {
            DeletePlant dp = new DeletePlant(SelectedPlant);
            const string m = "Czy aby napewno chcesz usunąć zaznaczoną roślinę?";
            const string c = "Zamknij";
            var result = MessageBox.Show(m, c, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Plants.Remove(SelectedPlant);
            }
        }

        private void editPlant(object obj)
        {
            EditPlant ep = new EditPlant(SelectedPlant);
            ep.ShowDialog();
            // ep.editPlant;

            try
            {
                Plant editedPlant = ((EditPlantViewModel)ep.DataContext).plantToEdit;

                var selectedIndex = (SelectedPlant).id - 1;
                Plants[selectedIndex] = editedPlant;
                OnPropertyChanged("plants");
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
