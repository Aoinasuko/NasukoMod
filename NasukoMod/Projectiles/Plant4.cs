using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	public class Plant4 : ModProjectile
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plant4");
		}
	
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 200;
			projectile.magic = true;
                        projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 180;
			projectile.light = 0.5f;
		}

                 public override void AI()
		{
                        if (projectile.timeLeft == 180)
				{
                             
                                projectile.velocity.X = Main.rand.Next(-13,13);
			
                                if (projectile.velocity.X >= 0)
				{
                                      projectile.velocity.X = 13.0f;
                                }else{
                                      projectile.velocity.X = -13.0f; 
                                }
                                     
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