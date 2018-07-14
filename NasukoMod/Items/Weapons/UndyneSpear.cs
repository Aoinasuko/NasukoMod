using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class UndyneSpear : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Undyne Spear");
			Tooltip.SetDefault("'NGAAAAHHHH!'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 28;
			item.melee = true;
			item.width = 38;
			item.height = 38;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 3;
			item.knockBack = 4;
			item.value = 10000;
            item.mana = 5;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType("UndyneSpear");
		}

	}
}