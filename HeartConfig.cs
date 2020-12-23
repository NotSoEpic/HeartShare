using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace HeartShare
{
    class HeartConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        [Label("Share Life Crystals")]
        public bool ShareLifeCrystals;

        [DefaultValue(true)]
        [Label("Share Life Fruit")]
        public bool ShareLifeFruit;

        // I don't know how to *replace* the life crystal/fruit effect for the player that uses it
        /*[DefaultValue(20)]
        [Range(1,350)]
        [Label("Life Crystal Effect")]
        [Tooltip("How much will life crystals increase your health\nHeavily reccommended to be a factor of 350")]
        public int CrystalEffect;

        [DefaultValue(5)]
        [Range(1, 400)]
        [Label("Life Crystal Effect")]
        [Tooltip("How much will life crystals increase your health\nHeavily reccommended to be a factor of 400")]
        public int FruitEffect;*/
    }
}
