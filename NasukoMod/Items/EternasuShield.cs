using Terraria;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class EternasuShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternasu Shield");
			Tooltip.SetDefault("-20% Mana Cost. -20% Taken Damage. +150% Move Speed." + "\n+20 Max Life. +10 Life and Mana Regen." );
		}

		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 28;
			item.value = 10000;
			item.rare = 11;
			item.expert = true;
			item.accessory = true;
			item.defense = 10;
			item.value = Item.sellPrice(10, 0, 0, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
				player.manaCost *= 0.8f;
				player.endurance = 1f - 0.8f * (1f - player.endurance);
				player.statLifeMax2 += 20;
				player.lifeRegen += 10;
				player.manaRegen += 10;
				player.moveSpeed *= 2.5f;
		}

	}
}