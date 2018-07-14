using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{

	[AutoloadBossHead]
	public class Aoinasuko : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aoi Nasuko");
        }

		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 80;
			npc.damage = 90;
			npc.defense = 80;
			npc.lifeMax = 575000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.0f;
			npc.noTileCollide = true;
			npc.aiStyle = 2;
			Main.npcFrameCount[npc.type] = 2;
			animationType = 1;
			npc.boss = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/EggPlantFairy2");
			bossBag = mod.ItemType("NasukoBag2");
		}

		public override void AI()
		{
		
		if (npc.life < npc.lifeMax * 0.5 && NPC.CountNPCS(mod.NPCType("Aoinasuko2")) == 0){
		    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Aoinasuko2"), 0, npc.whoAmI, 0, 0);
            }
		
		if (npc.life < npc.lifeMax * 0.25 && NPC.CountNPCS(mod.NPCType("Aoinasuko3")) == 0){
		    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Aoinasuko3"), 0, npc.whoAmI, 0, 0);
            }
		
                npc.ai[0] += 1;
                Player player = Main.player[npc.target];
                if(npc.position.Y >= player.Center.Y - 300){
                npc.velocity.Y = -5f;
                }
                if(npc.position.Y <= player.Center.Y - 1500){
                npc.velocity.Y = 15f;
                }
        
        if (npc.ai[0] == 200)
		{
            int proj = 0;
            int choice = Main.rand.Next(3);
                        switch (choice)
			{
				case 0:
			                	proj = Projectile.NewProjectile(npc.Center.X-200, npc.Center.Y, 0f, 3f, mod.ProjectileType("FairySpear"), 50, 1f);
			                	proj = Projectile.NewProjectile(npc.Center.X+200, npc.Center.Y, 0f, 3f, mod.ProjectileType("FairySpear"), 50, 1f);
			                	proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(500) - 250), npc.Center.Y-500, 0f, 7f, mod.ProjectileType("FairySpear2"), 70, 1f);
			                	proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(500) - 250), npc.Center.Y-500, 0f, 7f, mod.ProjectileType("FairySpear2"), 70, 1f);
			                	
			                	if (npc.life < npc.lifeMax * 0.5){
			                	proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(1000) - 500), npc.Center.Y-750, 0f, 7f, mod.ProjectileType("FairySpear2"), 70, 1f);
			                	proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(1000) - 500), npc.Center.Y-750, 0f, 7f, mod.ProjectileType("FairySpear2"), 70, 1f);
			                	}
			                	
					break;
				case 1:
						    int choice2 = Main.rand.Next(2);
						    
						    if(choice2 ==0){
			                for (int k = 0; k < 4; k++)
							{
            				    proj = Projectile.NewProjectile(player.Center.X + (Main.rand.Next(1000) - 450), player.Center.Y + (Main.rand.Next(1000) - 450), 0f, 0f, mod.ProjectileType("Ringbomb"), 150, 1f);
		    				}
		    				}else{
		    				for (int k = 0; k < 4; k++)
							{
            					proj = Projectile.NewProjectile(player.Center.X + (200 * k), player.Center.Y + (Main.rand.Next(300) - 100), 0f, 0f, mod.ProjectileType("Ringbomb"), 150, 1f);
            				    proj = Projectile.NewProjectile(player.Center.X - (200 * k), player.Center.Y + (Main.rand.Next(300) - 100), 0f, 0f, mod.ProjectileType("Ringbomb"), 150, 1f);
		    				}
		    				}
		    				
					break;
				case 2:
							   proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("EggPlant2"), 40, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
			                   proj = Projectile.NewProjectile(npc.Center.X-200, npc.Center.Y, 0f, 0f, mod.ProjectileType("EggPlant2"), 40, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
			                   proj = Projectile.NewProjectile(npc.Center.X+200, npc.Center.Y, 0f, 0f, mod.ProjectileType("EggPlant2"), 40, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
			                   
			                   if (npc.life < npc.lifeMax * 0.5){
			                   
			                    for (int k = 0; k < 10; k++)
								{
								
								proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(1000) - 500), npc.Center.Y-750, Main.rand.Next(20) - 10, Main.rand.Next(20) - 10, mod.ProjectileType("EggPlantMeteor2"), 70, 1f);
								
								}
			                	}
			                   
					break;
                              
			}
		    
		    npc.ai[0] = 0;
		    
        }

        }

         public override void NPCLoot()
		{
		
			if(Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
			int item = 0;
			int choice = Main.rand.Next(3);
			switch (choice)
			{
				case 0:
			                item = mod.ItemType("TrueEternasuSword");
					break;
				case 1:
			                item = mod.ItemType("TrueEggplantRapier");
					break;
				case 2:
			                item = mod.ItemType("EggPlantMeteor");
					break;
                              
			}

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			
			item = mod.ItemType("EggPlantCrystal");
		
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 100);
			
			}
		}

	}

}
