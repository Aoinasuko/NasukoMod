using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class TyphoonofTyphoon : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Typhoon of Typhoon");
			Tooltip.SetDefault("'This is true Typhoon.'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 48;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowArm3");
			item.shootSpeed = 9f;
			item.value = Item.sellPrice(3, 0, 0, 0);
		}
                
                public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
                {
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}

                 public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"TheTyphoon");
                recipe.AddIngredient(null,"EggPlantCrystal",100);
                recipe.AddIngredient(null,"EggPlantSOrb");
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

	}
}