using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gra_w_życie__Conwaya
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int gridSize = 5; // Zdefiniuj rozmiar siatki

        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < Symulator_gry_w_życie.dlugosc_boku_planszy; row++)
            {
                dynamicGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

                for (int col = 0; col < Symulator_gry_w_życie.dlugosc_boku_planszy; col++)
                {
                    if (row == 0) // Dodaj kolumny tylko raz (w pierwszym wierszu)
                    {
                        dynamicGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
                    }

                    CheckBox checkBox = new CheckBox();
                    checkBox.Content = $"Checkbox {row + 1}, {col + 1}";

                    // Dodaj obsługę zdarzenia dla każdego CheckBox
                    checkBox.Click += (sender, e) =>
                    {
                        MessageBox.Show($"Zaznaczono: {checkBox.Content}");
                    };

                    // Ustaw pozycję CheckBox w siatce
                    Grid.SetColumn(checkBox, col);
                    Grid.SetRow(checkBox, row);

                    // Dodaj CheckBox do siatki
                    dynamicGrid.Children.Add(checkBox);
                }
            }
        }

    }

    /*
    for (int x = 0; x <= Symulator_gry_w_życie.dlugosc_boku_planszy; x++)
    {
        for (int y = 0; y <= Symulator_gry_w_życie.dlugosc_boku_planszy; y++)
        {
            var box = new CheckBox();
            plansza.Children.Add(box);
            Grid.SetColumn(box, (x+1)*5);
            Grid.SetRow(box, (y+1)*5);
        }
    }
    //internal Grid plansza = new();
    */
}




