using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class Acornbaitofnasuko : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn bait of Nasuko");
			Tooltip.SetDefault("'It's a bit better than ordinary acorn.'");
		}
		
		public override void SetDefaults()
		{
			item.width = 21;
			item.height = 21;
			item.maxStack = 999;
			item.rare = 3;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.bait = 30;
		}

	}
}