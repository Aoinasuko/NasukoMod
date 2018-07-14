using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	public class NasukoBag2 : ModItem
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
			bossBagNPC = mod.NPCType("Aoinasuko");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			player.TryGettingDevArmor();
			
			int item = 0;
			int choice = Main.rand.Next(3);
			switch (choice)
			{
				case 0:
			                player.QuickSpawnItem(mod.ItemType("TrueEternasuSword"));
					break;
				case 1:
			                player.QuickSpawnItem(mod.ItemType("TrueEggplantRapier"));
					break;
				case 2:
			                player.QuickSpawnItem(mod.ItemType("EggPlantMeteor"));
					break;
                              
			}
			
			player.QuickSpawnItem(mod.ItemType("EggPlantCrystal"), 100);
			
			player.QuickSpawnItem(mod.ItemType("EggPlantHat2"));
			
			player.QuickSpawnItem(mod.ItemType("EternasuShield"));
			
			choice = Main.rand.Next(100);
			if(choice == 0){
			
			player.QuickSpawnItem(mod.ItemType("InfiniteManaPotion"));
			
			}
			
		}
	}
}