using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class EggPlantZombie : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EggPlant Zombie");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

		public override void SetDefaults()
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 24;
			npc.defense = 10;
			npc.lifeMax = 80;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.2f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
			animationType = NPCID.Zombie;
		}

        public override void NPCLoot()
		{
		
            int item = 0;
            
			if (Main.rand.Next(20) == 0)
			{
                                item = mod.ItemType("CrackedEggPlantOrb");
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			}
                        if (Main.rand.Next(20) == 0)
			{
                                item = mod.ItemType("RottenFlow");
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			}
			
			item = mod.ItemType("EggPlantCrystal");
			
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 10);

		}


		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
		
			if(Main.LocalPlayer.GetModPlayer<NasuPlayer>().ZonenasuBiome){
			
				return 1.0f;
			
			}
		
			return SpawnCondition.OverworldNightMonster.Chance * 0.2f;
		}



	}
}
