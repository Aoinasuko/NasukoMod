using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class FairySpear2 : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Spear");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 200;
			projectile.magic = true;
            projectile.light = 0.5f; 
            projectile.penetrate = 5;
            projectile.hide = false;
			projectile.ignoreWater = true;
			projectile.hostile = true;
            projectile.timeLeft = 800;
		}

        public override void AI()
		{
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			
			CreateDust(projectile.position);
                        
		}
                
		public void CreateDust(Vector2 pos)
		{
				int dust = Dust.NewDust(pos, 16, 200, mod.DustType("Smoke"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, Color.Red);
				Main.dust[dust].scale = 1f;
				Main.dust[dust].velocity *= 0.3f;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				if (projectile.oldPos[k] == Vector2.Zero)
				{
					return;
				}
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + projectile.Size / 2f;
				Color color = Lighting.GetColor((int)(projectile.oldPos[k].X / 16f), (int)(projectile.oldPos[k].Y / 16f));
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, 0f, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
			}
		}

	}
}