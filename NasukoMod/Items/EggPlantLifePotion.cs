using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class EggPlantLifePotion : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Life Potion");
			Tooltip.SetDefault("Getting 100 Life. But do not cause potsickness.");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 7;
			item.useAnimation = 6;
			item.useTime = 6;
			item.useStyle = 2;
			item.UseSound = SoundID.Item44;
			item.healLife = 100;
			item.consumable = true;
		}
		
		public override void AddRecipes()
        {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient(188,10);
        recipe.AddIngredient(null,"EggPlantCrystal", 3);
		recipe.AddTile(TileID.Bottles);
        recipe.SetResult(this, 5);
        recipe.AddRecipe();
        }

	}
}