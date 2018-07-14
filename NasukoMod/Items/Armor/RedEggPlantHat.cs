using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RedEggPlantHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red EggPlant Hat");
			Tooltip.SetDefault("+20% All Damage. -40 Max Life.");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 7;
			item.defense = 4;
			item.value = Item.sellPrice(0, 5, 0, 0);
		}
		
		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.2f;
			player.meleeDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.thrownDamage *= 1.2f;
			player.statLifeMax2 -= 40;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("EggPlantCoverings") && legs.type == mod.ItemType("EggPlantLoincloth");
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "+20% All Damage. -4 Defence.";
			player.magicDamage *= 1.2f;
			player.meleeDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.thrownDamage *= 1.2f;
			player.statDefense -= -4;
		}

		public override bool DrawHead()
        {
            return true;
        }

	}
}