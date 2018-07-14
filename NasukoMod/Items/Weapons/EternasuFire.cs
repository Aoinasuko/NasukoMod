using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class EternasuFire : ModItem
	{
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternasu Fire");
			Tooltip.SetDefault("Shoot to Laser Fire.");
		}
	
		public override void SetDefaults()
		{
			item.damage = 32;
			item.noMelee = true;
			item.magic = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.mana = 5;
			item.rare = 6;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("EternasuFire");
            item.value = Item.sellPrice(0, 5, 0, 0);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "BlueEggPlantCrystal");
			recipe.AddIngredient(null, "EggPlantCrystal", 100);
			recipe.AddIngredient(174,50);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}