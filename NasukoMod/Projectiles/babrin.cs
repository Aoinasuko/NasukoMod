using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class babrin : ModProjectile
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("babrin");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
            projectile.light = 0.5f; 
            projectile.penetrate = 1;
			projectile.ignoreWater = true;
            projectile.timeLeft = 60;
            projectile.friendly = true;
		}

                public override void AI()
		{
		
				int type = Main.player[projectile.owner].inventory[Main.player[projectile.owner].selectedItem].type;
				if (type != mod.ItemType("Bubburin") || Main.player[projectile.owner].altFunctionUse == 2) //add your Fishing Pole name here
                {
                		
                		projectile.timeLeft = 0;
                		
                }
		
                  int wait = 0;
                        if (projectile.timeLeft == 60)
				{
                             
                            projectile.velocity.X = Main.rand.Next(-4,4) * 2;
                            projectile.velocity.Y = Main.rand.Next(-4,4) * 2;
			                wait = 8;
				}
			if (projectile.timeLeft < 50)
				{
				Vector2 newMove = Main.player[projectile.owner].Center - projectile.Center;
                                AdjustMagnitude(ref newMove);	
                                projectile.velocity = (10 * projectile.velocity + newMove) / 11f;
                                AdjustMagnitude(ref projectile.velocity);
                    if ((projectile.velocity.X < 0.1 && projectile.velocity.X > -0.1) && (projectile.velocity.Y < 0.1 && projectile.velocity.Y > -0.1))
			        {
								projectile.velocity.X = Main.rand.Next(-4,4) * 3;
                                projectile.velocity.Y = Main.rand.Next(-4,4) * 3;
                                wait = 8;
			        }
                                }
                 wait -= 1;

		}
                
                public override bool OnTileCollide(Vector2 oldVelocity)
		{

				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X * 1.5f;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y * 1.5f;
				}
			return false;
		}

                private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 12f)
			{
				vector *= 12f / magnitude;
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
  

                public override void Kill(int timeLeft)
		{
			int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.player[projectile.owner].direction * 24, 0, mod.ProjectileType("babrin2"), projectile.damage, 6, Main.myPlayer, 0f, 0f);
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
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