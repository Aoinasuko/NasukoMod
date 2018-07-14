using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class Nasuko : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nasuko Statue");
        }

		public override void SetDefaults()
		{
			npc.width = 100;
			npc.height = 165;
			npc.damage = 40;
			npc.defense = 2000;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.0f;
			npc.aiStyle = 0;
			npc.boss = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/EggPlantFairy");
			bossBag = mod.ItemType("NasukoBag");
		}

		public override void AI()
		{
		
		int k = 0;
		
		for (k = 0; k < 255; k++)
			{
				if (Main.player[k].active && !Main.player[k].dead)
				{
					break;
				}
			}
		
		if(k==255){
		
			npc.noTileCollide = true;
		
		}
                npc.ai[0] += 1;
                Player player = Main.player[npc.target];
        
        if (npc.ai[0] == 300)
		{
            
            int choice = Main.rand.Next(3);
                        switch (choice)
			{
				case 0:
				
							
							if (NPC.CountNPCS(mod.NPCType("BigEggPlantBug2")) < 6){
							
			                NPC.NewNPC((int)npc.Center.X-800, (int)npc.Center.Y-300, mod.NPCType("BigEggPlantBug2"), 0, npc.whoAmI, 0, 0);
			                NPC.NewNPC((int)npc.Center.X+800, (int)npc.Center.Y-300, mod.NPCType("BigEggPlantBug2"), 0, npc.whoAmI, 0, 0);
			                
			                }
			                
					break;
				case 1:
				
							if (NPC.CountNPCS(mod.NPCType("Counstar3")) < 12){
				
			                NPC.NewNPC((int)npc.Center.X-80, (int)npc.Center.Y-300, mod.NPCType("Counstar3"), 0, npc.whoAmI, 0, 0);
			                NPC.NewNPC((int)npc.Center.X-80, (int)npc.Center.Y+300, mod.NPCType("Counstar3"), 0, npc.whoAmI, 0, 0);
			                NPC.NewNPC((int)npc.Center.X+80, (int)npc.Center.Y-300, mod.NPCType("Counstar3"), 0, npc.whoAmI, 0, 0);
			                NPC.NewNPC((int)npc.Center.X+80, (int)npc.Center.Y+300, mod.NPCType("Counstar3"), 0, npc.whoAmI, 0, 0);
			                
			                }
			                
					break;
				case 2:
			               int proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(500) - 250), npc.Center.Y - 400, 0f, 5f, mod.ProjectileType("EggPlant3"), 30, 0f);
			                   proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(500) - 250), npc.Center.Y - 400, 0f, 5f, mod.ProjectileType("EggPlant3"), 30, 0f);
			                   proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(500) - 250), npc.Center.Y - 400, 0f, 5f, mod.ProjectileType("EggPlant3"), 30, 0f);
					break;
                              
			}
		    
		    npc.ai[0] = 0;
		    
        }

        if (npc.ai[2] == 0)
		{
			npc.position.X = player.Center.X;
			npc.position.Y = player.Center.Y - 300;
			npc.ai[2] = 1;
		}

		if (npc.life <= (npc.lifeMax/2) && npc.ai[1] == 0 && Main.expertMode)
        {
        			Main.PlaySound(29);
        			npc.ai[1] = 1;
        			NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y+300, mod.NPCType("BitterDra"), 0, npc.whoAmI, 0, 0);
        			
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
		
			item = mod.ItemType("BlueEggPlantCrystal");

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			
			item = mod.ItemType("EggPlantCrystal");
		
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 10);
			
			}
		}

	}

}
