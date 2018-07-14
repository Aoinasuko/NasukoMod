using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class Minibitterdragon : TankShooter
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 32;
			projectile.height = 58;
			Main.projFrames[projectile.type] = 2;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
            projectile.damage = 50;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			inertia = 20f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.dead)
			{
				modPlayer.draMinion = false;
			}
			if (modPlayer.draMinion)
			{
				projectile.timeLeft = 10;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.velocity.Y = -3f;

			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.player[projectile.owner].statLife += (damage/20);
            
            Main.player[projectile.owner].HealEffect(damage/20, true);
            
        }

        public override void CreateDust()
		{
			if (projectile.velocity.Y < -0.3)
			{
				if (Main.rand.Next(3) == 0)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, mod.DustType("PuriumFlame"));
					Main.dust[dust].velocity.Y += 1.2f;
				}
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