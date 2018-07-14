using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Items.Weapons
{
	public class Bubburin : ModItem
	{        
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bubburin");
			Tooltip.SetDefault("To produce special foam. Right click to fire bullets from all bubbles.");
		}
	
		public override void SetDefaults()
		{
			item.damage = 44;
			item.ranged = true;
			item.width = 22;
			item.height = 30;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item19;
			item.autoReuse = true;
			item.shootSpeed = 10f;
            item.mana = 6;
			item.value = Item.sellPrice(0, 20, 0, 0);
            item.shoot = mod.ProjectileType("babrin");

		}

		public override bool AltFunctionUse(Player player)
       {
                return true;
       }

                public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
		{
				item.useStyle = 1;
				}
				else
				{
				item.useStyle = 5;
	}
	return base.CanUseItem(player);
	}

	}
}