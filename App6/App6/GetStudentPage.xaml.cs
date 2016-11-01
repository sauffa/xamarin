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
            InitializeComponent();
            DownloadStudentsAsync();
        }

        private async Task DownloadStudentsAsync()
        {
            var httpClient = new HttpClient();
            string json = await httpClient.GetStringAsync(url);

            var students = JsonConvert.DeserializeObject<List<Students>>(json);
            test.ItemsSource = students;
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
