﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Experimental.Bindthing {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage {
        public ListViewPage() {
            InitializeComponent();
            MyListView.BindingContext = new {
                One = "One"
            };
        }
    }
}
