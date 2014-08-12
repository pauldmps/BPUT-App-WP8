using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BPUT_App.Resources;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Diagnostics;

namespace BPUT_App
{
    public partial class MainPage : PhoneApplicationPage
    {

        public ObservableCollection<Notice> notices;
        String jsondata, url;
        

        public MainPage()
        {
           
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(mainpage_loaded);
            notices = new ObservableCollection<Notice>();            
        }


       private async void mainpage_loaded(object sender, RoutedEventArgs e)
       {
          url = "http://pauldmps.url.ph/json.php";
          await downloadData(url);

          try
          {
              var rootObject = JsonConvert.DeserializeObject<RootObject>(jsondata);
              if (notices.Count != 0)
              {
                  notices.Clear();
              }
              foreach (Notice notice in rootObject.notice)
              {
                  Notice notice1 = notice;
                  notices.Add(notice1);
              }
          }
          catch (Exception exp)
          {
              Debug.WriteLine(exp.StackTrace);
          }
          finally
          {
              progressbar_main.Visibility = System.Windows.Visibility.Collapsed;
              noticelist.ItemsSource = notices;
          }
       }   
       
        private async Task downloadData(string url)
        {
            HttpClient client = new HttpClient();
            jsondata = await client.GetStringAsync(url);
         }

        private void noticelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (noticelist.SelectedItem.Equals(-1))
            { return; }

            NavigationService.Navigate(new Uri("/NoticeActivity.xaml", UriKind.Relative));

            //noticelist.SelectedItem = -1;
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainpage_loaded(this,new RoutedEventArgs());
        }
        
        

        
        
          

    }
}