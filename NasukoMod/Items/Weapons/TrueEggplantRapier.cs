using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class TrueEggplantRapier : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Eggplant Rapier");
			Tooltip.SetDefault("'Beautiful like all nature.'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 280;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 3;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 11;
			item.mana = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.value = Item.sellPrice(10, 0, 0, 0);
			item.shoot = mod.ProjectileType("Rapia");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			
			int dust = 0;
		
			if (Main.rand.Next(3) == 0)
			{
				dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
			
			dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			
		}
		
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
                {
            if(player.immuneTime < 40){
            player.immune = true;
            player.immuneTime = 40;
            }
            player.immune = true;
			player.velocity.X += player.velocity.X*10;
                if(player.velocity.X > 15f){
			player.velocity.X = 15f;
                }
			if(player.velocity.X < -15f){
			player.velocity.X = -15f;
                }
			return true;
				}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            player.immuneTime = 100;
            player.immune = true;
        }

	}
}