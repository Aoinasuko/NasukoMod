using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class Pixie6 : ModProjectile
	{

                private Vector2 target
		{
			get
			{
				return new Vector2(projectile.ai[0], projectile.ai[1]);
			}
		}
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie6");
		}

		public override void SetDefaults()
		{
			projectile.width = 42;
			projectile.height = 30;
			projectile.ranged = true;
                        projectile.light = 2.0f; 
                        projectile.friendly = true;
                        projectile.penetrate = 1;
                        projectile.tileCollide = false;
			projectile.ignoreWater = true;
                        projectile.timeLeft = 600;
                        projectile.aiStyle = 3;
		}
                
		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(pos, 16, 16, mod.DustType("Smoke"), 0f, 0f, 0, Color.Green);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
			}
		}
  

                public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 3; k++)
			{
			int shoot = mod.ProjectileType("Pixie5");
			int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X * -1 * Main.rand.Next(2), projectile.velocity.Y * -1 * Main.rand.Next(2), shoot, projectile.damage, 6, Main.myPlayer, 0f, 0f);
			}

			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
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
                public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if (Main.rand.Next(3) == 0)
			{
				player.AddBuff((int)mod.BuffType("EtherealFlames"), 20, true);
			}
		}

	}
}