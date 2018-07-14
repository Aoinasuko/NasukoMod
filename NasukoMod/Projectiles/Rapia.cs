using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class Rapia : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rapier");
		}

		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 30;
            projectile.light = 1.0f; 
            projectile.friendly = true;
            projectile.penetrate = -1;
			projectile.tileCollide = false; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.timeLeft = 20;
			projectile.aiStyle = 0;
		}

		 public override void AI()
		{
		
		Player player = Main.player[projectile.owner];
		
		projectile.position = player.position;
		
		if (player.velocity.X == 0){
		
		projectile.timeLeft = 0;
		
		}
		
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.player[projectile.owner].immuneTime = 60;
            Main.player[projectile.owner].immune = true;
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

	}
}