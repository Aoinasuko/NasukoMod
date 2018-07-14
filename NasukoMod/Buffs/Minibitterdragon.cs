using Terraria;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Buffs
{
	public class Minibitterdragon : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mini Bitter Dragon");
			Description.SetDefault("Pui!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Minibitterdragon")] > 0)
			{
				modPlayer.draMinion = true;
			}
			if (!modPlayer.draMinion)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}

	}
}
