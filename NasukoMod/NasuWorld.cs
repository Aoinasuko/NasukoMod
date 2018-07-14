using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using System.Collections.Generic;

using System;
using Terraria.ModLoader.IO;
using System.IO;

namespace NasukoMod
{
    public class NasuWorld : ModWorld
    {
        public static int biomeTiles = 0;

        public override void TileCountsAvailable(int[] tileCounts)
        {
            biomeTiles = tileCounts[mod.TileType("EggplantDirt")] + tileCounts[mod.TileType("EggplantGrass")];
        }

        public override void ResetNearbyTileEffects()
        {
        	NasuPlayer modPlayer = Main.LocalPlayer.GetModPlayer<NasuPlayer>(mod);
            biomeTiles = 0;
        }
    }
}
