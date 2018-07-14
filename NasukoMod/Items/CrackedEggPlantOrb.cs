using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class CrackedEggPlantOrb : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cracked EggPlant Orb");
			Tooltip.SetDefault("'Useless...'");
		}
		
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 4;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
		}

	}
}