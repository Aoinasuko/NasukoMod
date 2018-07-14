using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles.Minions
{
	//ported from my tAPI mod because I'm lazy
	public class Fairy : HoverShooter
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 42;
			projectile.height = 30;
			Main.projFrames[projectile.type] = 2;
			projectile.friendly = true;
			Main.projPet[projectile.type] = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			inertia = 40f;
			shoot = mod.ProjectileType("FairyBolt");
			shootSpeed = 18f;
		}

		public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.dead)
			{
				modPlayer.fairyMinion = false;
			}
			if (modPlayer.fairyMinion)
			{
				projectile.timeLeft = 10;
			}
		}

		public override void CreateDust()
		{
			if (projectile.ai[0] == 0f)
			{
				if (Main.rand.Next(5) == 0)
				{
					int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height / 2, mod.DustType("PuriumFlame"));
					Main.dust[dust].velocity.Y -= 1.2f;
				}
			}
			else
			{
				if (Main.rand.Next(3) == 0)
				{
					Vector2 dustVel = projectile.velocity;
					if (dustVel != Vector2.Zero)
					{
						dustVel.Normalize();
					}
					int dust = Dust.NewDust(projectile.position, 16, 16, mod.DustType("Smoke"), 0f, 0f, 0, Color.Blue);
					Main.dust[dust].velocity -= 1.2f * dustVel;
				}
			}
			Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
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