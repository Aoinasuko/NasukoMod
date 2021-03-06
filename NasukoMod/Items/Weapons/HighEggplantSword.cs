using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class HighEggplantSword : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("High Eggplant Sword");
			Tooltip.SetDefault("'This is a High EggPlant sword.'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 35;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 8;
			item.useAnimation = 8;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Plant");
			item.shootSpeed = 10f;
			item.value = Item.sellPrice(0, 20, 0, 0);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}

                 public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"EggplantSword");
                recipe.AddIngredient(null,"BlueEggPlantCrystal");
                recipe.AddIngredient(null,"EggPlantCrystal",200);
                recipe.AddIngredient(174,50);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }


	}
}