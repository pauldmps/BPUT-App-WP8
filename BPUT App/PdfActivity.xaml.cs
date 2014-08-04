using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;

namespace BPUT_App
{
    public partial class PdfActivity : PhoneApplicationPage
    {
        public PdfActivity()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(pdfactivity_loaded);
        
        }

        private void pdfactivity_loaded(object sender, RoutedEventArgs e)
        {
            Uri path = new Uri(@"ms-appx:///Assets/Pdfjs/index.html", UriKind.Absolute);
            webview.IsScriptEnabled = true;
            webview.Navigate(path);
        }

    }
}