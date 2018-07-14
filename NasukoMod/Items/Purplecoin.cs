using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class Purplecoin : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Purple coin");
			Tooltip.SetDefault("'It have Suspicious Power.'(Summon Boss.)");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 11;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.value = Item.sellPrice(3, 0, 0, 0);
			item.consumable = true;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI,mod.NPCType("Aoinasuko"));
			return true;
		}
		
		public override void AddRecipes()
        {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(3467, 10);
        recipe.AddIngredient(null,"EggPlantCrystal", 300);
        recipe.SetResult(this);
        recipe.AddRecipe();
        }

	}
}