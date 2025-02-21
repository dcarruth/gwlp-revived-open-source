using GameServer.ServerData.Items;

namespace GameServer.ServerData.DataInterfaces
{
        public interface IHasGeneralCharData
        {
                byte ProfessionPrimary { get; set; }
                byte ProfessionSecondary { get; set; }

                uint Level { get; set; }

                uint Morale { get; set; }

                sbyte IsPvp { get; set; }

                CharacterItems Items { get; set; }
        }
}