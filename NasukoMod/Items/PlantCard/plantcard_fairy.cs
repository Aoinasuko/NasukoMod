using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_fairy : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fairy [Plantcard]");
			Tooltip.SetDefault("-10% Mana Cost. +25% Magic Damage. -50% Max Life." + "\nYou gain +25% Magic Crit when life is Half or less.");
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
			item.rare = 9;
			item.value = Item.sellPrice(0, 10, 0, 0);
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
					 player.manaCost *= 0.9f;
                     player.magicDamage *= 1.25f;
                     player.statLifeMax2 = (player.statLifeMax2/2);
                     if(player.statLife <= player.statLifeMax2/2){
                     player.magicCrit += 25;
                     }
		}

	}
}