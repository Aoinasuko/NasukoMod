using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
public class Picksword : ModItem
{

public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("AllRange Tool Sword");
			Tooltip.SetDefault("'All Range!'");
		}

public override void SetDefaults()
{
item.melee = true;
item.damage = 100;
item.width = 50;
item.height = 50;
item.useTime = 9;
item.useAnimation = 9;
item.useStyle = 1;
item.knockBack = 1;
item.value = 10000;
item.rare = 7;
item.tileBoost = 50;
item.UseSound = SoundID.Item1;
item.autoReuse = true;
}

public override bool AltFunctionUse(Player player)
       {
                return true;
       }

                public override bool CanUseItem(Player player)
{
	if (player.altFunctionUse == 2)
	{
				item.useAnimation = 9;
                                item.axe = 0;
        			item.hammer = 200;
                                item.pick = 0;
				}
				else
				{
				item.useAnimation = 9;
                                item.axe = 130;
       				item.hammer = 0;
                                item.pick = 200;
	}
	return base.CanUseItem(player);
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
recipe.AddIngredient(null,"EggPlantOrb");
recipe.AddIngredient(ItemID.PickaxeAxe);
recipe.SetResult(this);
recipe.AddRecipe();
}

}
}
