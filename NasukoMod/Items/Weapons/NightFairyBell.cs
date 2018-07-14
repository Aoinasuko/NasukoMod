using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace NasukoMod.Items.Weapons
{
	public class NightFairyBell : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night FairyBell");
			Tooltip.SetDefault("'Lets Play togeter!'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 44;
			item.magic = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 9;
			item.value = 10000;
			item.rare = 9; 
			item.autoReuse = true;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shootSpeed = 22f;
            item.shoot = mod.ProjectileType("Pixie");
			item.value = Item.sellPrice(1, 0, 0, 0);
		}


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
                   int numberProjectiles = 3; // 4 or 5 shots
			       for (int i = 0; i < numberProjectiles; i++)
					{
				    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
					}
		return false;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"EggPlantCrystal",300);
            recipe.AddIngredient(425);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}