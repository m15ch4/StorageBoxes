using Caliburn.Micro;
using StorageBoxes.AppLogic;
using StorageBoxes.Models;
using System.Diagnostics;

namespace StorageBoxes {
    public class ShellViewModel : PropertyChangedBase, IShell {
        private ProductsController _productsController;
        private BindableCollection<Category> _productCategories;
        private BindableCollection<Product> _products;
        public ShellViewModel()
        {
            _productsController = new ProductsController();
            _productCategories = _productsController.GetCategories();
            _products = _productsController.GetProducts();
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
                Products = _productsController.GetProducts(_categoriesSelectedItem);
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
                NotifyOfPropertyChange(() => ProductsSelectedItem);
            }
        }
    }
}