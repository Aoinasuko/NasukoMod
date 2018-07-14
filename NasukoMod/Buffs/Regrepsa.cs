using Terraria;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Buffs
{
	public class Regrepsa : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Regrepsa");
			Description.SetDefault("I am Regrepsa!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			NasuPlayer modPlayer = player.GetModPlayer<NasuPlayer>(mod);
			if (player.ownedProjectileCounts[mod.ProjectileType("Regrepsa")] > 0)
			{
				modPlayer.regMinion = true;
			}
			if (!modPlayer.regMinion)
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
