using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MainProgram
{
    public class WebInterfaceListener
    {
        private HttpListener listener;
        private PanelController panelController;
        private bool isMenuInitialized = false;
        private bool isListInitialized = false;

        public WebInterfaceListener()
        {
            //InitializeUserName();

            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/command/");

            panelController = new PanelController();
        }

        public async void InitializeUserName()
        {
            await SendUsernameAsync(LoginForm.UserName!);
        }
        public static async Task SendUsernameAsync(string username)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(username);
                var response = await client.PostAsync("http://localhost:8000/set_username", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Nastala chyba při odesílání uživatelského jména.", "Chyba");
                }
            }
        }
        public async Task StartAsync()
        {
            listener.Start();

            while (true)
            {
                var context = await listener.GetContextAsync();
                var request = context.Request;
                var response = context.Response;

                if (request.HttpMethod == "POST")
                {
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        var command = await reader.ReadToEndAsync();

                        string outputString = "OK";
                        if (command == "option-menu-activate")
                        {
                            if (!isMenuInitialized)
                            {
                                outputString = "OK-MENU";
                                panelController.MenuInitialize();
                                isMenuInitialized = true;
                            }
                        }
                        if (command == "option-list-activate")
                        {
                            if (!isListInitialized)
                            {
                                outputString = "OK-LIST";
                                panelController.PlayerListInitialize();
                                isListInitialized = true;
                            }
                        }
                        
                        var buffer = Encoding.UTF8.GetBytes(outputString);
                        response.ContentLength64 = buffer.Length;
                        await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                    }
                }

                response.Close();
            }
        }
        public async Task SendDataAsync(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync("http://localhost:5000/api/data", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
