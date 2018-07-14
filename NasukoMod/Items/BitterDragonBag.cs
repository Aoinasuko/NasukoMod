using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	public class BitterDragonBag : ModItem
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
			bossBagNPC = mod.NPCType("BitterDragon");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			int choice = Main.rand.Next(2);
			if (choice == 0)
			{
				player.QuickSpawnItem(mod.ItemType("Thefoam"));
			}
			else
			{
				player.QuickSpawnItem(mod.ItemType("TheTyphoon"));
			}
			
			player.QuickSpawnItem(mod.ItemType("EggPlantCrystal"), 20);
			
			player.QuickSpawnItem(mod.ItemType("BitterDragonChocolate"));
			
		}
	}
}