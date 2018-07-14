using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class EggPlantSOrb : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue EggPlant Orb");
			Tooltip.SetDefault("'This is Blue Egg Plant Orb.'");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 7;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
		}

		public override void AddRecipes()
        {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null,"EggPlantOrb", 1);
        recipe.AddIngredient(null,"EggPlantCrystal", 200);
        recipe.AddIngredient(1006, 10);
        recipe.AddIngredient(null,"BlueEggPlantCrystal");
        recipe.SetResult(this);
        recipe.AddRecipe();
        }

	}
}