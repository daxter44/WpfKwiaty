using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfKwiaty.Models;

namespace WpfKwiaty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ObservableCollection<Plant> plants =new ObservableCollection<Plant>();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            seedPlantList();
            dataTable.ItemsSource = plants;
        }

        public void seedPlantList()
        {
            Plant plant1 = new Plant();
            plant1.id = 1;
            plant1.name = "Jabłoń";
            plant1.type = "drzewo";
            plant1.dateOfBirth = new DateTime(2020, 1,1);
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
            plants.Add(plant1);
            plants.Add(plant2);
            plants.Add(plant3);
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePlant cp = new CreatePlant();
            cp.ShowDialog();

            Plant newPlant = new Plant();
            newPlant.name = cp.plantNme.Text;
            newPlant.type = cp.typeList.Text;
            newPlant.id = lastPlantId() + 1;
            //newPlant.dateOfBirth = cp.;

            plants.Add(newPlant);
        }
        private void DeletePlant(object sender, RoutedEventArgs e)
        {
            DeletePlant dp = new DeletePlant((Plant)dataTable.SelectedItem);
            const string m = "Czy aby napewno chcesz usunąć zaznaczoną roślinę?";
            const string c = "Zamknij";
            var result = MessageBox.Show(m, c, MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes) 
            {
                plants.Remove((Plant)dataTable.SelectedItem);
            }

            //dp.ShowDialog();
            
        }
        private int lastPlantId()
        {
            return plants.Last().id;
        }
        private void EditPlant(object sender, RoutedEventArgs e)
        {
            EditPlant ep = new EditPlant((Plant)dataTable.SelectedItem);
            ep.ShowDialog();
            // ep.editPlant;
            
            try
            {
                Plant editedPlant = ((EditPlantViewModel)ep.DataContext).plantToEdit;

                var selectedIndex = ((Plant)dataTable.SelectedItem).id-1;
                plants[selectedIndex] = editedPlant;
                OnPropertyChanged("plants");
            }
            catch (Exception)
            {

                throw;
            }

        }


        
    }
}
