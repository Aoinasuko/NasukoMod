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
	public class babrin2 : ModProjectile
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("babrin2");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
            projectile.light = 0.5f; 
            projectile.penetrate = 1;
			projectile.ignoreWater = true;
            projectile.timeLeft = 120;
            projectile.friendly = true;
		}

	}
}