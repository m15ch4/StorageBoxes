using Caliburn.Micro;
using StorageBoxes.Interfaces;
using StorageBoxes.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.ViewModels
{
    class DialogViewModel : Screen, IDialog
    {
        private BindableCollection<OptionValue> _optionValues;
        private BindableCollection<OptionValue> _selectedOptionValues;
        public DialogViewModel(BindableCollection<OptionValue> optionValues, BindableCollection<OptionValue> selectedOptionValues)
        {
            _optionValues = optionValues;
            _selectedOptionValues = selectedOptionValues;
        }

        public BindableCollection<OptionValue> OptionValues
        {
            get { return _optionValues; }
            set
            {
                _optionValues = value;
                NotifyOfPropertyChange(() => OptionValues);
            }
        }


        private OptionValue _optionValuesSelectedItem;
        public OptionValue OptionValuesSelectedItem
        {
            get { return _optionValuesSelectedItem; }
            set
            {
                _optionValuesSelectedItem = value;
                Trace.WriteLine("v");
                NotifyOfPropertyChange(() => OptionValuesSelectedItem);
                NotifyOfPropertyChange(() => CanConfirm);
            }
        }

        public void Confirm()
        {
            _selectedOptionValues.Add(_optionValuesSelectedItem);
            TryClose(true);
        }

        public bool CanConfirm
        {
            get { return _optionValuesSelectedItem != null; }
        }
    }
}
