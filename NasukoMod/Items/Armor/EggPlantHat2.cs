using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class EggPlantHat2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True EggPlant Hat");
			Tooltip.SetDefault("+25% All Damage. +40 Max Life and Max Mana. +2 Max Minions." + "\n+10 Life and Mana Regen. +1 Extra Accessory Slots.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 11;
			item.expert = true;
			item.defense = 24;
			item.value = Item.sellPrice(10, 0, 0, 0);
		}
		
		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.25f;
			player.meleeDamage *= 1.25f;
			player.minionDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.thrownDamage *= 1.25f;
			player.statLifeMax2 += 40;
			player.statManaMax2 += 40;
			player.extraAccessorySlots += 1;
			player.maxMinions += 2;
			player.lifeRegen += 10;
			player.manaRegen += 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EggPlantCoverings") && legs.type == mod.ItemType("EggPlantLoincloth");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+30 Defence. Disable knockback.";
			player.statDefense += 30;
			player.noKnockback = true;
		}

		public override bool DrawHead()
        {
            return true;
        }

	}
}