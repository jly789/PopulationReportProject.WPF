// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using UiDesktopAppMaster.Models;
using UiDesktopAppMaster.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace UiDesktopAppMaster.Views.Pages
{
    public partial class DataPage : INavigableView<DataViewModel>
    {
        public DataViewModel ViewModel { get; }

        public DataPage(DataViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            InitializeComponent();
        }

        private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AdministrativeAgency":
                    this.searchGridLoadingControl.Visibility = Visibility.Collapsed;
                    this.searchGrid.Visibility = Visibility.Visible;
                    break;

                case "GangnamguPopulations":
                    this.dgGridLoadingControl.Visibility = Visibility.Collapsed;
                    this.dgGrid.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void cbxAdminAgency_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
