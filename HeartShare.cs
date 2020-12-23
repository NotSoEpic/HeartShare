using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HeartShare
{
	public class HeartShare : Mod
	{
        public override void HandlePacket(BinaryReader reader, int whoAmI) // receives packet sent from HeartItem.GlobalItem()
        {
            HeartModMessageTypes msgType = (HeartModMessageTypes)reader.ReadByte();
            switch(msgType) // yoinked from examplemod and im too scared to change it
            {
                case HeartModMessageTypes.LifeIncrease:
                    // just unloading all the data from the packet
                    int healer = reader.ReadInt32(); // whoAmI supplied by the function wasnt working properly
                    byte delta = reader.ReadByte();
                    int min = reader.ReadInt32(); // fun fact: I initially sent this as a byte... with a max value of 127
                    int max = reader.ReadInt32(); // this too
                    // Main.NewText(healer.ToString() + " " + Main.myPlayer.ToString(), 0, 255, 0); // debug text
                    if (Main.myPlayer != healer) // dont want to double the effects of the player using it
                    {
                        Main.player[Main.myPlayer].GetModPlayer<HeartPlayer>().AddHealth((int)delta, min, max); // sends variables over to HeartPlayer.AddHealth()
                    }
                    break;
            }
        }

        internal enum HeartModMessageTypes : byte
        {
            LifeIncrease
        }
    }
}