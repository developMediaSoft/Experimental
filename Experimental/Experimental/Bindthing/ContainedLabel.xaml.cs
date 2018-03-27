using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace Experimental.Bindthing {
    public class Model : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string three = "Three";
        public string Three {
            get {
                return three;
            } set {
                three = value;
                NotifyPropertyChanged("Three");
            }
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContainedLabel : ContentView {
        private Model model = new Model();
        public static readonly BindableProperty TwoProperty = BindableProperty.Create(nameof(Two), typeof(string), typeof(ContainedLabel), "Two", propertyChanged:(bindable, oldValue, newValue)=> { ((ContainedLabel)bindable).model.Three = (string)newValue; });
        public string Two { get { return (string)GetValue(TwoProperty); } set { SetValue(TwoProperty, value); } }

        public ContainedLabel() {
            InitializeComponent();
            label.BindingContext = model;
        }
    }
}