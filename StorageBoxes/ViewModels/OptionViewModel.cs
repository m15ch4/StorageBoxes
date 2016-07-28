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
    class OptionViewModel : Screen, IOption
    {
        // OptionValues ComboBox items
        private BindableCollection<OptionValue> _optionValues;
        // Reference to choosen optionvalues
        private BindableCollection<OptionValue> _selectedOptionValues;
        public OptionViewModel(Option option, BindableCollection<OptionValue> optionValues, BindableCollection<OptionValue> selectedOptionValues)
        {
            _optionLabel = option.OptionName.ToString();

            // ComboBox Items Initialization
            _optionValues = optionValues;

            // Container for choosen option_values for each option
            _selectedOptionValues = selectedOptionValues;
        }

        //====================================
        // ComboBox items setter / getter
        //====================================
        public BindableCollection<OptionValue> OptionValues
        {
            get { return _optionValues; }
            set
            {
                _optionValues = value;
                NotifyOfPropertyChange(() => OptionValues);
            }
        }

        //====================================
        // SelectedItem setter / getter
        //====================================
        private OptionValue _optionValuesSelectedItem;
        public OptionValue OptionValuesSelectedItem
        {
            get { return _optionValuesSelectedItem; }
            set
            {
                _optionValuesSelectedItem = value;
                NotifyOfPropertyChange(() => OptionValuesSelectedItem);
                NotifyOfPropertyChange(() => CanConfirm);
            }
        }

        private string _optionLabel;
        public string OptionLabel
        {
            get { return _optionLabel; }
            set
            {
                _optionLabel = value;
                NotifyOfPropertyChange(() => OptionLabel);
            }
        }
        //====================================
        // On Confirm button pressed callback
        //====================================
        public void Confirm()
        {
            _selectedOptionValues.Add(_optionValuesSelectedItem);
            TryClose(true);
        }

        //====================================
        // Confirm button enable / disable
        //====================================
        public bool CanConfirm
        {
            get { return _optionValuesSelectedItem != null; }
        }
    }
}
