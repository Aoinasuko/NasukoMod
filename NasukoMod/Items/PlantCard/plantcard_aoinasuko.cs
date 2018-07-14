using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_aoinasuko : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aoi Nasuko [Plantcard]");
			Tooltip.SetDefault("+40 Max Mana. +30% Magic Crit. -20% Magic Damage." + "\nYou gain Mana regeneration when life is Half or less.");
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
			item.defense = 6;
			item.rare = 9;
			item.value = Item.sellPrice(0, 10, 0, 0);
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
					 player.magicDamage *= 0.8f;
                     player.statManaMax2 += 40;
                     player.magicCrit += 30;
                     if(player.statLife <= player.statLifeMax2/2){
                     player.manaRegen += 20;
                     }
		}

	}
}