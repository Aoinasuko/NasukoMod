using Terraria;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Buffs
{
	public class Nasuko : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Nasuko");
			Description.SetDefault("I am Nasuko!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Nasuko")] > 0)
			{
				modPlayer.nasuMinion = true;
			}
			if (!modPlayer.nasuMinion)
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
