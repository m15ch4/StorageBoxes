using Caliburn.Micro;
using StorageBoxes.AppLogic;
using StorageBoxes.Contracts;
using StorageBoxes.Models;
using StorageBoxes.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Windows;

namespace StorageBoxes {
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private ProductsController _productsController;
        private BindableCollection<Category> _productCategories;
        private BindableCollection<Product> _products;
        private BindableCollection<ProductSKU> _productSKUs;

        private readonly IProductService _productService;
        private readonly IOptionService _optionService;

        public ShellViewModel(IProductService productService, IOptionService optionService)
        {
            _productService = productService;
            _optionService = optionService;

            _products = _productService.GetAll();

            _productsController = new ProductsController();
            _productCategories = _productsController.GetCategories();
            _productSKUs = _productsController.GetProductSKUs();
            CategoriesSelectedItem = _productCategories[0];
        }

        //===================================================
        // Categories items
        //===================================================
        public BindableCollection<Category> Categories
        {
            get { return _productCategories; }
            set
            {
                _productCategories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        //===================================================
        // Category selection (changed)
        //===================================================
        private Category _categoriesSelectedItem;
        public Category CategoriesSelectedItem
        {
            get { return _categoriesSelectedItem; }
            set
            {
                _categoriesSelectedItem = value;
                //Trace.WriteLine(_categoriesSelectedItem.ToString());
                Products = _productService.GetAllByCategory(_categoriesSelectedItem);
                NotifyOfPropertyChange(() => CategoriesSelectedItem);
            }
        }

        //===================================================
        // Product list
        //===================================================
        public BindableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        //===================================================
        // Category selection (changed)
        //===================================================
        private Product _productsSelectedItem;
        public Product ProductsSelectedItem
        {
            get { return _productsSelectedItem; }
            set
            {
                _productsSelectedItem = value;
                //Trace.WriteLine(_productsSelectedItem.ToString());
                ProductSKUs = _productsController.GetProductSKUs(_productsSelectedItem);

                //foreach (Option o in _productsSelectedItem.Options)
                //{
                //    foreach (OptionValue ov in o.OptionValues)
                //    {
                //        Trace.WriteLine(ov.ValueName);
                //    }
                //}
                Trace.WriteLine(_productsSelectedItem.Options);

                NotifyOfPropertyChange(() => ProductsSelectedItem);
            }
        }

        //===================================================
        // SKU List
        //===================================================
        public BindableCollection<ProductSKU> ProductSKUs
        {
            get { return _productSKUs; }
            set
            {
                _productSKUs = value;
                NotifyOfPropertyChange(() => ProductSKUs);
            }
        }

        public void OpenDialog()
        {
            BindableCollection<OptionValue> selectedOptionValues = new BindableCollection<OptionValue>();
            dynamic mysettings = new ExpandoObject();
            mysettings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mysettings.ResizeMode = ResizeMode.NoResize;
            mysettings.WindowStyle = WindowStyle.None;
            mysettings.ShowInTaskbar = false;

            if (_productsSelectedItem != null)
            {
                IWindowManager wm = new WindowManager();
                foreach (Option o in _optionService.GetAllByProduct(_productsSelectedItem))
                {
                    var availableOptionValues = _productsController.GetOptionValues(o);
                    wm.ShowDialog(new DialogViewModel(availableOptionValues, selectedOptionValues),null,mysettings);
                }
                foreach (var i in selectedOptionValues)
                {
                    Trace.WriteLine(i.ValueName);
                }
            }
        }
    }
}