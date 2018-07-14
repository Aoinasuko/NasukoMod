using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class EggPlantOrb : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Orb");
			Tooltip.SetDefault("'Nasunasu?'");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 6;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
		}
		
		public override void AddRecipes()
        {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(null,"CrackedEggPlantOrb", 1);
        recipe.AddIngredient(null,"EggPlantCrystal", 50);
        recipe.SetResult(this);
        recipe.AddRecipe();
        }

	}
}