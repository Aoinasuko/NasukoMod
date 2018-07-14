using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class FairyOrb : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy Orb");
			Tooltip.SetDefault("'Go! Fairy!'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 25;
			item.summon = true;
			item.mana = 30;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("Fairy");
			item.width = 30;
			item.height = 30;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 9;
			item.noMelee = true;
            item.buffType = mod.BuffType("Fairy");
			item.value = Item.sellPrice(1, 0, 0, 0);
		}

                public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"EggPlantCrystal", 300);
                recipe.AddIngredient(425);
                recipe.SetResult(this);
                recipe.AddRecipe();
                }

                public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

	}
}