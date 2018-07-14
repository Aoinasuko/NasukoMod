using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class Ringbomb : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ring Bomb");
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
            projectile.light = 0.5f; 
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.penetrate = -1;
		}

        public override void AI()
		{
			if (Main.rand.Next(3) == 0 && projectile.timeLeft < 60)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}

			if (projectile.timeLeft == 119)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 4);
			}

            if (projectile.timeLeft == 5)
			{
			projectile.width = 296;
			projectile.height = 296;
			projectile.position.X -= 148;
			projectile.position.Y -= 172;
            projectile.hide = true;
            projectile.hostile = true;
            projectile.damage = projectile.damage;
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			for (int k = 0; k < 32; k++){
				int dust = Dust.NewDust(projectile.position, 296, 296, mod.DustType("Smoke"), 0f, 0f, 0, Color.Blue);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
			}
			
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
                
		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(6) == 0)
			{
				int dust = Dust.NewDust(pos, 16, 16, mod.DustType("Smoke"), 0f, 0f, 0, Color.SkyBlue);
				Main.dust[dust].scale = 2f;
				Main.dust[dust].velocity *= 0.5f;
			}
		}

	}
}