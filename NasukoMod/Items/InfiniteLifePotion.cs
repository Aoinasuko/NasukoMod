using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class InfiniteLifePotion : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infinite LifePotion");
			Tooltip.SetDefault("'Getting Infinite Life.'");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 9;
			item.useAnimation = 6;
			item.useTime = 6;
			item.useStyle = 2;
			item.UseSound = SoundID.Item44;
			item.healLife = 114514;
			item.accessory = true;
			item.consumable = false;
		}

                public override void UpdateAccessory(Player player, bool hideVisual)
		{
                     player.statLife = player.statLifeMax;
		}

	}
}