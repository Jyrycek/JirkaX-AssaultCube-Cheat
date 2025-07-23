using System.Diagnostics;

namespace MainProgram
{
    public class WebInterface
    {
        private ProcessStartInfo start;
        private WebInterfaceListener webInterfaceListener;

        public WebInterface(string path) 
        {
            start = new ProcessStartInfo();
            //C:\\Users\\jgeng\\AppData\\Local\\Programs\\Python\\Python312\\python.exe
            start.FileName = "C:\\Users\\jirka\\AppData\\Local\\Programs\\Python\\Python312\\python.exe";
            start.Arguments = path;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;


            if (!pythonExecution()) return;
            
            //openBrowser("http://127.0.0.1:8000");

            //webInterfaceListener = new WebInterfaceListener();

            _ = startAsync();
        }
        private async Task startAsync()
        {
            await webInterfaceListener.StartAsync();
        }
        private bool pythonExecution()
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = start;
                    process.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
            return true;
        }
        private void openBrowser(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
