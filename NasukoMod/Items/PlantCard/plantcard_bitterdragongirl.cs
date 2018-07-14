using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.PlantCard
{
	//imported from my tAPI mod because I'm lazy
	public class plantcard_bitterdragongirl : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bitter Dragon Girl [Plantcard]");
			Tooltip.SetDefault("+10% Melee Speed. +10% Minion Damage." + "\nSummon Mini Bitter Dragon.");
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
			item.defense = 4;
			item.rare = 9;
			item.value = Item.sellPrice(0, 10, 0, 0);
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.meleeSpeed *= 1.1f;
            player.minionDamage  *= 1.1f;
            if (player.ownedProjectileCounts[mod.ProjectileType("Minibitterdragon")] == 0)
			{
                Projectile.NewProjectile(player.position.X, player.position.Y - 30, 0, 0, mod.ProjectileType("Minibitterdragon"), 50, 3, player.whoAmI);
				player.AddBuff(mod.BuffType("Minibitterdragon"), 3600, true);
			}
		}

	}
}