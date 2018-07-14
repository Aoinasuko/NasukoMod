using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class Regrepsa : HoverShooter
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 60;
			projectile.height = 60;
			Main.projFrames[projectile.type] = 6;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			inertia = 20f;
			shoot = mod.ProjectileType("ShadowArm6");
			shootSpeed = 18f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.dead)
			{
				modPlayer.regMinion = false;
			}
			if (modPlayer.regMinion)
			{
				projectile.timeLeft = 10;
			}
		}

		public override void SelectFrame()
		{
			projectile.frameCounter++;
			if (projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 2;
			}
		}
	}

}