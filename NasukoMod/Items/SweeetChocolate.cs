using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class SweeetChocolate : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sweeet Chocolate");
			Tooltip.SetDefault("Summon Mount Bitter Dragon." + "\n[c/DD99DD:Valentine's Item]");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 1;
			item.rare = 11;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.mountType = mod.MountType("BitterDragon");
			item.value = Item.sellPrice(100, 0, 0, 0);
		}

	}
}