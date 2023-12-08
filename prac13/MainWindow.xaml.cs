﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] matrix;
        private ContextMenu inputDataContextMenu;
        private ContextMenu resultContextMenu;
        public MainWindow()
        {
            InitializeComponent();
            InitializeContextMenu();
        }
        private void InitializeContextMenu()
        {
            // Создаем контекстное меню для блока "Исходные данные"
            inputDataContextMenu = new ContextMenu();

            // Создаем пункт меню "Очистить"
            MenuItem clearMenuItem = new MenuItem();
            clearMenuItem.Header = "Очистить";
            clearMenuItem.Click += ClearInputs_Click;
            inputDataContextMenu.Items.Add(clearMenuItem);

            // Назначаем контекстное меню блоку "Исходные данные"
            GIntial.ContextMenu = inputDataContextMenu;

            // Создаем контекстное меню для блока "Результат"
            resultContextMenu = new ContextMenu();
            MenuItem clearRezItem = new MenuItem();
            clearRezItem.Header = "Очистить";
            clearRezItem.Click += ClearRezult_Click;
            // Назначаем контекстное меню блоку "Результат"
            GRezult.ContextMenu = resultContextMenu;
        }

        private void ClearInputs_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем значения текстовых полей блока "Исходные данные"
            tbRows.Text = "";
            tbColumn.Text = "";
            
        }
        private void ClearRezult_Click(object sender, RoutedEventArgs e)
        {
            DGarray.ItemsSource = null;
            tblStatus.Text = "";
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbRows.Text, out int rows) && int.TryParse(tbColumn.Text, out int columns))
            {
                if (rows > 0 && columns > 0)
                {
                    matrix = new int[rows, columns];

                    visulaarray.Fill2Array(matrix);

                    List<int> columnSums = new List<int>();

                    for (int col = 2; col <= columns; col += 2)
                    {
                        int sum = 0;

                        for (int row = 0; row < rows; row++)
                        {
                            sum += matrix[row, col - 1];
                        }

                        columnSums.Add(sum);
                    }
                    DGarray.ItemsSource = visulaarray.ToDataTable(matrix).DefaultView;
                    tbResult.Text = "Column sums for even columns:\n" + string.Join("\n", columnSums);
                }
                else
                {
                    MessageBox.Show("Rows and columns must be positive integers.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input for rows and columns.");
            }

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил лучший разработчик: Девяткин Вадим Евгеньевич\r\nПрактическая №1 \r\n\r\nДаны координаты двух противоположных вершин прямоугольника: (x1, y1), (x2, y2).\r\nСтороны прямоугольника параллельны осям координат. Найти периметр и площадь данного прямоугольника.\r\n\r\nДан размер файла в байтах. Используя операцию деления нацело, найти количество полных килобайтов, которые занимает данный файл (1 килобайт = 1024 байта)");
        }
    }
}
