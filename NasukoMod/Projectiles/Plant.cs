using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
	public class Plant : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plant");
		}
	
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 120;
			projectile.light = 0.5f;
		}

	}
}