using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class MegaEggPlantBug : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega EggPlant Bug");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

		public override void SetDefaults()
		{
			npc.width = 350;
			npc.height = 281;
			npc.damage = 0;
			npc.defense = 0;
			npc.lifeMax = 10000000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 90f;
			npc.knockBackResist = 0.0f;
			npc.aiStyle = 26;
			npc.boss = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/EggPlantFairy");
		}

		public override void AI()
		{

		 npc.ai[1] += 1;
		 
		 if(npc.ai[1] >= 6500){
		 		Main.NewText("Total damage:" + (npc.lifeMax - npc.life), 150, 250, 150);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EggPlantCrystal"), ((npc.lifeMax*2)/npc.life)*10);
				
				for (int i = 0; i < npc.lifeMax/(npc.lifeMax-npc.life)*3; i++)
				{
				Item.NewItem((int)npc.position.X+(Main.rand.Next(1000)-500), (int)npc.position.Y+100, npc.width, npc.height, 73, 10);
				}
				
				if(npc.life < npc.lifeMax*0.5){
					Item.NewItem((int)npc.position.X+(Main.rand.Next(1000)-500), (int)npc.position.Y+100, npc.width, npc.height, 74, 10);
				}
				
				if(npc.life < npc.lifeMax*0.3){
					Item.NewItem((int)npc.position.X+(Main.rand.Next(1000)-500), (int)npc.position.Y+100, npc.width, npc.height, 74, 30);
				}
				
				if(npc.life < npc.lifeMax*0.1){
					Item.NewItem((int)npc.position.X+(Main.rand.Next(1000)-500), (int)npc.position.Y+100, npc.width, npc.height, 74, 50);
				}
				
				npc.StrikeNPC(npc.lifeMax, 0, 0);
			}
		
		if(npc.life < npc.lifeMax*0.05){
		
		npc.life = npc.lifeMax/20;
		
		}
		
		}
		
	}
}
