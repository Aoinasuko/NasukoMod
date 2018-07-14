using Terraria;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Buffs
{
	public class Fairy : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Battle Fairy");
			Description.SetDefault("Fairy is Flowing you!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Fairy")] > 0)
			{
				modPlayer.fairyMinion = true;
			}
			if (!modPlayer.fairyMinion)
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
