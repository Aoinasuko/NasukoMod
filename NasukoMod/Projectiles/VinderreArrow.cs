using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
    public class VinderreArrow : ModProjectile
    {
    
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("VinderreArrow");
		}
    
        public override void SetDefaults()
        {
            projectile.width = 8;  //Set the hitbox width
            projectile.height = 8;  //Set the hitbox height
            projectile.aiStyle = 1; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = 1.0f; //This defines the projectile light
            aiType = 1; // this is the projectile ai style . 1 is for arrows style
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
        	Player player = Main.player[projectile.owner];
        
            target.AddBuff(BuffID.Poisoned, 510);//this adds a buff to the npc hit. 210 it the time of the buff
            if(!target.boss){
            target.AddBuff(mod.BuffType("Neutralization"), 210);//this adds a buff to the npc hit. 210 it the time of the buff
            target.damage = 0;
            target.position = player.position;
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/bow2"), target.position);
            }
        }

    }
}