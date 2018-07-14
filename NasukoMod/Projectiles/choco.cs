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
	public class choco : ModProjectile
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chocorate");
		}
	
		private const float increment = 8f;
		private Vector2 target
		{
			get
			{
				return new Vector2(projectile.ai[0], projectile.ai[1]);
			}
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
            projectile.light = 0.5f; 
            projectile.penetrate = 1;
            projectile.hostile = true;
			projectile.ignoreWater = true;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.aiStyle = 1;
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