using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class EggPlantCoverings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Fairy Coverings");
			Tooltip.SetDefault("+5% Magic and Melee Damage. +20 Max Mana.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 5;
			item.defense = 8;
			item.value = Item.sellPrice(0, 5, 0, 0);
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.05f;
			player.magicDamage *= 1.05f;
			player.statManaMax2 += 20;
		}

	}
}