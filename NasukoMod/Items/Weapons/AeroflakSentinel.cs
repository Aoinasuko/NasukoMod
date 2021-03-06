using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class AeroflakSentinel : ModItem
	{        
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeroflak Sentinel");
			Tooltip.SetDefault("Strong against enemies in the air.");
		}
	
		public override void SetDefaults()
		{
			item.damage = 32;
			item.ranged = true;
			item.width = 23;
			item.height = 30;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 5;
            item.mana = 10;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shootSpeed = 10f;
			item.value = Item.sellPrice(0, 5, 0, 0);
            item.shoot = mod.ProjectileType("AFBullet");
                        

		}

                public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
                {
                        if(player.velocity.Y > 2f || player.velocity.Y < -2f){
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
                        }
			return true;
		}

	}
}