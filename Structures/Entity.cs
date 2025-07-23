using System.Numerics;
using MemoryAccesor;

namespace Structures
{
    public class Entity
    {
        public IntPtr BaseAddress { get; private set; }
        public Vector3 feet, head;
        private Vector2 viewAngles;
        public float Mag { get; private set; }
        public int Health { get; private set; }
        public int Team { get; private set; }
        public int Dead { get; private set; }
        public int CurrentAmmo { get; private set; }
        public string Name { get; private set; } = "";
        
        public static int PlayersNumber { get => playersNumber; set => playersNumber = value; }
        private static int playersNumber = 0;

        private static int
            playerNumberOffset = 0x18AC0C,
            entityListOffset = 0x0018AC04;

        private readonly int
            ammoOffset = 0x138,
            healthOffset = 0xEC,
            teamOffset = 0x30C,
            headPosOffset = 0x04,
            footPosOffset = 0x28,
            nickNameOffset = 0x205;

        public void ReadEntity()
        {
            CurrentAmmo = MemoryManager.ReadInt(BaseAddress, ammoOffset);
            head = MemoryManager.ReadVector3(BaseAddress, headPosOffset);
            feet = MemoryManager.ReadVector3(BaseAddress, footPosOffset);
            Health = MemoryManager.ReadInt(BaseAddress, healthOffset);
            Name = MemoryManager.ReadString(BaseAddress, nickNameOffset);
            Team = MemoryManager.ReadInt(BaseAddress, teamOffset);
        }
        public Entity() { }
        public Entity(IntPtr currentEntBase)
        {
            BaseAddress = currentEntBase;

            ReadEntity();
        }

        public IntPtr ReadLocalPlayer(IntPtr processBaseAddress)
        {
            BaseAddress = MemoryManager.ReadPointer(processBaseAddress, 0x0017E0A8);

            ReadEntity();

            return BaseAddress;
        }
        public Entity readAngles()
        {
            ReadEntity();

            viewAngles.X = MemoryManager.ReadFloat(BaseAddress, 0x34);
            viewAngles.Y = MemoryManager.ReadFloat(BaseAddress, 0x34 + 0x4);

            return this;
        }

        public static List<Entity> ReadEntities(Entity localPlayer)
        {
            List<Entity> entities = new List<Entity>();
            IntPtr entityList = MemoryManager.ReadPointer(MemoryManager.processBaseAddress, entityListOffset);

            PlayersNumber = MemoryManager.ReadInt(MemoryManager.processBaseAddress, playerNumberOffset);

            for (int i = 0; i < PlayersNumber; i++)
            {
                IntPtr currentEntBase = MemoryManager.ReadPointer(entityList, i * 0x4);

                Entity currentPlayer = new Entity(currentEntBase);

                currentPlayer.Mag = CalcMag(currentPlayer, localPlayer);

                if (currentPlayer.Health > 0 && currentPlayer.Health < 101)
                {
                    entities.Add(currentPlayer);
                }
            }

            return entities;
        }
        private static float CalcMag(Entity destEntity, Entity localPlayer)
        {
            return (float)
                Math.Sqrt(Math.Pow(destEntity.feet.X - localPlayer.feet.X, 2)
                + Math.Pow(destEntity.feet.Y - localPlayer.feet.Y, 2)
                + Math.Pow(destEntity.feet.Z - localPlayer.feet.Z, 2));
        }
    }
}