using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace NasukoMod.Items      //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class NasukoFishingPole : ModItem
    {
    
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nasuko Fishing Pole");
			Tooltip.SetDefault("'Cute Eggplant fairy Fishing rod.'");
		}
	
    
        public override void SetDefaults()
        {
        	item.CloneDefaults(ItemID.GoldenFishingRod);  //This defines the fishing pole you want to clone
        	item.width = 48;
			item.height = 38;
            item.fishingPole = 30; //this defines the fishing pole fishing power
            item.value = Item.buyPrice(0, 5, 0, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10 gold and to sell it its 2 gold)
            item.rare = 6;    //The color the title of your item when hovering over it ingame .
            item.shoot = mod.ProjectileType("NasukoFishingPoleProj");  //This defines what type of projectile this item will shot	
            item.shootSpeed = 18f; //this defines the the projectile speed when shot. for fishing pole also increases the fishing line length/range
            item.value = Item.sellPrice(0, 20, 0, 0);
        }

        // What if I wanted it to shoot like a shotgun?
		// Shotgun style: Multiple Projectiles, Random spread 
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3; // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
				// If you want to randomize the speed to stagger the projectiles
				// float scale = 1f - (Main.rand.NextFloat() * .3f);
				// perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}

    }
}