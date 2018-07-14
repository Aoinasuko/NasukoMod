using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class InfiniteManaPotion : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinite EggPlant ManaPotion");
			Tooltip.SetDefault("'Getting Infinite Mana.'");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.value = 10000;
			item.rare = 11;
			item.expert = true;
			item.useAnimation = 6;
			item.useTime = 6;
			item.useStyle = 2;
			item.UseSound = SoundID.Item44;
            item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
                     player.statMana = player.statManaMax;
		}

	}
}