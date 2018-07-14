using Terraria;
using Terraria.ModLoader;
using NasukoMod.NPCs;

namespace NasukoMod.Buffs
{
	public class bitterdragon : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bitter Dragon");
			Description.SetDefault("Puieeeeee!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(mod.MountType<Mounts.BitterDragon>(), player);
			player.buffTime[buffIndex] = 10;
			
			player.lifeRegen += 2;
			player.manaRegen += 6;
			player.statDefense += 8;
			
			if(player.HasBuff(21)){
			
				player.lifeRegen += 8;
			
			}
			
			if(player.HasBuff(94)){
			
				player.manaRegen += 14;
			
			}
			
			if(player.HasBuff(24)){
			
				player.lifeRegen = -40;
			
			}
			
		}

	}
}
