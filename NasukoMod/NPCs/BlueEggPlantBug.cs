using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class BlueEggPlantBug : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blue EggPlant Bug");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

		public override void SetDefaults()
		{
			npc.width = 40;
			npc.height = 34;
			npc.damage = 12;
			npc.defense = 4;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 120f;
			npc.knockBackResist = 1.0f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
			animationType = NPCID.Zombie;
		}

        public override void NPCLoot()
		{
			int item = 0;
			
			if (Main.rand.Next(30) == 0)
			{
                item = mod.ItemType("CrackedEggPlantOrb");
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			}
                        if (Main.rand.Next(30) == 0)
			{
                item = mod.ItemType("RottenFlow");
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			}
			
			if (Main.rand.Next(50) == 0 && Main.expertMode)
			{
                item = mod.ItemType("SpeedBooster");
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			}
			
			item = mod.ItemType("EggPlantCrystal");
			
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 5);

		}


		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.raining || Main.LocalPlayer.GetModPlayer<NasuPlayer>().ZonenasuBiome){
			return 1.0f;
			}else{
			return 0.0f;
			}
		}



	}
}
