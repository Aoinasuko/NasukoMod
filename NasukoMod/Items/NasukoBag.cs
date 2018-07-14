using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	public class NasukoBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 11;
			item.expert = true;
			bossBagNPC = mod.NPCType("Nasuko");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			
			player.QuickSpawnItem(mod.ItemType("BlueEggPlantCrystal"), 3);
			
			player.QuickSpawnItem(mod.ItemType("EggPlantCrystal"), 20);
			
			player.QuickSpawnItem(mod.ItemType("NasukoDoll"));
		}
	}
}