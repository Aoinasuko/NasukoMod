using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BlueEggPlantHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue EggPlant Hat");
			Tooltip.SetDefault("+2 Life Regen. +40 Max Life.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 7;
			item.defense = 12;
			item.value = Item.sellPrice(0, 5, 0, 0);
			item.lifeRegen = 2;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EggPlantCoverings") && legs.type == mod.ItemType("EggPlantLoincloth");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+4 Defense. +4 Life Regen.";
			player.statDefense += 4;
			player.lifeRegen += 4;
		}

		
		public override void UpdateEquip(Player player)
		{
			player.statLifeMax2 += 40;
		}

		public override bool DrawHead()
        {
            return true;
        }

	}
}