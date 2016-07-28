using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using CommuneCalculator.DB.DataAccess;
using CommuneCalculator.DB.Entities;
using CommuneCalculator.EntityViewModels;
using CommuneCalculator.Navigation;
using CommuneCalculator.Pages.Categories.Create;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace CommuneCalculator.Pages.Categories.Overview
{
    public class CategoryOverviewModel : ViewModelBase
    {
        public static readonly string CategoriesUpdate = nameof(CategoriesUpdate);
        private readonly IDataRepo<Category> _categoriesRepo;

        private readonly INavigator _navigator;

        public CategoryOverviewModel(INavigator navigator, IDataRepo<Category> categoriesRepo)
        {
            _navigator = navigator;
            _categoriesRepo = categoriesRepo;

            CreateCategoryCommand = new RelayCommand(() => _navigator.NavigateTo<CreateCategory>());
        }

        #region properties

        public List<CategoryModel> Categories => _categoriesRepo.All().Select(category => new CategoryModel {Entity = category}).ToList();

        #endregion

        #region commands

        public ICommand CreateCategoryCommand { get; }

        #endregion
    }
}