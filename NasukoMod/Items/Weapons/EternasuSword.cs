using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class EternasuSword : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eternasu Sword");
			Tooltip.SetDefault("Summon Blue EggPlant Fairy.");
		}
	
		public override void SetDefaults()
		{
			item.damage = 10;
			item.summon = true;
			item.width = 26;
			item.height = 26;
			item.mana = 25;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 10000;
			item.rare = 9;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.value = Item.sellPrice(2, 0, 0, 0);
			item.buffType = mod.BuffType("Nasuko");
			item.shoot = mod.ProjectileType("Nasuko");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}

	}
}