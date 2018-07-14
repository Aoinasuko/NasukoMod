using Terraria;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class ChocolateWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Allows flight and slow fall and Regenerates life.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 11;
			item.expert = true;
			item.accessory = true;
			item.defense = 6;
			item.lifeRegen = 2;
			item.value = Item.sellPrice(3, 0, 0, 0);
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.wingTimeMax = 80;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.08f;
			ascentWhenRising = 0.18f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 7f;
			acceleration *= 1.5f;
		}

	}
}