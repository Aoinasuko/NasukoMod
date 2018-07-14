using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class BlueEggPlantCrystal : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue EggPlant Crystal");
			Tooltip.SetDefault("'It have Blue EggPlant Power.'");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.value = Item.sellPrice(0, 20, 0, 0);
		}

	}
}