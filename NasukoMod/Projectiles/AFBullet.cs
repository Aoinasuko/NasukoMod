using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class AFBullet : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AFBullet");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
                        projectile.light = 0.5f; 
                        projectile.friendly = true;
                        projectile.penetrate = 2;
			projectile.ignoreWater = true;
                        projectile.timeLeft = 400;
		}

                public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
			if (projectile.penetrate == 1 && projectile.ai[0] == 0)
			{
				projectile.penetrate = 1;
				projectile.maxPenetrate = 1;
				projectile.velocity = Vector2.Zero;
                                projectile.velocity.Y = 20;
                                projectile.friendly = false;
				projectile.hide = true;
                                projectile.tileCollide = true;
				projectile.timeLeft = 6;
                                projectile.ai[0] = 1;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
			}
			Vector2 move = Vector2.Zero;
                        float distance = 80f;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
                                        Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
                                                projectile.penetrate = 1;
					}

				}

			}
                        if (projectile.timeLeft == 1 && projectile.ai[0] == 1)
			{
			projectile.width = 148;
			projectile.height = 148;
                        projectile.penetrate = -1;
			projectile.maxPenetrate = -1;
                        projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.position.X -= 74;
			projectile.position.Y -= 174;
			projectile.velocity = Vector2.Zero;
                        projectile.hide = true;
			projectile.timeLeft = 2;
                        projectile.damage = projectile.damage * 5;
                        projectile.ai[0] = 2;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
			}
                        CreateDust(projectile.position);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				if (projectile.oldPos[k] == Vector2.Zero)
				{
					break;
				}
				CreateDust(projectile.oldPos[k]);
			}
		projectile.velocity.Y += 0.01f;

                }
                
		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(pos, 16, 16, mod.DustType("Smoke"), 0f, 0f, 0, Color.SkyBlue);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
			}
		}

		public override void Kill(int timeLeft)
		{

			if (projectile.ai[0] == 2)
			{
			for (int k = 0; k < 16; k++)
			{
				int dust = Dust.NewDust(projectile.position, 148, 148, mod.DustType("Smoke"), 0f, 0f, 0, Color.SkyBlue);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
			}
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

	}
}