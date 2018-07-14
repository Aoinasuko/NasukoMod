using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Items.Weapons
{
	public class CaveMachinegun : ModItem
	{        
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cave Machinegun");
			Tooltip.SetDefault("Vertical upward reaction is strong." + "\n'Many shoot!'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 8;
			item.ranged = true;
			item.width = 23;
			item.height = 30;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = -1;
			item.value = 10000;
			item.rare = 6;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.UseSound = SoundID.Item11;
			item.value = Item.sellPrice(1, 0, 0, 0);
			item.useAmmo = AmmoID.Bullet;
            item.shoot = 10; //idk why but all the guns in the vanilla source have this
            item.value = Item.sellPrice(0, 5, 0, 0);

		}

                public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
                {
			player.velocity.Y += (-speedY / 5f);
                if(player.velocity.Y > 9f){
			player.velocity.Y = 9f;
                }
		if(player.velocity.Y < -9f){
			player.velocity.Y = -9f;
                }
			return true;
		}

	}
}