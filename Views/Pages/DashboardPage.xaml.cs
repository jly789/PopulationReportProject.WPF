// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using UiDesktopAppMaster.ViewModels.Pages;
using Wpf.Ui.Controls;
using System.Windows.Media;

namespace UiDesktopAppMaster.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
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
                    this.loadingGrid.Visibility = Visibility.Collapsed;
                    this.dashboardGrid.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
