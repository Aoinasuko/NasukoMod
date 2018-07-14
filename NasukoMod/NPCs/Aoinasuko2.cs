using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{

	public class Aoinasuko2 : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aoi Nasuko");
        }

		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 80;
			npc.damage = 110;
			npc.defense = 1000;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.0f;
			npc.noTileCollide = true;
			npc.aiStyle = 2;
			npc.alpha = 100;
			Main.npcFrameCount[npc.type] = 2;
			animationType = 1;
			npc.dontTakeDamage = true;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}

		public override void AI()
		{
				NPC owner = Main.npc[(int)npc.ai[0]];
				if (!owner.active || owner.type != mod.NPCType("Aoinasuko"))
				{
				npc.active = false;
				return;
				}
                npc.ai[1] += 1;
                Player player = Main.player[npc.target];
                npc.position.Y = owner.position.Y - 100;
                npc.position.X = owner.position.X - 200;
        
        if (npc.ai[1] == 350)
		{
            int proj = 0;
				
								int choice2 = Main.rand.Next(2);
				
			                	if(choice2 ==0){
			                	for (int k = 0; k < 4; k++)
								{
            				    	proj = Projectile.NewProjectile(player.Center.X + (Main.rand.Next(1000) - 450), player.Center.Y + (Main.rand.Next(1000) - 450), 0f, 0f, mod.ProjectileType("Ringbomb"), 150, 1f);
		    					}
		    					}else{
		    					for (int k = 0; k < 4; k++)
								{
            						proj = Projectile.NewProjectile(player.Center.X + (Main.rand.Next(300) - 100), player.Center.Y + (200 * k), 5f, 0f, mod.ProjectileType("Ringbomb"), 150, 1f);
            				    	proj = Projectile.NewProjectile(player.Center.X + (Main.rand.Next(300) - 100), player.Center.Y - (200 * k), -5f, 0f, mod.ProjectileType("Ringbomb"), 150, 1f);
		    					}
		    					}
		    					
		if (NPC.CountNPCS(mod.NPCType("Counstar2")) < 10)
		{
        	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Counstar2"), 0, npc.whoAmI, 0, 0);
        }
		    					
		    npc.ai[1] = 0;
        }

        }
	}

}
