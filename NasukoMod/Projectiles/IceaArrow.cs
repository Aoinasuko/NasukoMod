using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Projectiles
{
    public class IceaArrow : ModProjectile
    {
    
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("IceaArrow");
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

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            
            projectile.velocity.Y *= -5f;
            
            if(projectile.velocity.Y < -8f){
            
            	projectile.velocity.Y = -8f;
            
            }
            if(projectile.velocity.Y > 8f){
            
            	projectile.velocity.Y = 8f;
            
            }
            
            if(projectile.timeLeft > 350){
            
            projectile.timeLeft = 350;
            
            }
            
			return false;
		}

        public override void AI()
        {
            //red | green| blue
            Lighting.AddLight(projectile.Center, 0.9f, 0.4f, 0.4f);  //this defines the projectile light color
            int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.AncientLight);
            Main.dust[dust2].velocity /= 30f; //this modify the velocity of dust2
            Main.dust[dust2].scale = 1f; //this modify the scale of the dust2

			if (projectile.timeLeft <= 360){

			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
            float distance = 2000f;
            bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5 && projectile.timeLeft <= 280)
				{
                                        Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}

				}

			}
                        if (target)
			{
                                AdjustMagnitude(ref move);	
                                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                                AdjustMagnitude(ref projectile.velocity);
			}

			}

		}

                private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 12f)
			{
				vector *= 12f / magnitude;
			}
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
            target.AddBuff(BuffID.Frostburn, 510);//this adds a buff to the npc hit. 210 it the time of the buff
        }

    }
}