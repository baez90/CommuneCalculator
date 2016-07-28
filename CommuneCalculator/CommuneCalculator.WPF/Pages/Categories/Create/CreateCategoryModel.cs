using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Categories.Overview;
using CommuneCalculator.Utils;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Categories.Create
{
    public class CreateCategoryModel : ViewModelBase
    {
        private readonly IDataRepo<Category> _categoriesRepo;
        private readonly INavigator _navigator;

        private CategoryModel _category = new CategoryModel { Entity = new Category() };
        private bool _isSaving;

        public CreateCategoryModel(INavigator navigator, IDataRepo<Category> categoriesRepo)
        {
            _navigator = navigator;
            _categoriesRepo = categoriesRepo;

            CancelCommand = new RelayCommand(() => _navigator.NavigateTo<CategoryOverview>());
            SaveCommand = new RelayCommand(async () => await SaveCategory());
        }

        #region private methods

        private async Task SaveCategory()
        {
            IsSaving = true;
            try
            {
                await _categoriesRepo.CreateEntityAsync(Category.Entity);
                _navigator.NavigateTo<CategoryOverview>();
                this.RaiseBroadcastPropertyChanged<CategoryOverviewModel, List<CategoryModel>>(model => model.Categories);
            }
            catch (Exception)
            {
                Application.Current.Dispatcher.Invoke(() => ModernDialog.ShowMessage("Failed to create new category", "Persistence error", MessageBoxButton.OK));
            }
            finally
            {
                IsSaving = false;

            }
        }

        #endregion

        #region properties

        public CategoryModel Category
        {
            get { return _category; }
            set
            {
                _category = value;
                RaisePropertyChanged();
            }
        }

        public bool IsSaving
        {
            get { return _isSaving; }
            set
            {
                _isSaving = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region commands

        public ICommand CancelCommand { get; }

        public ICommand SaveCommand { get; }

        #endregion
    }
}