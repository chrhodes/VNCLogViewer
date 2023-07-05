using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

using VNC.Core.Mvvm;

namespace VNCLogViewer.LoggingUIConfig
{
    public class LoggingLevel : INPCBase
    {
        private string _label;
        public string Label
        {
            get => _label;
            set
            {
                if (_label == value)
                {
                    return;
                }

                _label = value;
                OnPropertyChanged();
            }
        }
        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                if (_color == value)
                {
                    return;
                }

                _color = value;
                OnPropertyChanged();
            }
        }
        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked == value)
                {
                    return;
                }

                _isChecked = value;
                OnPropertyChanged();
            }
        }
        private string _toolTip;
        public string ToolTip
        {
            get => _toolTip;
            set
            {
                if (_toolTip == value)
                {
                    return;
                }

                _toolTip = value;
                OnPropertyChanged();
            }
        }

        private System.Windows.Visibility _visibility;
        public System.Windows.Visibility Visibility
        {
            get => _visibility;
            set
            {
                if (_visibility == value)
                {
                    return;
                }

                _visibility = value;
                OnPropertyChanged();
            }
        }

        #region INotifyPropertyChanged

        //public event PropertyChangedEventHandler PropertyChanged;

        //// This is the traditional approach - requires string name to be passed in

        ////private void OnPropertyChanged(string propertyName)
        ////{
        ////    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        ////}

        //// This is the new CompilerServices attribute!

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        #endregion
    }
}
