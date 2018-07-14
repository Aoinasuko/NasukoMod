using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class Zoneofsafe : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zone of Safe");
		}

		public override void SetDefaults()
		{
			projectile.width = 128;
			projectile.height = 128;
			projectile.magic = true;
            projectile.light = 0.5f; 
            projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.damage = 0;
            projectile.timeLeft = 900;
            Main.projFrames[projectile.type] = 3;
		}

        public override void AI()
		{
            if(projectile.frame != 2){
                        projectile.frame = (projectile.frame + 1) % 3;
            }
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}

			float distance = 60f;
			for (int k = 0; k < 100; k++)
			{
                    Vector2 newMove = Main.player[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{

						Main.player[k].manaRegenCount = 5;
						Main.player[k].manaRegen = 0;
						Main.player[k].immune = true;
						Main.player[k].immuneTime = 60;

					}
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