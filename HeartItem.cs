using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static HeartShare.HeartShare;
using static Terraria.ModLoader.ModContent;

namespace HeartShare
{
    class HeartItem : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            HeartConfig cfg = GetInstance<HeartConfig>();
            if (player.itemAnimation == player.itemAnimationMax - 1) // is it the first frame of animation? (don't want to simulate using 30 life crystals)
            {
                int delta = -1; // how much to change
                int min = -1; // minimum life to be able to add
                int max = -1; // maximum life to be able to add
                if (cfg.ShareLifeCrystals && item.type == ItemID.LifeCrystal && player.statLifeMax < 400) // is enabled, life crystal is being used, and it is consumed
                {
                    delta = 20;//cfg.CrystalEffect;
                    min = 0;
                    max = 400;
                }
                else if (cfg.ShareLifeFruit && item.type == ItemID.LifeFruit && player.statLifeMax >= 400 && player.statLifeMax < 500) // is enabled, life fruit is being used, and it is consumed
                {
                    delta = 5;// cfg.FruitEffect;
                    min = 400;
                    max = 500;
                }
                if (delta > 0) // did one of the 2 cases above fire
                {
                    var packet = mod.GetPacket();
                    packet.Write((byte)HeartModMessageTypes.LifeIncrease);
                    packet.Write(player.whoAmI); // whoAmI from HandlePacket always returned 255 for some reason
                    packet.Write((byte)delta);
                    packet.Write(min);
                    packet.Write(max);
                    packet.Send(); // sends packet over to HeartShare.HandlePacket()
                }
                /*if (item.type == ItemID.Wood) // debug stick for testing
                {
                    player.statLifeMax = 100;
                }*/
            }
            return base.UseItem(item, player);
        }
    }
}
