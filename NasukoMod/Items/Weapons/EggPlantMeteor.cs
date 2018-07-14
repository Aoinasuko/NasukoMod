using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class EggPlantMeteor : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Meteor");
			Tooltip.SetDefault("Shoot bullets that can be operated freely for a certain period of time." + "\n'The meteorite freely!'");
			
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 30;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
			
		}
	
		public override void SetDefaults()
		{
			item.damage = 200;
			item.magic = true;
			item.mana = 200;
			item.width = 40;
			item.height = 40;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 3;
			item.channel = true;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("EggPlantMeteor3");
			item.shootSpeed = 18f;
			item.value = Item.sellPrice(10, 0, 0, 0);
		}

	}
}