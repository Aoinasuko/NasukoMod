using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class Acornbait : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn bait");
			Tooltip.SetDefault("'Acorn carved into something.'");
		}
		
		public override void SetDefaults()
		{
			item.width = 21;
			item.height = 21;
			item.maxStack = 999;
			item.rare = 2;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.value = Item.sellPrice(0, 0, 1, 0);
			item.bait = 15;
		}

		public override void AddRecipes()
        {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(27,3);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }

	}
}