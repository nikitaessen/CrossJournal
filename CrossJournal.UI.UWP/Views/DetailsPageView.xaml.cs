using CrossJournal.Core.ViewModels;
using MvvmCross.WindowsUWP.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CrossJournal.UI.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPageView : MvxWindowsPage
    {
        public event EventHandler<BackRequestedEventArgs> BackRequested;

        public DetailsPageView()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            BackRequested -= DetailsPageView_BackRequested;
            BackRequested += DetailsPageView_BackRequested;
        }

        private void DetailsPageView_BackRequested(object sender, BackRequestedEventArgs e)
        {

        }
    }
}
