using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class Zoneofsafe : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zone of safe");
			Tooltip.SetDefault("Create a safe zone." + "\nMana does not regenerate within the zone.");
		}
	
		public override void SetDefaults()
		{
			item.width = 38;
			item.height = 38;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.value = 10000;
            item.mana = 100;
			item.rare = 5;
			item.value = Item.sellPrice(0, 10, 0, 0);
            item.shoot = mod.ProjectileType("Zoneofsafe");
            item.UseSound = SoundID.Item44;
            item.value = Item.sellPrice(0, 25, 0, 0);
		}

	}
}