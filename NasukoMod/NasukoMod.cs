using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework;
using System.Linq;

namespace NasukoMod
{
	public class NasukoMod : Mod
	{
	
		public static int EggPlantCrystalID;

		public NasukoMod()
		{
		Properties = new ModProperties()
		{
			Autoload = true,
			AutoloadGores = true,
			AutoloadSounds = true,
			AutoloadBackgrounds = true
		};
		}
		
		public override void Load()
		{
		EggPlantCrystalID = CustomCurrencyManager.RegisterCurrency(new EggPlantCrystalData(ItemType<Items.EggPlantCrystal>(), 999L));
		}

		public override void UpdateMusic(ref int music)
		{
		
			if (Main.myPlayer != -1 && !Main.gameMenu && Main.LocalPlayer.active)
			{
			
				if(Main.LocalPlayer.GetModPlayer<NasuPlayer>().ZonenasuBiome)
				{
				
					music = GetSoundSlot(SoundType.Music, "Sounds/Music/EggPlantForest");
				
				}
				
			}
		
		}

		
	}

}

