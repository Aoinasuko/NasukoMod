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
	public class EggPlantMeteor4 : ModProjectile
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
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 300;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 600f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 22f;
			projectile.width = 64;
			projectile.height = 64;
            projectile.light = 0.5f; 
            projectile.penetrate = -1;
			projectile.ignoreWater = true;
            projectile.timeLeft = 200;
            projectile.tileCollide = true;
            projectile.aiStyle = 99;
            projectile.friendly = true;
		}
		
	}
}