using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfKwiaty
{
    /// <summary>
    /// Logika interakcji dla klasy DeletePlant.xaml
    /// </summary>
    public partial class DeletePlant : Window
    {
        public DeletePlant()
        {
            InitializeComponent();

        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
