using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
    public class IceaAmmo : ModProjectile
    {
    
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("IceaAmmo");
		}
    
        public override void SetDefaults()
        {
            projectile.width = 12;  //Set the hitbox width
            projectile.height = 12;  //Set the hitbox height
            projectile.aiStyle = 0; //How the projectile works
            projectile.friendly = true;  //Tells the game whether it is friendly to players/friendly npcs or not
            projectile.hostile = false; //Tells the game whether it is hostile to players or not
            projectile.tileCollide = true; //Tells the game whether or not it can collide with a tile
            projectile.ignoreWater = true; //Tells the game whether or not projectile will be affected by water
            projectile.ranged = true;   //Tells the game whether it is a ranged projectile or not
            projectile.timeLeft = 400; //The amount of time the projectile is alive for
            projectile.light = 1.0f; //This defines the projectile light
            aiType = 0; // this is the projectile ai style . 1 is for arrows style
        }

        public override void AI()
        {
            //red | green| blue
            Lighting.AddLight(projectile.Center, 0.9f, 0.4f, 0.4f);  //this defines the projectile light color
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight);
            Main.dust[dust2].velocity /= 30f; //this modify the velocity of dust2
            Main.dust[dust2].scale = 1f; //this modify the scale of the dust2

		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            target.AddBuff(BuffID.Frostburn, 510);//this adds a buff to the npc hit. 210 it the time of the buff
            
            if(Main.rand.Next(10)==0){
            
            		Main.player[projectile.owner].statLife += (damage/20);
            
            		Main.player[projectile.owner].HealEffect(damage/20, true);
            
            }
            
        }

    }
}