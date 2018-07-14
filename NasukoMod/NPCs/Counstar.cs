using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class Counstar : ModNPC
	{
	
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Counstar");
        }

		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 30;
			npc.damage = 18;
			npc.defense = 999;
			npc.lifeMax = 8;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 1.3f;
			npc.aiStyle = 2;
			aiType = NPCID.Pixie;
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
			
			item = mod.ItemType("EggPlantCrystal");
		
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 10);
			
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (Main.LocalPlayer.GetModPlayer<NasuPlayer>().ZonenasuBiome){
			return 1.0f;
			}else{
			return 0.0f;
			}
		}

	}
}
