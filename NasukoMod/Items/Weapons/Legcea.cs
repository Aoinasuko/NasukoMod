using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class Legcea : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Legcea");
			Tooltip.SetDefault("Transforms Wooden Arrows in Icea Arrow.");
		}
	
		public override void SetDefaults()
        {
            item.damage = 36;
            item.noMelee = true;
            item.ranged = true;
            item.width = 69;
            item.height = 40;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.shoot = 10;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            item.crit = 5;
            item.value = Item.sellPrice(0, 30, 0, 0);

        }
        
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        	if (type == ProjectileID.WoodenArrowFriendly) // or ProjectileID.WoodenArrowFriendly
			{
				type = mod.ProjectileType("IceaArrow"); // or ProjectileID.FireArrow;
			}
			
			return true;
			
        }
        
		// What if I wanted this gun to have a 38% chance not to consume ammo?
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}

	}
}