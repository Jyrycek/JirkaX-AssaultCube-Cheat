using InjectMemory;
using System.Data;
using System.Numerics;
using Structures;
using MemoryAccesor;

namespace MemoryInjection
{
    class Aimbot : Module
    {
        public override string Name => "Aimbot";
        private bool firstExecute = false;

        private Entity localPlayer = new Entity();
        private List<Entity> entities = new List<Entity>();

        public Aimbot(System.Windows.Forms.Label label) : base(label) { }
        public Aimbot(System.Windows.Forms.Label label, bool isSelected, bool isOnItem) : base(label, isSelected, isOnItem) { }
        public Aimbot(System.Windows.Forms.Label label, bool isOnItem) : base(label, isOnItem) { }

        public override void Execute()
        {
            if (!firstExecute)
            {
                Thread thread = new Thread(Aim) { IsBackground = true };
                thread.Start();

                firstExecute = true;
            }
        }

        private void Aim()
        {
            while (this.IsSelected)
            {
                localPlayer.ReadLocalPlayer(MemoryManager.processBaseAddress);

                localPlayer.readAngles();

                entities = Entity.ReadEntities(localPlayer).OrderBy(o => o.Mag).ToList();

                if (User32.GetAsyncKeyState(Keys.LButton) < 0)
                {
                    if (entities.Count > 0 && localPlayer.CurrentAmmo != 0)
                    {
                        foreach (var ent in entities)
                        {
                            if (ent.Team != localPlayer.Team)
                            {
                                var angles = CalcAngles(ent);

                                MemoryManager.WriteFloat(localPlayer.BaseAddress, Data.yawOffset, angles.X);
                                MemoryManager.WriteFloat(localPlayer.BaseAddress, Data.pitchOffset, angles.Y);

                                break;
                            }
                        }
                    }
                }
                Thread.Sleep(5);
            }
            firstExecute = false;
        }
        private Vector2 CalcAngles(Entity destEnt)
        {
            float x, y;

            var deltaX = destEnt.head.X - localPlayer.head.X;
            var deltaY = destEnt.head.Y - localPlayer.head.Y;
            float deltaZ = destEnt.head.Z - localPlayer.head.Z;

            x = (float)(Math.Atan2(deltaY, deltaX) * 180 / Math.PI) + 90;

            float dist = CalcDist(destEnt);

            y = (float)(Math.Atan2(deltaZ, dist) * 180 / Math.PI) - 1;

            return new Vector2(x, y);
        }
        private float CalcDist(Entity destEnt)
        {
            return (float)
                Math.Sqrt(Math.Pow(destEnt.feet.X - localPlayer.feet.X, 2)
                + Math.Pow(destEnt.feet.Y - localPlayer.feet.Y, 2));
        }
    }
}