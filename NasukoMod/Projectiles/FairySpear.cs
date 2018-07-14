using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class FairySpear : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Spear");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.magic = true;
            projectile.light = 0.5f; 
            projectile.penetrate = 5;
            projectile.hide = true;
			projectile.ignoreWater = true;
            projectile.timeLeft = 800;
            projectile.hostile = false;
            Main.projFrames[projectile.type] = 3;
		}

        public override void AI()
		{
                        if(projectile.penetrate != -1){
                        projectile.velocity.Y = projectile.velocity.Y + 0.06f;
                        CreateDust(projectile.position);
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
            projectile.width = 32;
			projectile.height = 626;
                        projectile.penetrate = -1;
			projectile.maxPenetrate = -1;
			projectile.position.Y -= 184;
            projectile.tileCollide = false;
			projectile.velocity = Vector2.Zero;
            projectile.hide = false;
			projectile.timeLeft = 60;
			projectile.hostile = true;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 25);
			int shoot = mod.ProjectileType("EggPlant2");
			int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 50, 2, -6, shoot, 20, 6, Main.myPlayer, 0f, 0f);
				proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 50, -2, -6, shoot, 20, 6, Main.myPlayer, 0f, 0f);
				proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 50, 0, -6, shoot, 20, 6, Main.myPlayer, 0f, 0f);
			
			return false;
		}
                
		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(pos, 8, 8, mod.DustType("Smoke"), 0f, 0f, 0, Color.Red);
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