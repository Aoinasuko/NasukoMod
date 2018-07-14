using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NasukoMOD.Items;

namespace NasukoMOD.Items
{
    public class IceaArrow : ModItem
    {
    	
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icea Arrow");
			Tooltip.SetDefault("This is Induce Arrow. Give Frostburn to the enemy I applied.");
		}
    
        public override void SetDefaults()
        {
            item.damage = 3;    //The damage stat for the Weapon.
            item.ranged = true;  //This defines if it does Ranged damage and if its effected by Ranged increasing Armor/Accessories.
            item.width = 8;  //The size of the width of the hitbox in pixels.
            item.height = 8;   //The size of the height of the hitbox in pixels.
            item.maxStack = 999; //This defines the items max stack
            item.consumable = true;  //Tells the game that this should be used up once fired
            item.knockBack = 1.0f;  //Added with the weapon's knockback
            Item.sellPrice(0, 0, 5, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 20silvers)
            item.rare = 6;   //The color the title of your Weapon when hovering over it ingame  
            item.shoot = mod.ProjectileType("IceaArrow");  //This defines what type of projectile this weapon will shoot	
            item.shootSpeed = 12f; //Added to the weapon's shoot speed
            item.ammo = 40;    //This defines what type of ammo is. 40 is arrow
        }

    }
}