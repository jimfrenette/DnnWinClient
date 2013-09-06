using System;
using System.Windows.Forms;
using RestSharp;

namespace DnnWinClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var domain = txtSite.Text;
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            var route = txtRoute.Text;

            var apiUrl = string.Format("{0}/{1}", domain, route);

            IRestRequest request = new RestRequest();
            request.AddHeader("Content-type", "application/json; charset=utf-8");
            var client = new RestClient
            {
                BaseUrl = apiUrl,
                Authenticator = new HttpBasicAuthenticator(username, password),
            };
            IRestResponse response = client.Execute(request);

            txtResponse.Text = response.Content;
        }
    }
}
