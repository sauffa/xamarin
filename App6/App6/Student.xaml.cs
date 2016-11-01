using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App6
{
    public partial class Student : ContentPage
    {
        string url = "http://mystudents.azurewebsites.net/api/studentsApi";

        public Student()
        {
            InitializeComponent();
            
        }

        private async void SaveStudent(object o, EventArgs e)
        {

            var httpClient = new HttpClient();

            var stud = new Students
            {
                Department = department.Text,
                fullname = fullname.Text


            };

            string json = JsonConvert.SerializeObject(stud);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var reponse = await httpClient.PostAsync(url, httpContent);
            await Navigation.PushModalAsync(new GetStudentPage());

        }

    }
}
