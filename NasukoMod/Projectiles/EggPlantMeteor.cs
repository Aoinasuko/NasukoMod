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
	public class EggPlantMeteor : ModProjectile
	{
	
		private const float increment = 16f;
		private Vector2 target
		{
			get
			{
				return new Vector2(projectile.ai[0], projectile.ai[1]);
			}
		}
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Meteor");
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
            projectile.light = 0.5f; 
            projectile.penetrate = 1;
            projectile.hostile = true;
			projectile.ignoreWater = true;
            projectile.timeLeft = 200;
            projectile.tileCollide = false;
            projectile.aiStyle = 3;
            ProjectileID.Sets.Homing[projectile.type] = true;
		}

        public override void AI()
		{
			CreateDust(projectile.position);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				if (projectile.oldPos[k] == Vector2.Zero)
				{
					break;
				}
				CreateDust(projectile.oldPos[k]);
			}
			
			if (projectile.timeLeft == 180){
				projectile.aiStyle = 14;
				ProjectileID.Sets.Homing[projectile.type] = false;
				projectile.tileCollide = true;
			}
			
			if (projectile.timeLeft == 150 && projectile.velocity.X == 0 && projectile.velocity.Y == 0 && projectile.aiStyle == 14){
				projectile.aiStyle = 3;
				ProjectileID.Sets.Homing[projectile.type] = true;
				projectile.tileCollide = false;
			}
		}

		public void CreateDust(Vector2 pos)
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust = Dust.NewDust(pos, 16, 16, mod.DustType("Smoke"), 0f, 0f, 0, Color.Black);
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