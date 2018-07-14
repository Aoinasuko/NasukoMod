using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class Icea : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icea");
			Tooltip.SetDefault("Transforms Wooden Arrows in Icea Arrow. Recover HP Everytime You Shoot.");
		}
	
		public override void SetDefaults()
        {
            item.damage = 66;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 11;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            item.crit = 15;
            item.expert = true;
            item.value = Item.sellPrice(5, 0, 0, 0);

        }
        
		// What if I wanted this gun to have a 38% chance not to consume ammo?
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        	
        	if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = mod.ProjectileType("IceaArrow"); // or ProjectileID.FireArrow;
			}
        
           int numberProjectiles = 3;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
            
            int amountToHeal = damage / 40;
			if(amountToHeal + player.statLife > player.statLifeMax2)
			amountToHeal = player.statLifeMax2 - player.statLife;
			player.statLife += amountToHeal;
            
            return false; //Makes sure to not fire the original projectile
        }

	}
}