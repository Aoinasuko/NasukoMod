using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class BitterDragon : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bitter Dragon");
        }

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 145;
			npc.damage = 28;
			npc.defense = 10;
			npc.lifeMax = 5200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.boss = true;
            npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = 60f;
			npc.knockBackResist = 0.0f;
			npc.aiStyle = 2;
			Main.npcFrameCount[npc.type] = 2;
            animationType = 1;
            bossBag = mod.ItemType("BitterDragonBag");
		}

		public override void AI()
		{
                npc.ai[0] += 1;
                Player player = Main.player[npc.target];
        
        if (npc.ai[0] >= 100 && npc.ai[0] <= 120)
		{
		
			Main.PlaySound(27);
			
            npc.velocity.Y = 0;
            
            if(npc.velocity.X > 0f){
			npc.velocity.X = 8f;
                }
			if(npc.velocity.X < 0f){
			npc.velocity.X = -8f;
                }
            
            if (npc.ai[0] % 10 == 0){
		    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Chocoratemarshmallow"), 0, npc.whoAmI, 0, 0);
            }
        }
        
      
        if (npc.ai[0] >= 170 && npc.ai[0] <= 210)
		{
            npc.velocity.Y = 0;
            npc.velocity.X = 0;
            
        }
        
        if (npc.ai[0] == 200 && Main.expertMode && NPC.CountNPCS(mod.NPCType("BitterDragon2")) < 5)
		{
        	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("BitterDragon2"), 0, npc.whoAmI, 0, 0);
        }
        
        if (npc.ai[0] == 220)
		{
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
                        int choice = Main.rand.Next(2);
                        switch (choice)
			{
				case 0:
			                item = mod.ItemType("Thefoam");
					break;
				case 1:
			                item = mod.ItemType("TheTyphoon");
					break;
                              
			}

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			
			item = mod.ItemType("EggPlantCrystal");
		
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 10);
			
			}
		}

	}

}
