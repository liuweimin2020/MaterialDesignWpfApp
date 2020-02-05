//<!--网络来源 https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit-->
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;

namespace MaterialDesignTemplate
{
    public class ViewItem : INotifyPropertyChanged
    {
        private string _name;
        private object _content;
        private ScrollBarVisibility _horizontalScrollBarVisibilityRequirement;
        private ScrollBarVisibility _verticalScrollBarVisibilityRequirement;
        private Thickness _marginRequirement = new Thickness(16);

        //public ViewItem(string name, object content)
        //{
        //    _name = name;
        //    Content = content;
        //    //Documentation = documentation;
        //}


        public ViewItem(string name, object content, IEnumerable<DocumentationLink> documentation)
        {
            _name = name;
            Content = content;
            Documentation = documentation;
        }

        public string Name
        {
            get { return _name; }
            //set { _name = value; OnPropertyChanged(); }
            set { this.MutateVerbose(ref _name, value, RaisePropertyChanged()); }

        }

        public object Content
        {
            get { return _content; }
            //set { _content = value; OnPropertyChanged(); }
            set { this.MutateVerbose(ref _content, value, RaisePropertyChanged()); }
        }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
        {
            get { return _horizontalScrollBarVisibilityRequirement; }
            //set { _horizontalScrollBarVisibilityRequirement = value; OnPropertyChanged(); }
            set { this.MutateVerbose(ref _horizontalScrollBarVisibilityRequirement, value, RaisePropertyChanged()); }
        }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
        {
            get { return _verticalScrollBarVisibilityRequirement; }
            //set { _verticalScrollBarVisibilityRequirement = value; OnPropertyChanged(); }
            set { this.MutateVerbose(ref _verticalScrollBarVisibilityRequirement, value, RaisePropertyChanged()); }
        }

        public Thickness MarginRequirement
        {
            get { return _marginRequirement; }
            set { this.MutateVerbose(ref _marginRequirement, value, RaisePropertyChanged()); }
            //set { _marginRequirement = value;OnPropertyChanged(); }
        }

        public IEnumerable<DocumentationLink> Documentation { get; }

        //public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private  void MutateVerbose<TField>( ref TField field, TField newValue, Action<PropertyChangedEventArgs> raise, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TField>.Default.Equals(field, newValue)) return;
            field = newValue;
            raise?.Invoke(new PropertyChangedEventArgs(propertyName));
        }
    }

}
