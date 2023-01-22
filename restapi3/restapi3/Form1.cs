using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restapi3
{
    public partial class Form1 : Form
    {

      
        String URL = "http://127.0.0.1:3000/toys/";
        String ROUTE = "";
        String x_access_token = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void getToys_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = "";
            var request = new RestRequest(ROUTE, Method.GET);
            request.RequestFormat = DataFormat.Json;

            //RestResponse?
            IRestResponse<List<Toy>> response = client.Execute<List<Toy>>(request);
            Console.WriteLine(response.Content);
            foreach (Toy toy in response.Data)
            {
                listBox1.Items.Add(toy.Id + " " + toy.Name);
            }
            
        }

        private void getToyWithId(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = bekertIdTextBox.Text;
            var request = new RestRequest(ROUTE, Method.GET);  //read by id
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            bekertIdTextBox.Text = content;
           
        }

        private void toyAddClick(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.POST);  //Create
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Authorization", x_access_token);
            //request.AddBody(x_access_token);
            request.AddBody(new Toy
            {
                Name = textBox4.Text,
    
            });
            IRestResponse response = client.Execute(request);

        }

        private void deleteByIdClick(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = textBox1.Text;
            var request = new RestRequest(ROUTE, Method.DELETE);  //Delete by id
            IRestResponse response = client.Execute(request);
            
        }

        private void updateToyClick(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = bekertIdTextBox.Text;
            var request = new RestRequest(ROUTE, Method.PUT);  //Update
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Toy
            {
                Id = bekertIdTextBox.Text,
                Name = textBox4.Text
            });
            IRestResponse response = client.Execute(request);
   
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bejelentkezesClick(object sender, EventArgs e)
        {
            String URL = "http://127.0.0.1:3000/";
            String ROUTE = "login";
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.POST);  //felhasználó bejelentkezése
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Felhasznalo
            {
                Felhasznalonev = felhasznalonevTextBox.Text,
                Jelszo = jelszoTextBox.Text,
            });
            Console.WriteLine(felhasznalonevTextBox.Text);
            Console.WriteLine(jelszoTextBox.Text);
            IRestResponse response = client.Execute(request);
            listBox1.Items.Add(response.Content);
            //accessToken = response.Content;
            //Console.WriteLine(accessToken);
        }
    }

    public class Toy
    {
        public String Id { get; set; }
        public String Name { get; set; }

    }

    public class Felhasznalo
    {
        public String Felhasznalonev { get; set; }
        public String Jelszo { get; set; }

    }

}
