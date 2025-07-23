using InjectMemory;

namespace MemoryInjection
{
    internal class GraphicsManager
    {

        private const int WIDTH = 130;
        private const int CATEGORY_LABEL_HEIGHT = 25;

        private GameManager gameManager;
        private Form mainForm;

        private GameManager GameManager { get => gameManager; set => gameManager = value; }
        public Form MainForm { get => mainForm; set => mainForm = value; }

        public GraphicsManager(GameManager gamemanager, Form mainForm)
        {
            this.GameManager = gamemanager;
            this.MainForm = mainForm;

            mainForm.BackColor = Color.FromArgb(20, 20, 20);

            MenuCategoriesRenderer();
            SetWindowPosition();
        }


        public void RenderGraphics(PaintEventArgs e)
        {
            Label itemLabel;

            if (GameManager.IsInCategory)
            {
                itemLabel = Data.Categories.Find(item => item.IsOnCategory).Label;
            }
            else
            {
                itemLabel = Data.Categories[Data.Categories.
                                    FindIndex(category => category.IsOnCategory)].
                                    Items.Find(item => item.IsOnItem).Label;
            }

            Pen mypen = new Pen(Color.Black, 6);
            Graphics g = e.Graphics;

            g.DrawLine(mypen, 0, 0, WIDTH, 0);

            mypen = new Pen(Color.Black, 3);
            g.DrawLine(mypen, 0, CATEGORY_LABEL_HEIGHT, WIDTH, CATEGORY_LABEL_HEIGHT);

            mypen = new Pen(Color.White, 2);

            int a = itemLabel.Location.Y - 1;
            int b = itemLabel.Height + 3;

            //x-ové čáry vrch
            g.DrawLine(mypen, 0, a, 6, a);
            g.DrawLine(mypen, WIDTH - 6, a, WIDTH, a);

            //y-ové čáry vrch
            g.DrawLine(mypen, 0 + 1, a, 0 + 1, a + 6);
            g.DrawLine(mypen, WIDTH - 1, a, WIDTH - 1, a + 6);


            //y-ové čáry spodek
            g.DrawLine(mypen, 0 + 1, a + b - 6, 0 + 1, a + b);
            g.DrawLine(mypen, WIDTH - 1, a + b - 6, WIDTH - 1, a + b);

            //x-ové čáry spodek
            g.DrawLine(mypen, 0, a + b, 6, a + b);
            g.DrawLine(mypen, WIDTH - 6, a + b, WIDTH, a + b);
        }

        //Nastasvuje veliksot a pozici menu
        public void SetWindowPosition()
        {
            User32.RECT outrect;
            User32.GetWindowRect(User32.handle, out outrect);

            MainForm.Size = new Size(WIDTH, 200);

            MainForm.Top = outrect.top + 200;
            MainForm.Left = outrect.left + 20;

            MainForm.FormBorderStyle = FormBorderStyle.None;

            int initialStyle = User32.GetWindowLong(mainForm.Handle, -20);
            User32.SetWindowLong(mainForm.Handle, -20, initialStyle | 0x80000 | 0x20);
        }

        public void SetHidenOrShown()
        {
            if (GameManager.IsOpenedMenu)
            {
                mainForm.Invoke(new Action(() => mainForm.Hide()));
                GameManager.IsOpenedMenu = false;
            }
            else
            {
                mainForm.Invoke(new Action(() => mainForm.Show()));
                GameManager.IsOpenedMenu = true;
            }
        }

        //Vyrenderuje kategorie (labels atd.) v hlavní části menu
        public void MenuCategoriesRenderer()
        {
            int label = 0;
            foreach (var category in Data.Categories)
            {
                category.Label.Text = category.Name;
                category.Label.Location = new Point((WIDTH - category.Label.Size.Width) / 2, category.Label.Location.Y);
                label++;

            }
            LabelClear(label);
        }
        //Vymaže text pro nevyužité labely
        private void LabelClear(int labelNumber)
        {
            for (int i = labelNumber; i < 6; i++)
            {
                Data.Labels[i].Text = "";
            }
        }

        public void openCategory(List<Module> items)
        {
            GameManager.IsInCategory = false;
            int index = 0;

            foreach (Module item in items)
            {
                MainForm.Invoke(new Action(() =>
                {
                    items[index].Label.Text = items[index].Name;
                    items[index].Label.Location = new Point((WIDTH - items[index].Label.Size.Width) / 2, items[index].Label.Location.Y);
                    index++;
                }));
            }
            LabelClear(index);

            SetWindowPosition();
        }

        public void ItemColorRenderer()
        {
            if (GameManager.IsInCategory)
                return;

            List<Module> items = Data.Categories[Data.Categories.FindIndex(it => it.IsSelected)].Items;

            foreach (Module item in items)
            {
                item.SetColor();
            }
        }

        public void OnFocusLost()
        {
            if (!GameManager.IsFocused)
            {
                mainForm.Invoke(new Action(() => mainForm.Hide()));

            }
            GameManager.IsFocused = false;
        }
        public void OnFocusGained()
        {
            GameManager.IsFocused = true;

            if (GameManager.IsOpenedMenu)
            {
                mainForm.Invoke(new Action(() => mainForm.Show()));
            }
        }
    }
}
