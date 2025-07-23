using InjectMemory;
using ConfigManagerSpace;
using ConfigurationLibrary;
using MainProgram;
using Org.BouncyCastle.Ocsp;

namespace MemoryInjection
{
    internal class MenuManager
    {
        private GameManager gamemanager;
        private GraphicsManager graphicsManager;

        public MenuManager(GraphicsManager graphicsManager, GameManager gamemanager)
        {
            this.graphicsManager = graphicsManager;
            this.gamemanager = gamemanager;
        }

        public void OnKeyChange(Keys key)
        {
            if (!GameManager.IsFocused) { return; }

            if (key == Keys.F9)
                graphicsManager.SetHidenOrShown();
            else if (!gamemanager.IsOpenedMenu)
                return;

            bool isInCategory = gamemanager.IsInCategory;

            switch (key)
            {
                case Keys.NumPad8:
                    (isInCategory ? new Action(MoveUp) : new Action(MoveUpSubMenu))();
                    break;
                case Keys.NumPad5:
                    (isInCategory ? new Action(OnCategoryPressedKey) : new Action(MoveIntoSubCategory))();
                    break;
                case Keys.NumPad6:
                    if (isInCategory)
                        OnCategoryPressedKey();
                    break;
                case Keys.NumPad4:
                    if (!isInCategory)
                        BackToCategory();
                    break;
                case Keys.NumPad2:
                    (gamemanager.IsInCategory ? new Action(MoveDown) : new Action(MoveDownSubMenu))();
                    break;
                case Keys.Delete:
                    AplicationExit();
                    break;
            }
        }
        //Uložení konfigurace
        private void AplicationExit()
        {
            AppConfig config = Data.ReadData();

            if (Data.SaveBoxes[0].Checked)
            {
                ConfigManager.JsonConfigWrite(config);
            }
            else
            {
                ConfigManager.DatabaseConfigWrite(config, LoginForm.UserName);
            }
            Environment.Exit(0);
        }

        private void OnCategoryPressedKey()
        {
            int index = Data.Categories.FindIndex(category => category.IsOnCategory);
            Data.Categories[index].IsSelected = true;
            graphicsManager.openCategory(Data.Categories[index].Items);

            graphicsManager.ItemColorRenderer();
        }

        private void MoveIntoSubCategory()
        {
            int catIndex = Data.Categories.FindIndex(item => item.IsOnCategory);
            List<Module> items = Data.Categories[catIndex].Items;
            items[items.FindIndex(item => item.IsOnItem)].SetIsSelected();

            graphicsManager.ItemColorRenderer();
        }

        private void MoveDown()
        {
            int index = Data.Categories.FindIndex(item => item.IsOnCategory);

            Data.Categories[index++].IsOnCategory = false;

            if (index < 0)
            {
                index = Data.Categories.Count - 1;
            }
            else if (index > Data.Categories.Count - 1)
            {
                index = 0;
            }

            Data.Categories[index].IsOnCategory = true;

            graphicsManager.SetWindowPosition();
        }
        private void MoveDownSubMenu()
        {

            List<Module> items = Data.Categories[Data.Categories.FindIndex(cat => cat.IsOnCategory)].Items;
            int index = items.FindIndex(item => item.IsOnItem);

            items[index++].IsOnItem = false;

            if (index < 0)
            {
                index = items.Count - 1;
            }
            else if (index > items.Count - 1)
            {
                index = 0;
            }

            items[index].IsOnItem = true;

            graphicsManager.SetWindowPosition();
        }

        private void BackToCategory()
        {
            gamemanager.IsInCategory = true;

            foreach (var cat in Data.Labels)
            {
                cat.ForeColor = Color.Red;
            }

            int index = Data.Categories.FindIndex(category => category.IsOnCategory);
            Data.Categories[index].IsSelected = false;

            graphicsManager.MenuCategoriesRenderer();
            graphicsManager.SetWindowPosition();
        }

        private void MoveUp()
        {
            int index = Data.Categories.FindIndex(item => item.IsOnCategory);


            Data.Categories[index--].IsOnCategory = false;

            if (index < 0)
            {
                index = Data.Categories.Count - 1;
            }
            else if (index > Data.Categories.Count - 1)
            {
                index = 0;
            }

            Data.Categories[index].IsOnCategory = true;

            graphicsManager.SetWindowPosition();
        }

        private void MoveUpSubMenu()
        {
            List<Module> items = Data.Categories[Data.Categories.FindIndex(cat => cat.IsOnCategory)].Items;
            int index = items.FindIndex(item => item.IsOnItem);


            items[index--].IsOnItem = false;

            if (index < 0)
            {
                index = items.Count - 1;
            }
            else if (index > items.Count - 1)
            {
                index = 0;
            }

            items[index].IsOnItem = true;

            graphicsManager.SetWindowPosition();
        }
    }
}