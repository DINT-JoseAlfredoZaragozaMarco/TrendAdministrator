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
using System.Windows.Shapes;
using TrendAdministrator.VistasModelo;

namespace TrendAdministrator.Vistas
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private LoginWindowVM vm;
        public LoginWindow()
        {
            InitializeComponent();
            this.vm = new LoginWindowVM();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vm.ComprobarDatos())
            {
                DialogResult = true;
            }
        }
    }
}
