using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
public class EggPlantPicksword : ModItem
{

public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Tool Sword");
			Tooltip.SetDefault("'Nice Tool.'");
		}

public override void SetDefaults()
{
item.melee = true;
item.damage = 32;
item.width = 50;
item.height = 50;
item.useTime = 9;
item.useAnimation = 9;
item.useStyle = 1;
item.knockBack = 1;
item.value = 10000;
item.rare = 6;
item.tileBoost = 8;
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
                                item.axe = 100;
       				item.hammer = 0;
                                item.pick = 150;
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
recipe.AddIngredient(null,"BlueEggPlantCrystal");
recipe.AddIngredient(null,"EggPlantCrystal",100);
recipe.SetResult(this);
recipe.AddRecipe();
}

}
}
