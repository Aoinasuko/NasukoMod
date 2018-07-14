using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	public class CardBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Card Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = 7;
			bossBagNPC = mod.NPCType("BitterDra");
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			
			int choice = Main.rand.Next(5);
			if (choice == 0)
			{
				int choice2 = Main.rand.Next(5) + 1;
					
					switch (choice2)
      {
          case 1:
              player.QuickSpawnItem(mod.ItemType("plantcard_aoinasuko"));
              break;
          case 2:
              player.QuickSpawnItem(mod.ItemType("plantcard_bitterdragongirl"));
              break;
          case 3:
              player.QuickSpawnItem(mod.ItemType("plantcard_catnasuko"));
              break;
          case 4:
              player.QuickSpawnItem(mod.ItemType("plantcard_fairy"));
              break;
          case 5:
              player.QuickSpawnItem(mod.ItemType("plantcard_lapis"));
              break;
          default:
              break;
      }
					
			}
			else
			{
			
			int choice2 = Main.rand.Next(5) + 1;
					
					switch (choice2)
      {
          case 1:
              player.QuickSpawnItem(mod.ItemType("plantcard_conzikinako"));
              break;
          case 2:
              player.QuickSpawnItem(mod.ItemType("plantcard_eggplantcrystal"));
              break;
          case 3:
              player.QuickSpawnItem(mod.ItemType("plantcard_hanamigirl"));
              break;
          case 4:
              player.QuickSpawnItem(mod.ItemType("plantcard_miko"));
              break;
          case 5:
              player.QuickSpawnItem(mod.ItemType("plantcard_suiso"));
              break;
          default:
              break;
      }
			
			}
			
			player.QuickSpawnItem(73,Main.rand.Next(5)+1);
			
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BlueEggPlantCrystal");
			recipe.AddIngredient(null, "EggPlantCrystal", 100);
			recipe.SetResult(this,5);
			recipe.AddRecipe();
		}
		
	}
}