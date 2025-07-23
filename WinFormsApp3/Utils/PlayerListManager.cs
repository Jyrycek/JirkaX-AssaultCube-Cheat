using InjectMemory;
using MemoryInjection;
using Structures;
using MemoryAccesor;

namespace WinFormsApp3
{
    internal class PlayerListManager
    {
        private int maxNumber;
        private List<Entity> entities = new List<Entity>();
        private Entity localPlayer;
        private PlayersList playerList;

        public PlayerListManager(PlayersList form)
        {
            maxNumber = Data.LabelsNames.Count;
            playerList = form;

            localPlayer = new Entity();
            localPlayer.ReadLocalPlayer(MemoryManager.processBaseAddress);
        }
        public void refreshForm()
        {
            dataUpdate();

            if (Entity.PlayersNumber <= 0)
                return;

            initializeLocalPlayer();
            int i;
            int labelI = 1;
            for (i = 0; i <= maxNumber - 2 && i < realLiveEntities(); i++, labelI++)
            {

                int health = entities[i].Health;
                Color setColor;
                if (health > 70)
                {
                    setColor = Color.Green;
                }
                else if (health > 30)
                {
                    setColor = Color.Orange;
                }
                else
                {
                    setColor = Color.Red;
                }

                Data.LabelsHealth[labelI].ForeColor = setColor;
                Data.LabelsHealth[labelI].Text = entities[i].Health.ToString();
                Data.LabelsHealth[labelI].Left = 102;

                if (entities[i].Team != localPlayer.Team)
                {
                    Data.LabelsNames[labelI].ForeColor = Color.Red;
                }
                else
                {
                    Data.LabelsNames[labelI].ForeColor = Color.Green;
                }

                Data.LabelsNames[labelI].Text = entities[i].Name;
                Data.LabelsNames[labelI].Left = 5;

            }

            for (; labelI < maxNumber; labelI++)
            {
                Data.LabelsNames[labelI].Text = string.Empty;
                Data.LabelsHealth[labelI].Text = string.Empty;
            }
        }

        private int realLiveEntities()
        {
            int realNumber = 0;
            foreach (var entity in entities)
            {
                if (entity.Health > 0 && entity.Health < 101)
                {
                    realNumber += 1;
                }
            }
            return realNumber;
        }

        private void initializeLocalPlayer()
        {
            Data.LabelsHealth[0].Text = localPlayer.Health.ToString();
            Data.LabelsHealth[0].Left = 102;

            Data.LabelsNames[0].Text = localPlayer.Name;
            Data.LabelsNames[0].Left = 5;
        }

        private void dataUpdate()
        {
            localPlayer.readAngles();
            entities = Entity.ReadEntities(localPlayer);
        }

        public void OnFocusLost()
        {
            playerList.Invoke(new Action(() => playerList.Hide()));
        }
        public void OnFocusGained()
        {
            playerList.Invoke(new Action(() => playerList.Show()));
        }
    }
}
