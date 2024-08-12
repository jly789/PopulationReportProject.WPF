// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows.Media;
using UiDesktopAppMaster.Interfaces;
using UiDesktopAppMaster.Models;
using Wpf.Ui.Controls;

namespace UiDesktopAppMaster.ViewModels.Pages
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        #region FIELDS

        private bool isInitialized = false;

        private readonly IDatabase<GangnamguPopulation?>? database;

        #endregion

        #region PROPERTIES

        [ObservableProperty]
        private IEnumerable<GangnamguPopulation?>? gangnamguPopulations;

        [ObservableProperty]
        private IEnumerable<string?>? administrativeAgency;

        [ObservableProperty]
        private string? selectedAdministrativeAgency;

        [ObservableProperty]
        private int? selectedTotalPopulation;

        [ObservableProperty]
        private int? selectedMalePopulation;

        [ObservableProperty]
        private int? selectedFeMalePopulation;

        [ObservableProperty]
        private double? selectedSexRatio;

        [ObservableProperty]
        private int? selectedNumberOfHouseholds;

        [ObservableProperty]
        private double? selectedNumberOfPeoplePerHouseholds;

        [ObservableProperty]
        private int? selectedId;

        #endregion

        #region CONSTRUCTOR

        public DataViewModel(IDatabase<GangnamguPopulation?>? database)
        {
            this.database = database;
        }

        #endregion

        #region COMMANDS

        [RelayCommand]
        private void OnSelectAdministrativeAgency()
        {
            var selectedData = this.SelectedAdministrativeAgency;
        }

        [RelayCommand]
        private void UpdateData() 
        {
            var data = this.database?.GetDetail(this.SelectedId);

            data.AdministrativeAgency = this.SelectedAdministrativeAgency;
            data.TotalPopulation = this.SelectedTotalPopulation;
            data.MalePopulation = this.SelectedMalePopulation;
            data.FemalePopulation = this.SelectedFeMalePopulation;
            data.SexRatio = this.SelectedSexRatio;
            data.NumberOfHouseholds = this.SelectedNumberOfHouseholds;
            data.NumberOfPeoplePerHousehold = this.SelectedNumberOfPeoplePerHouseholds;

            this.database?.Update(data);
        }

        [RelayCommand]
        private void DeleteData() 
        {
            this.database?.Delete(this.SelectedId);
        }

        [RelayCommand]
        private void ReadDetailData() 
        {
            var data = this.database?.GetDetail(this.SelectedId);

            this.SelectedAdministrativeAgency = data.AdministrativeAgency;
            this.SelectedTotalPopulation = data.TotalPopulation;
            this.SelectedMalePopulation = data.MalePopulation;
            this.SelectedFeMalePopulation = data.FemalePopulation;
            this.SelectedSexRatio = data.SexRatio;
            this.SelectedNumberOfHouseholds = data.NumberOfHouseholds;
            this.SelectedNumberOfPeoplePerHouseholds = data.NumberOfPeoplePerHousehold;
        }

        [RelayCommand]
        private void CreateNewData()
        {
            GangnamguPopulation gangnamguPopulation = new GangnamguPopulation();

            gangnamguPopulation.AdministrativeAgency = this.SelectedAdministrativeAgency;
            gangnamguPopulation.TotalPopulation = this.SelectedTotalPopulation;
            gangnamguPopulation.MalePopulation = this.SelectedMalePopulation;
            gangnamguPopulation.FemalePopulation = this.SelectedFeMalePopulation;
            gangnamguPopulation.SexRatio = this.SelectedSexRatio;
            gangnamguPopulation.NumberOfHouseholds = this.SelectedNumberOfHouseholds;
            gangnamguPopulation.NumberOfPeoplePerHousehold = this.SelectedNumberOfPeoplePerHouseholds;

            this.database?.Create(gangnamguPopulation);
        }

        [RelayCommand]
        private void ReadAllData()
        {
            this.GangnamguPopulations = this.database?.Get();
        }

        #endregion

        #region METHOS

        public void OnNavigatedTo()
        {
            if (!isInitialized)
            {
                InitializeViewModelAsync();
            }
        }

        public void OnNavigatedFrom()
        {
            //
        }

        private async Task InitializeViewModelAsync()
        {
            // 비동기로 데이터를 가져오기
            this.GangnamguPopulations = await Task.Run(() => this.database?.Get());

            // 가져온 데이터를 가지고 필요한 작업 수행
            if (this.GangnamguPopulations != null)
            {
                this.AdministrativeAgency = this.GangnamguPopulations.Select(c => c.AdministrativeAgency).ToList();
            }

            isInitialized = true;
        }

        #endregion
    }
}
