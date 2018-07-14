using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class EggPlantLoincloth : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Fairy Loincloth");
			Tooltip.SetDefault("+5% Melee Speed. +10% Move Speed.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.value = 10000;
			item.rare = 5;
			item.defense = 6;
			item.value = Item.sellPrice(0, 5, 0, 0);
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed *= 1.05f;
			player.moveSpeed *= 1.05f;
		}

	}
}