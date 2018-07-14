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
	public class EggPlant2 : ModProjectile
	{
	
		private const float increment = 10f;
		private Vector2 target
		{
			get
			{
				return new Vector2(projectile.ai[0], projectile.ai[1]);
			}
		}
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
            projectile.light = 0.7f;
            projectile.penetrate = 1;
            projectile.hostile = true;
			projectile.ignoreWater = true;
            projectile.timeLeft = 500;
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
			
			if (projectile.timeLeft == 360){
				projectile.aiStyle = 0;
				ProjectileID.Sets.Homing[projectile.type] = false;
			}
			
			if (projectile.timeLeft == 260 && Main.expertMode){
				projectile.aiStyle = 3;
				ProjectileID.Sets.Homing[projectile.type] = true;
			}
			
			if (projectile.timeLeft == 200 && Main.expertMode){
				projectile.aiStyle = 0;
				ProjectileID.Sets.Homing[projectile.type] = false;
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