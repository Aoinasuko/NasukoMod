using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class FairyBow : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Bow");
			Tooltip.SetDefault("Mana Changed Fairy!");
		}
	
		public override void SetDefaults()
		{
			item.damage = 15;
			item.ranged = true;
			item.mana = 2;
			item.width = 16;
			item.height = 36;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item25;
			item.autoReuse = true;
			item.shootSpeed = 8f;
			item.value = Item.sellPrice(0, 0, 50, 0);
            item.shoot = mod.ProjectileType("Pixie3");
		}

                public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(27,30);
                recipe.AddIngredient(39);
                recipe.AddIngredient(40,100);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

	}
}