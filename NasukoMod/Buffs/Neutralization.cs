using Terraria;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Buffs
{
	public class Neutralization : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Neutralization");
			Description.SetDefault("The attack power becomes 0.");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<NasuPlayer>(mod).Neutralization = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<NasuGlobalNPC>(mod).Neutralization = true;
		}

	}
}
