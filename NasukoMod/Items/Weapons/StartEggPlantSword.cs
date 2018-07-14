using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class StartEggPlantSword : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Start Eggplant Sword");
			Tooltip.SetDefault("'This is Start EggPlant sword.'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 14;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
                        item.shoot = mod.ProjectileType("Plant");
			item.value = Item.sellPrice(0, 0, 50, 0);
                        item.shootSpeed = 8f;
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
                recipe.AddIngredient(27,30);
                recipe.AddIngredient(24);
                recipe.AddIngredient(72);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

	}
}