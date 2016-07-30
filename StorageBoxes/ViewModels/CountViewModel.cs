using Caliburn.Micro;
using StorageBoxes.Interfaces;
using StorageBoxes.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBoxes.ViewModels
{
    class CountViewModel : Screen, ICount
    {
        private int _countSlider = 0;
        private string _countLabel;
        private int _maximum;
        private IEventAggregator _eventAggregator;

        public CountViewModel(IEventAggregator eventAggregator, int maxCount)
        {
            _eventAggregator = eventAggregator;
            CountSlider = 1;
            Maximum = maxCount;
        }

        public int CountSlider
        {
            get { return _countSlider; }
            set
            {
                _countSlider = value;
                CountLabel = _countSlider.ToString();
                NotifyOfPropertyChange(() => CountSlider);
                NotifyOfPropertyChange(() => CanCountConfirm);
            }
        }

        public string CountLabel
        {
            get { return _countLabel; }
            set
            {
                _countLabel = value;
                NotifyOfPropertyChange(() => CountLabel);
            }
        }

        public void CountConfirm()
        {
            _eventAggregator.PublishOnUIThread(new CountMessage(_countSlider));
            TryClose(true);
        }

        public bool CanCountConfirm
        {
            get { return (_countSlider != 0); }
        }

        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                NotifyOfPropertyChange(() => Maximum);
            }
        }

    }
}
