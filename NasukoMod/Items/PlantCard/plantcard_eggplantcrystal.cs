using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_eggplantcrystal : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlantCrystal [Plantcard]");
			Tooltip.SetDefault("+5% Magic Crit.");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 10000;
			item.useAnimation = 6;
			item.useTime = 6;
			item.useStyle = 2;
			item.UseSound = SoundID.Item44;
			item.accessory = true;
			item.defense = 4;
			item.rare = 7;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
                     player.magicCrit += 5;
		}

	}
}