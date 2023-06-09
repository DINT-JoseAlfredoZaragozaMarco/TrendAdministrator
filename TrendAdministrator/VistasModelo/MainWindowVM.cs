﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TrendAdministrator.Mensajes;
using TrendAdministrator.Modelos;
using TrendAdministrator.Servicios;

namespace TrendAdministrator.VistasModelo
{
    class MainWindowVM : ObservableObject
    {
        private ServicioNavegacion servicioNavegacion;
        private UserControl contenidoVentana;

        public UserControl ContenidoVentana
        {
            get { return contenidoVentana; }
            set { SetProperty(ref contenidoVentana, value); }
        }

        private Employees empleadoActual;

        public Employees EmpleadoActual
        {
            get { return empleadoActual; }
            set { SetProperty(ref empleadoActual, value); }
        }


        public RelayCommand GestionarPedidosCommand { get; }
        public RelayCommand CargarEstadisticaCommand { get; }
        public RelayCommand CargarGestionEmpleadosCommand { get; }
        public RelayCommand GestionProductosCommand { get; }
        public RelayCommand GestionProveedoresCommand { get; }
        public RelayCommand AbrirManualDeUsuarioCommand { get; }
        public RelayCommand CambiarSesionCommand { get; }

        public MainWindowVM()
        {
            servicioNavegacion = new ServicioNavegacion();

            WeakReferenceMessenger.Default.Register<EmpleadoLoggeadoMessage>(this, (r, m) =>
            {
                EmpleadoActual = m.Value;
            });

            if ((bool)this.servicioNavegacion.CargarLogin())
            {
                CambiarSesionCommand = new RelayCommand(CambiarSesion);
                GestionarPedidosCommand = new RelayCommand(CargarGestionarPedidos);
                CargarEstadisticaCommand = new RelayCommand(CargarEstadistica);
                CargarGestionEmpleadosCommand = new RelayCommand(CargarGestionEmpleados);
                GestionProductosCommand = new RelayCommand(CargarGestionProductos);
                GestionProveedoresCommand = new RelayCommand(CargarGestionProveedores);
                AbrirManualDeUsuarioCommand = new RelayCommand(AbrirManualDeUsuario);
            }
        }

        public void CargarGestionarPedidos()
        {
            ContenidoVentana = servicioNavegacion.CargarListaPedidos();
            WeakReferenceMessenger.Default.Send(new EmpleadoLoggeadoMessage(EmpleadoActual));
        }
        public void CargarEstadistica()
        {
            ContenidoVentana = servicioNavegacion.CargarEstadisticas();
        }

        public void CargarGestionEmpleados()
        {
            ContenidoVentana = servicioNavegacion.CargarGestionEmpleados();
        }

        public void CargarGestionProductos()
        {
            ContenidoVentana = servicioNavegacion.CargarGestionProductos();
        }

        public void CargarGestionProveedores()
        {
            ContenidoVentana = servicioNavegacion.CargarGestionarProveedores();
        }

        public void AbrirManualDeUsuario()
        {
            Process.Start("http://trend.eastus.cloudapp.azure.com:8080/ManualDeUsuario/");
        }
        public void CambiarSesion()
        {
            MessageBoxResult result = MessageBox.Show("¿Estás seguro de cambiar de usuario?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool? resultado = this.servicioNavegacion.CargarLogin();
            }
        }
    }
}
