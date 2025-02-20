﻿using SudoWorld.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudoWorld.View.Components
{
    /// <summary>
    /// Interaction logic for SudokuCellView.xaml
    /// </summary>
    public partial class SudokuCellView : UserControl
    {
        public SudokuCellView()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBlock && DataContext is SudokuCellViewModel vm)
            {
                vm.selectDeselect();
            }
        }
    }
}
