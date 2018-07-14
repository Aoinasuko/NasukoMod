using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class EggPlantFairy : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EggPlant Fairy");
        }

		public override void SetDefaults()
		{
			npc.width = 72;
			npc.height = 120;
			npc.damage = 65;
			npc.defense = 50;
			npc.lifeMax = 95000;
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
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/EGOPlantoon");
			musicPriority = MusicPriority.BossMedium; // By default, musicPriority is BossLow
            bossBag = mod.ItemType("EggPlantFairyBag");
		}

		public override void AI()
		{
        npc.ai[0] += 1;
        Player player = Main.player[npc.target];
        
        if (npc.ai[0] >= 100 && npc.ai[0] <= 120)
		{
		
			Main.PlaySound(29);
			
            npc.velocity.Y = 0;
            
            if(npc.velocity.X > 0f){
			npc.velocity.X = 8f;
                }
			if(npc.velocity.X < 0f){
			npc.velocity.X = -8f;
                }
            if (npc.ai[0] % 15 == 0 && NPC.CountNPCS(mod.NPCType("Counstar2")) < 12){
		    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Counstar2"), 0, npc.whoAmI, 0, 0);
            }
            
        }
        
        if (npc.ai[0] >= 190 && npc.ai[0] <= 290 && npc.ai[0] % 25 == 0){
			int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("EggPlant"), 40, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
		}
        
        if (npc.ai[0] >= 170 && npc.ai[0] <= 300)
		{
            npc.velocity.Y = 0;
            npc.velocity.X = 0;
        }
        
        if (npc.ai[0] == 290 && NPC.CountNPCS(mod.NPCType("EggPlantFairy2")) < 5)
		{
        	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("EggPlantFairy2"), 0, npc.whoAmI, 0, 0);
        }
        
        if (npc.ai[0] == 300)
		{
        	npc.ai[0] = 0;
        }
        
        }

        public override void NPCLoot()
		{
		
			int item = 0;
		
			if(Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
			
			item = mod.ItemType("HeartOrb");
			
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			
			}
		}

	}

}
