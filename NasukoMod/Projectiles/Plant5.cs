using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	public class Plant5 : ModProjectile
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plant5");
		}
	
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.magic = true;
                        projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.light = 0.5f;
		}

                public override void AI()
		{
                        if (projectile.timeLeft == 120)
				{
                             
                                        projectile.velocity.X = Main.rand.Next(-9,9);
				
                                        projectile.velocity.Y = Main.rand.Next(-9,9);
			
                                       
				}
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}

                public override void OnHitPlayer(Player player, int damage, bool crit)
		{
				player.AddBuff((int)mod.BuffType("EtherealFlames"), 240, true);
		}

	}
}