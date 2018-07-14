using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_lapis : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lapis [Plantcard]");
			Tooltip.SetDefault("+20 Max Mana. +25% Move Speed. +4 Life Regen." + "\nYou gain +200% Move Speed when life is 25% or less.");
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
			item.rare = 9;
			item.value = Item.sellPrice(0, 10, 0, 0);
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
					 player.lifeRegen += 4;
                     player.moveSpeed *= 1.25f;
                     player.statManaMax2 += 20;
                     if(player.statLife <= player.statLifeMax2/4){
                     player.moveSpeed *= 3.0f;
                     }
		}

	}
}