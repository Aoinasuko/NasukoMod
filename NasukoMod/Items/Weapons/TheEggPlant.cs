using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class TheEggPlant : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The EggPlant");
			Tooltip.SetDefault("'Lets Throw an eggplant.'");
			
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 10;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			
		}
	
		public override void SetDefaults()
		{
			item.damage = 20;
			item.magic = true;
			item.mana = 40;
			item.width = 40;
			item.height = 40;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 9;
			item.channel = true;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("EggPlantMeteor4");
			item.shootSpeed = 18f;
			item.value = Item.sellPrice(0, 50, 0, 0);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"BlueEggPlantCrystal");
            recipe.AddIngredient(null,"EggPlantCrystal",100);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		

	}
}