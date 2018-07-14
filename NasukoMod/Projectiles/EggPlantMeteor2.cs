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
	public class EggPlantMeteor2 : ModProjectile
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
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.aiStyle = 14;
		}

        public override void AI()
		{
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				if (projectile.oldPos[k] == Vector2.Zero)
				{
					break;
				}
			}
			
		}

	}
}