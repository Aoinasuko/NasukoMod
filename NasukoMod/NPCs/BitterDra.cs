using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class BitterDra : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bitter Dra");
        }

		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 116;
			npc.damage = 32;
			npc.defense = 30;
			npc.lifeMax = 3500;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = 60f;
			npc.knockBackResist = 0.0f;
			npc.aiStyle = 2;
			Main.npcFrameCount[npc.type] = 2;
            animationType = 1;
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
            
            if (npc.ai[0] % 15 == 0){
		    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Chocoratemarshmallow"), 0, npc.whoAmI, 0, 0);
            }
        }
        
      
        if (npc.ai[0] >= 170 && npc.ai[0] <= 210)
		{
            npc.velocity.Y = 0;
            npc.velocity.X = 0;
            
        }
        
        if (npc.ai[0] == 220)
		{
        	npc.ai[0] = 0;
        }
        
        }

        public override void NPCLoot()
		{
			
			int item = 0;
			
			item = mod.ItemType("EggPlantCrystal");
		
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 20);

		}

	}

}
