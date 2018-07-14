using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class UndyneSpear : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undyne Spear");
		}

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.magic = true;
                        projectile.light = 0.5f; 
                        projectile.friendly = true;
                        projectile.penetrate = 5;
                        projectile.hide = true;
			projectile.ignoreWater = true;
                        projectile.timeLeft = 800;
                        Main.projFrames[projectile.type] = 3;
		}

        public override void AI()
		{
                        if(projectile.penetrate != -1){
                        projectile.velocity.Y = projectile.velocity.Y + 0.06f;
                        }
                        if(projectile.penetrate == -1 && projectile.frame != 2){
                        projectile.frame = (projectile.frame + 1) % 3;
                        }
			if (Main.rand.Next(5) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
                        
		}
                
                public override bool OnTileCollide(Vector2 oldVelocity)
		{
                        projectile.width = 16;
			projectile.height = 106;
                        projectile.penetrate = -1;
			projectile.maxPenetrate = -1;
			projectile.position.Y -= 92;
                        projectile.tileCollide = false;
			projectile.velocity = Vector2.Zero;
                        projectile.hide = false;
			projectile.timeLeft = 60;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
			return false;
		}
                
		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(pos, 8, 8, mod.DustType("Smoke"), 0f, 0f, 0, Color.Blue);
				Main.dust[dust].scale = 1f;
				Main.dust[dust].velocity *= 0.3f;
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