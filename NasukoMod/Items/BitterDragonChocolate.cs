using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class BitterDragonChocolate : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bitter Dragon Chocolate");
			Tooltip.SetDefault("Getting 50 Life. But This use 100 Mana.");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 1;
			item.rare = 11;
			item.useAnimation = 12;
			item.useTime = 12;
			item.useStyle = 5;
			item.UseSound = SoundID.Item4;
			item.healLife = 50;
			item.mana = 100;
			item.expert = true;
		}
	}
}