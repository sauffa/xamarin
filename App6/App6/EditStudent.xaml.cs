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
    public partial class EditStudent : ContentPage
    {
        string url = "http://mystudents.azurewebsites.net/api/studentsApi/";
        public Students _st = new Students();
        public EditStudent(Students st)
        {
            InitializeComponent();
            ID.Text = st.Id.ToString();
            fullname.Text = st.fullname;
            department.Text = st.Department;
            _st = st;
        }

        private async void Edit(object o, EventArgs e)
        {

            var httpClient = new HttpClient();

            var stud = new Students
            {//gygygygg
                Id =  Convert.ToInt32(ID.Text),
                Department = department.Text,
                fullname = fullname.Text


            };

            string json = JsonConvert.SerializeObject(stud);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var reponse = await httpClient.PutAsync(url+stud.Id, httpContent);
            await Navigation.PushModalAsync(new GetStudentPage());

        }
        private async void Delete(object o, EventArgs e)
        {
            var httpClient = new HttpClient();


            var reponse = await httpClient.DeleteAsync(url + _st.Id);
            await Navigation.PushModalAsync(new GetStudentPage());
        }
    }
}
