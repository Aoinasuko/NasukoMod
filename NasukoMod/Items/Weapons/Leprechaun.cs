using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class Leprechaun : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Leprechaun");
			Tooltip.SetDefault("'Hun...'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 90;
			item.ranged = true;
			item.width = 16;
			item.height = 36;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item25;
			item.autoReuse = true;
			item.shootSpeed = 22f;
			item.value = Item.sellPrice(5, 0, 0, 0);
		}

                 public override bool AltFunctionUse(Player player)
		{
			return true;
		}

                public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
                item.shootSpeed = 16f; 
			    item.shoot = mod.ProjectileType("Pixie6");
                                
			}
			else
			{
                            item.shootSpeed = 22f;
                            item.shoot = mod.ProjectileType("Pixie4");

			}
			return base.CanUseItem(player);
		}

                public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"HeartOrb");
                recipe.AddIngredient(null,"FairyShot");
                recipe.AddIngredient(501,100);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

	}
}