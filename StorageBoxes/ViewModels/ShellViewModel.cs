using Caliburn.Micro;
using StorageBoxes.AppLogic;
using StorageBoxes.Contracts;
using StorageBoxes.Messages;
using StorageBoxes.Models;
using StorageBoxes.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Windows;
using System;
using System.Collections;
using StorageBoxes.Contracts.Tasks;

namespace StorageBoxes {
    public class ShellViewModel : PropertyChangedBase, IShell, IHandle<CountMessage>
    {
        private BindableCollection<Category> _productCategories;
        private BindableCollection<Product> _products;
        private BindableCollection<ProductSKU> _productSKUs;
        private BindableCollection<WishListItem> _wishList;

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOptionService _optionService;
        private readonly IOptionValueService _optionValueService;
        private readonly IProductSKUService _productSKUService;
        private readonly ISKUValueService _skuValueService;
        private readonly IBoxService _boxService;
        private readonly ITaskService _taskService;

        private IEventAggregator _eventAggregator;

        public ShellViewModel(IEventAggregator eventAggregator, ICategoryService categoryService, IProductService productService, IOptionService optionService, IOptionValueService optionValueService, IProductSKUService productSKUService, ISKUValueService skuValueService, IBoxService boxService, ITaskService taskService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _optionService = optionService;
            _optionValueService = optionValueService;
            _productSKUService = productSKUService;
            _skuValueService = skuValueService;
            _boxService = boxService;
            _taskService = taskService;

            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

            _products = _productService.GetAll();

            _productCategories = _categoryService.GetAll();
            _productSKUs = _productSKUService.GetAll();
            CategoriesSelectedItem = _productCategories[0];

            _wishList = new BindableCollection<WishListItem>();
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


        private int _itemCount;
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

                //----------------
                // Display window for each option available to selected product
                //----------------
                foreach (Option o in _optionService.GetAllForProduct(_productsSelectedItem))
                {
                    // get available optionvalues
                    var availableOptionValues = _optionValueService.GetAllForOption(o);

                    //show dialog to select one optionvalue
                    windowManager.ShowDialog(new OptionViewModel(o, availableOptionValues, selectedOptionValues),null,mysettings);
                }

                //wybieramy z tabeli SKUValue tylko elementy dotycz¹ce zaznaczonego przedmiotu
                var psv = _skuValueService.GetAllForProduct(_productsSelectedItem);

                // Wyszukaj ID (int) konkretnego SKU dla wybranego przedmiotu z wybranymi opcjami.
                var skuid = _skuValueService.FindSKUID(psv, selectedOptionValues);
                
                // jeœli jest taki skuid
                if (skuid > 0)
                {
                    // pobierz sku
                    ProductSKU productSKU = _productSKUService.GetByID(skuid);
                    // Product product = _productService.GetBySKU(productSKU);
                    Trace.WriteLine(productSKU.Sku + " " + productSKU.Product.ProductName);

                    var maxCount = _boxService.GetMaxCountBySKU(productSKU);

                    windowManager.ShowDialog(new CountViewModel(_eventAggregator, maxCount), null, mysettings);

                    _wishList.Add(new WishListItem(productSKU, _itemCount));
                }
            }
        }

        public BindableCollection<WishListItem> WishList
        {
            get { return _wishList; }
            set
            {
                _wishList = value;
                NotifyOfPropertyChange(() => WishList);
            }
        }

        public void Handle(CountMessage message)
        {
            _itemCount = message.Count;
        }

        public void Order()
        {
            Queue<double[]> orderQueue = new Queue<double[]>();
            foreach (WishListItem item in _wishList)
            {
                var selectedBoxes = _boxService.GetBySKU(item.ProductSKU, item.Count);
                foreach (Box box in selectedBoxes)
                {
                    _taskService.CreateSBTask(box);
                }
            }
        }

        public bool CanOrder
        {
            get { return true; }
        }
    }
}