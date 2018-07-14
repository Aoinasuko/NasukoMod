using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NasukoMOD.Items;

namespace NasukoMOD.Items
{
    public class IceaAmmo : ModItem
    {
    	
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icea Ammo");
			Tooltip.SetDefault("This is Ice Ammo. If you hit you rarely recover your physical strength.");
		}

		public override void SetDefaults()
		{
			item.damage = 4;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.0f;
			item.rare = 6;
			item.shoot = mod.ProjectileType("IceaAmmo");   //The projectile shoot when your weapon using this ammo
			Item.sellPrice(0, 0, 5, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 20silvers)
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

    }
}