using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class Ageoftornado : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Age of tornado");
			Tooltip.SetDefault("'Moonlight is In full bloom.'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 92;
			item.magic = true;
			item.mana = 30;
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
			item.shoot = mod.ProjectileType("ShadowArm5");
			item.shootSpeed = 16f;
			item.value = Item.sellPrice(5, 0, 0, 0);
		}
                
                public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
                {
                         int numberProjectiles = 2; // 4 or 5 shots
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
                recipe.AddIngredient(null,"TyphoonofTyphoon");
                recipe.AddIngredient(null,"HeartOrb");
                recipe.AddIngredient(3467,100);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

	}
}