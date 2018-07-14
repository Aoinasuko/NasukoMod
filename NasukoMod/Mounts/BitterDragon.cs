using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace NasukoMod.Mounts
{
	public class BitterDragon : ModMountData
	{
		public override void SetDefaults()
		{
			mountData.spawnDust = mod.DustType("Smoke");
			mountData.buff = mod.BuffType("bitterdragon");
			mountData.heightBoost = 10;
			mountData.fallDamage = 0.0f;
			mountData.runSpeed = 13f;
			mountData.dashSpeed = 10f;
			mountData.flightTimeMax = 1800;
			mountData.fatigueMax = 0;
			mountData.jumpHeight = 10;
			mountData.acceleration = 0.19f;
			mountData.jumpSpeed = 5f;
			mountData.blockExtraJumps = false;
			mountData.totalFrames = 3;
			mountData.constantJump = true;
			mountData.textureWidth = 82;
			mountData.textureHeight = 192;
			int[] array = new int[mountData.totalFrames];
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = 20;
			}
			mountData.playerYOffsets = array;
			//mountData.xOffset = 13;
			mountData.bodyFrame = 3;
			//mountData.yOffset = -12;
			mountData.playerHeadOffset = 22;
			mountData.standingFrameCount = 3;
			mountData.standingFrameDelay = 12;
			mountData.standingFrameStart = 0;
			mountData.runningFrameCount = 3;
			mountData.runningFrameDelay = 12;
			mountData.runningFrameStart = 0;
			mountData.flyingFrameCount = 3;
			mountData.flyingFrameDelay = 12;
			mountData.flyingFrameStart = 0;
			mountData.inAirFrameCount = 3;
			mountData.inAirFrameDelay = 12;
			mountData.inAirFrameStart = 0;
			mountData.idleFrameCount = 3;
			mountData.idleFrameDelay = 12;
			mountData.idleFrameStart = 0;
			mountData.idleFrameLoop = true;
			mountData.swimFrameCount = mountData.inAirFrameCount;
			mountData.swimFrameDelay = mountData.inAirFrameDelay;
			mountData.swimFrameStart = mountData.inAirFrameStart;
		}

		public override void UpdateEffects(Player player)
		{
			if (Math.Abs(player.velocity.X) > 4f)
			{
				Rectangle rect = player.getRect();
				Dust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, mod.DustType("Smoke"));
			}
		}
	}
}