using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserStoryApp
{
    public partial class Form1 : Form
    {
        static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            
        }

        private static async Task CreateUser()
        {
            var usersClient = new UserStoryStuff.UsersClient(client);
            usersClient.BaseUrl = "http://localhost:5000";
            UserStoryStuff.RegisterUserCommand command = new UserStoryStuff.RegisterUserCommand
            {
                FirstName = "Michael",
                LastName = "Rosario",
                Password = "gobulls123",
                UserName = "michael.p.rosario@gmail.com"
            };
            var response = await usersClient.RegisterUserAsync(command);
            if (response.Code == UserStoryStuff.ResponseCode.Success)
            {
                MessageBox.Show("User created");
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser();
        }
    }
}
