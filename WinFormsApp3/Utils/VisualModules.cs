using System.Numerics;
using ezOverLay;
using InjectMemory;
using MainProgram;
using MemoryInjection;
using Structures;

namespace WinFormsApp3
{
    public class VisualModules
    {
        private CoverForm coverForm;

        private ez ez = new ez();

        Entity localPlayer = new Entity();
        List<Entity> entities = new List<Entity>();

        readonly Pen red = new Pen(Color.Red, 3);
        readonly Pen green = new Pen(Color.Green, 3);

        public VisualModules(CoverForm form)
        {
            this.coverForm = form;

            ez.SetInvi(form);
            ez.DoStuff(Data.WINDOW_NAME, form);
        }

        public void visualEngine(Graphics g)
        {
            entities = Entity.ReadEntities(localPlayer);

            foreach (var ent in entities.ToList())
            {
                localPlayer.readAngles();
                entities = Entity.ReadEntities(localPlayer);

                var wtsFeet = WorldToScreen(Matrix.ReadMatrix(), ent.feet, coverForm.Width, coverForm.Height);
                var wtsHead = WorldToScreen(Matrix.ReadMatrix(), ent.head, coverForm.Width, coverForm.Height);

                if (wtsFeet.X <= 0) return;

                Font customFont = new Font(new FontFamily("Verdana"), 9, FontStyle.Regular);
                Rectangle esp_rectangle = CalcRect(wtsFeet, wtsHead);

                int nametagX = esp_rectangle.Left + (esp_rectangle.Width - (int)g.MeasureString(ent.Name.ToString(), customFont).Width) / 2;
                int nametagX_health = esp_rectangle.Left + (esp_rectangle.Width - (int)g.MeasureString(ent.Health.ToString(), customFont).Width) / 2;


                Point nametagPosition = new Point(nametagX + 6, esp_rectangle.Y - 20);
                Point healthPosition = new Point(nametagX_health + 6, esp_rectangle.Y - 36);

                if (Nametags.IsEnabled)
                {
                    g.DrawString(ent.Name, new Font("Arial", 8, FontStyle.Regular), Brushes.AliceBlue, nametagPosition);
                    g.DrawString(ent.Health.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.GreenYellow, healthPosition);
                }

                if (localPlayer.Team == ent.Team)
                {
                    if (Esp.IsEnabled)
                        g.DrawRectangle(green, esp_rectangle);

                    if (WireFrame.IsEnabled)
                        g.DrawLine(green, new Point(coverForm.Width / 2, coverForm.Height), wtsFeet);
                }
                else
                {
                    if (Esp.IsEnabled)
                        g.DrawRectangle(red, esp_rectangle);

                    if (WireFrame.IsEnabled)
                        g.DrawLine(red, new Point(coverForm.Width / 2, coverForm.Height), wtsFeet);
                }
            }
        }

        private static Point WorldToScreen(Matrix mtx, Vector3 pos, int width, int height)
        {
            var twoD = new Point();

            //pozor - mozná bude potřeba kontrolovat, zda je screenW > 0.0001, ale screenW nabývá uplne jinych hodnot (-180 až 180), coz nedava smysl
            float screenW = (mtx.M14 * pos.X) + (mtx.M24 * pos.Y) + (mtx.M34 * pos.Z) + mtx.M44;

            if (screenW != 0)
            {
                float screenX = (mtx.M11 * pos.X) + (mtx.M21 * pos.Y) + (mtx.M31 * pos.Z) + mtx.M41;
                float screenY = (mtx.M12 * pos.X) + (mtx.M22 * pos.Y) + (mtx.M32 * pos.Z) + mtx.M42;

                float camX = width / 2f;
                float camY = height / 2f;

                float X = camX + (camX * screenX / screenW);
                float Y = camY - (camY * screenY / screenW);

                twoD.X = (int)X;
                twoD.Y = (int)Y;
            }
            else
            {
                twoD = new Point(-99, 99);
            }
            return twoD;
        }

        public static Rectangle CalcRect(Point feet, Point head)
        {
            var rect = new Rectangle();
            rect.X = head.X - (feet.Y - head.Y) / 4;
            rect.Y = head.Y;

            rect.Width = (feet.Y - head.Y) / 2;
            rect.Height = feet.Y - head.Y;

            return rect;
        }
    }
}
