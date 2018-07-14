using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class SummonRegrepsaOrb : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Summon Regrepsa Orb");
			Tooltip.SetDefault("'...'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 60;
			item.summon = true;
			item.mana = 50;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("Regrepsa");
			item.width = 30;
			item.height = 30;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 9;
			item.noMelee = true;
            item.buffType = mod.BuffType("Regrepsa");
			item.value = Item.sellPrice(3, 0, 0, 0);
		}

                public override void AddRecipes()
                {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"FairyOrb");
                recipe.AddIngredient(null,"HeartOrb");
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