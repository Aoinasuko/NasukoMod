using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod
{
	public class NasuPlayer : ModPlayer
	{           public bool fairyMinion = false;
                public bool regMinion = false;
                public bool nasuMinion = false;
                public bool draMinion = false;
                public bool Neutralization = false;
                
                public bool ZonenasuBiome = false;

		public override void ResetEffects()
		{
						fairyMinion = false;
                        regMinion = false;
                        nasuMinion = false;
                        draMinion = false;
                        Neutralization = false;
		}
		
		 public override void UpdateBiomes()
        {
            ZonenasuBiome = (NasuWorld.biomeTiles > 30); // Chance 50 to the minimum number of tiles that need to be counted before it is classed as a biome
        }

        public override bool CustomBiomesMatch(Player other)
        {
            NasuPlayer otherPlayer = other.GetModPlayer<NasuPlayer>(mod); // This will get other players using the TutorialPlayerClass
            return ZonenasuBiome == otherPlayer.ZonenasuBiome; // This will return true or false depending on other player
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            NasuPlayer otherPlayer = other.GetModPlayer<NasuPlayer>(mod);
            otherPlayer.ZonenasuBiome = ZonenasuBiome; // This will set other player's biome to the same as thisPlayer
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZonenasuBiome;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZonenasuBiome = flags[0];
        }

        public override void UpdateBiomeVisuals()
        {
            
        }

        public override Texture2D GetMapBackgroundImage()
		{
			if (ZonenasuBiome)
			{
				return mod.GetTexture("Nasubiomestyle");
			}
			return null;
		}

	}
}
