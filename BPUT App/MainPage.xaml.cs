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

namespace BPUT_App
{
    public partial class MainPage : PhoneApplicationPage
    {

        public ObservableCollection<Notice> notices;
        String jsondata, url;
        List<Notice> notice;
        

        public MainPage()
        {
           
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(mainpage_loaded);
            notices = new ObservableCollection<Notice>();

            /*
            var uri = new Uri("http://pauldmps.url.ph/json.php");
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.BeginGetResponse(new AsyncCallback(getJsonData),request); */
            
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
              Dispatcher.BeginInvoke(() => MessageBox.Show(exp.StackTrace));
          }
          finally
          {
              progressbar_main.Visibility = System.Windows.Visibility.Collapsed;
          }
          noticelist.ItemsSource = notices;
       }   
        /*
        public void getJsonData(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
             
                try
                   {
                     WebResponse response =  request.EndGetResponse(result);
                     jsondata = new StreamReader(response.GetResponseStream()).ReadToEnd();
                     Dispatcher.BeginInvoke(() => textblock1.Text = jsondata);
                }
                catch (Exception){
                }    
              }   */
       

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e){}

        private async Task downloadData(string url)
        {
            HttpClient client = new HttpClient();
            jsondata = await client.GetStringAsync(url);
         //   progressbar_main.Visibility = System.Windows.Visibility.Collapsed;
         }


            
        
        
        

        
        
          

    }
}