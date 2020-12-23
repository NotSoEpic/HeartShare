using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using static HeartShare.HeartShare;

namespace HeartShare
{
    class HeartPlayer : ModPlayer
    {
        public int lastItemTime = 999;
        public void AddHealth(int delta, int min, int max) // receives variables from HeartShare.HandlePacket()
        {
            // Main.NewText(delta.ToString() + " " + min.ToString() + " " + max.ToString(), 150, 250, 150);
            if (player.statLifeMax >= min && player.statLifeMax < max)
            {
                player.statLifeMax += delta;
                player.statLifeMax2 += delta;
                player.statLife += delta;
                if (player.whoAmI == Main.myPlayer)
                {
                    player.HealEffect(delta, true);
                }
            }
            // Main.NewText(player.statLifeMax.ToString() + " " + player.statLifeMax2.ToString(), 255, 0, 255);
        }
    }
}
