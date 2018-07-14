using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class FairyShot : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Shot");
			Tooltip.SetDefault("'Shall I help you?'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 42;
			item.ranged = true;
            item.mana = 4;
			item.width = 16;
			item.height = 36;
			item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 6;
			item.UseSound = SoundID.Item25;
			item.autoReuse = true;
			item.shootSpeed = 15f;
			item.shoot = mod.ProjectileType("Pixie3");
			item.value = Item.sellPrice(1, 0, 0, 0);
		}

                public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
                {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(40));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
				}
				
                public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"EggPlantCrystal", 200);
                recipe.AddIngredient(null,"FairyBow");
                recipe.AddIngredient(501,100);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

	}
}