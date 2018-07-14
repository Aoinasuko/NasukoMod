using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class BowofVinderre : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bow of Vinderre");
			Tooltip.SetDefault("Transforms Wooden Arrows in Vinderre Arrow. Attract Enemies when hit." + "\n'You hear someone testing the string of his bow.'");
		}
	
		public override void SetDefaults()
        {
            item.damage = 48;
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
            item.rare = 9;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/bow");
            item.autoReuse = true;
            item.shootSpeed = 8f;
            item.crit = 20;
            item.value = Item.sellPrice(1, 0, 0, 0);

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
				type = mod.ProjectileType("VinderreArrow"); // or ProjectileID.FireArrow;
			}
            
            return true;
        }

	}
}