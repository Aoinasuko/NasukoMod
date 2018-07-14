using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_catnasuko : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cat Nasuko [Plantcard]");
			Tooltip.SetDefault("+25% Melee Speed. +10% Melee Crit. -100% Magic Damage." + "\nConvert half of possessed mana to HP.");
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
					 player.magicDamage *= 0.0f;
                     player.meleeCrit += 10;
                     player.meleeSpeed *= 1.25f;
                     player.statLifeMax2 += player.statManaMax2/2;
		}

	}
}