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
	public class EggPlantMeteor3 : ModProjectile
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
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 600;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 600f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 22f;
			projectile.width = 128;
			projectile.height = 128;
            projectile.light = 2.0f; 
            projectile.penetrate = -1;
			projectile.ignoreWater = true;
            projectile.timeLeft = 200;
            projectile.tileCollide = false;
            projectile.aiStyle = 99;
            projectile.friendly = true;
		}
		
		public override void PostAI()
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 16);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
		
	}
}