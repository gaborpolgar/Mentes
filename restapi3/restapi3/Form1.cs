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

        //String URL = "http://localhost/nodejsrestapi/";
        String URL = "http://127.0.0.1:3306/toys/";
        String ROUTE = "";

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
            foreach (Toy toy in response.Data)
            {
                listBox1.Items.Add(toy.Id + " " + toy.Name);
            }
            
            //var content = response.Content;
            //textBox1.Text = content;
        }

        private void getToyWithId(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = textBox2.Text;
            var request = new RestRequest(ROUTE, Method.GET);  //read by id
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            textBox2.Text = content;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.POST);  //Create
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Toy
            {
                id=int.Parse(textBox3.Text),
                employee_name = textBox4.Text,
                employee_age = int.Parse(textBox5.Text),
                employee_salary = int.Parse(textBox6.Text)
            });
            IRestResponse response = client.Execute(request);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            String ROUTE = textBox1.Text;
            var request = new RestRequest(ROUTE, Method.DELETE);  //Delete by id
            //request.AddParameter("id", int.Parse(textBox1.Text));
            IRestResponse response = client.Execute(request);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(ROUTE, Method.PUT);  //Create
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Toy
            {
                Id = int.Parse(textBox3.Text),
                Name = textBox4.Text,
                //employee_age = int.Parse(textBox5.Text),
                //employee_salary = int.Parse(textBox6.Text)
            });
            IRestResponse response = client.Execute(request);

            
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
