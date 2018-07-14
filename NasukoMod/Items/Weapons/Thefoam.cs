using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class Thefoam : ModItem
	{
	
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The foam");
			Tooltip.SetDefault("Foam,farm,fall.");
		}
	
		public override void SetDefaults()
		{
			item.damage = 100;
			item.magic = true;
			item.mana = 100;
			item.width = 40;
			item.height = 40;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 4;
			item.UseSound = SoundID.Item18;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ShadowArm4");
			item.shootSpeed = 7f;
            item.value = Item.sellPrice(0, 5, 0, 0);
		}

	}
}