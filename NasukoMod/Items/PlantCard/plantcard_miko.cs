using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_miko : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miko [Plantcard]");
			Tooltip.SetDefault("+5% Move Speed. +2 Life Regen.");
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
			item.defense = 2;
			item.rare = 7;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
					 player.lifeRegen += 2;
                     player.moveSpeed *= 1.05f;
		}

	}
}