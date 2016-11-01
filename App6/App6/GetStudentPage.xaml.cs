using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App6
{
    public partial class GetStudentPage : ContentPage
    {
        string url = "http://mystudents.azurewebsites.net/api/studentsApi";
        public GetStudentPage()
        {
            var didCrashInLastSession = HockeyApp.CrashManager.DidCrashInLastSession;

            InitializeComponent();
            DownloadStudentsAsync();
        }

        private async Task DownloadStudentsAsync()
        {
      
            var httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(url);

            var students = JsonConvert.DeserializeObject<List<Students>>(json);
            test.ItemsSource = students;

            HockeyApp.MetricsManager.TrackEvent(
                 "DownloadStudentsAsync()",
                 new Dictionary<string, string>
                 {
                        { "time", DateTime.UtcNow.ToString() }
                 },
                 new Dictionary<string, double>
                 {
                        { "value", 1.0 }
                 });
        }

        private async void clicked(object o, EventArgs e)
        {
            Students st = (Students)test.SelectedItem;
            await Navigation.PushModalAsync(new EditStudent(st));
            //await Navigation.PushModalAsync(new ProductDetailsPage(prod));
        }

        private async void addStudent(object o, EventArgs e)
        {
            Students st= new Students();
            await Navigation.PushModalAsync(new Student());

        }
    }
}
