using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class ShadowArm3 : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadow Arm3");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.magic = true;
			projectile.penetrate = 1;
                        projectile.light = 0.5f; 
                        projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
                        projectile.timeLeft = 300;
		}

		public override void AI()
		{

                        if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
                        float distance = 2000f;
                        bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.timeLeft <= 260)
				{
                                        Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}

				}

			}
                        if (target && ((Main.rand.Next(5) == 0 && projectile.timeLeft <= 230) || (Main.rand.Next(4) == 0 && projectile.timeLeft <= 200) || (Main.rand.Next(3) == 0 && projectile.timeLeft <= 170) || (Main.rand.Next(2) == 0 && projectile.timeLeft <= 120)))
			{
                                AdjustMagnitude(ref move);	
                                  if (projectile.timeLeft <= 230 && projectile.timeLeft > 200)
			          {
                                  projectile.velocity = (10 * projectile.velocity + move) / 7f;
				  }
                                  if (projectile.timeLeft <= 200 && projectile.timeLeft > 170)
			          {
                                  projectile.velocity = (11 * projectile.velocity + move) / 5f;
				  }
                                  if (projectile.timeLeft <= 170 && projectile.timeLeft > 150)
			          {
                                  projectile.velocity = (12 * projectile.velocity + move) / 3f;
				  }
                                  if (projectile.timeLeft <= 150 && projectile.timeLeft > 120)
			          {
                                  projectile.velocity = (13 * projectile.velocity + move);
				  }
                                  if (projectile.timeLeft <= 120 && projectile.timeLeft > 30)
			          {
                                  projectile.velocity = (15 * projectile.velocity + move);
				  }
                                AdjustMagnitude(ref projectile.velocity);
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

		}

                private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}

		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(pos, 16, 16, mod.DustType("Smoke"), 0f, 0f, 0, Color.Blue);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
			}
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