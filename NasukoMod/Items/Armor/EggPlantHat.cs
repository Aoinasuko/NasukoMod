using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EggPlantHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Hat");
			Tooltip.SetDefault("+5% All Damage. +20 Max Life.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 7;
			item.defense = 8;
			item.value = Item.sellPrice(0, 5, 0, 0);
		}
		
		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.05f;
			player.meleeDamage *= 1.05f;
			player.minionDamage *= 1.05f;
			player.rangedDamage *= 1.05f;
			player.thrownDamage *= 1.05f;
			player.statLifeMax2 += 20;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EggPlantCoverings") && legs.type == mod.ItemType("EggPlantLoincloth");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+10% Renged Damage. +4 Mana Regen.";
			player.rangedDamage *= 1.1f;
			player.manaRegen += 4;
		}

		public override bool DrawHead()
        {
            return true;
        }

	}
}