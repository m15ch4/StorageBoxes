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

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOptionService _optionService;
        private readonly IOptionValueService _optionValueService;
        private readonly IProductSKUService _productSKUService;
        private readonly ISKUValueService _skuValueService;

        public ShellViewModel(ICategoryService categoryService, IProductService productService, IOptionService optionService, IOptionValueService optionValueService, IProductSKUService productSKUService, ISKUValueService skuValueService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _optionService = optionService;
            _optionValueService = optionValueService;
            _productSKUService = productSKUService;
            _skuValueService = skuValueService;

            _products = _productService.GetAll();

            _productsController = new ProductsController();
            _productCategories = _categoryService.GetAll();
            _productSKUs = _productSKUService.GetAll();
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
                //ProductSKUs = _productsController.GetProductSKUs(_productsSelectedItem);
                //foreach (Option o in _productsSelectedItem.Options)
                //{
                //    foreach (OptionValue ov in o.OptionValues)
                //    {
                //        Trace.WriteLine(ov.ValueName);
                //    }
                //}
                //Trace.WriteLine(_productsSelectedItem.Options);

                NotifyOfPropertyChange(() => ProductsSelectedItem);
            }
        }


        public void OpenDialog()
        {
            // Prepare collection to store OptionValues for selected Product
            BindableCollection<OptionValue> selectedOptionValues = new BindableCollection<OptionValue>();

            // Set OptionValue selection window style
            dynamic mysettings = new ExpandoObject();
            mysettings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mysettings.ResizeMode = ResizeMode.NoResize;
            mysettings.WindowStyle = WindowStyle.None;
            mysettings.ShowInTaskbar = false;

            // Set optionvalue for each option of selected product (only if particular product is selected)
            if (_productsSelectedItem != null)
            {
                IWindowManager windowManager = new WindowManager();

                // For each option available to selected product
                foreach (Option o in _optionService.GetAllForProduct(_productsSelectedItem))
                {
                    // get available optionvalues
                    var availableOptionValues = _optionValueService.GetAllForOption(o);

                    //show dialog to select one optionvalue
                    windowManager.ShowDialog(new DialogViewModel(availableOptionValues, selectedOptionValues),null,mysettings);
                }

                var psv = _skuValueService.GetAllForProduct(_productsSelectedItem);
                var skuid = _skuValueService.FindSKUID(psv, selectedOptionValues);
                if (skuid > 0)
                {
                    ProductSKU productSKU = _productSKUService.GetByID(skuid);
                    Trace.WriteLine(productSKU.Sku);
                }


            }
        }
    }
}