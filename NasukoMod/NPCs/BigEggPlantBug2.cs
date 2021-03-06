using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class BigEggPlantBug2 : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EggPlant Bug");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 68;
			npc.damage = 28;
			npc.defense = 10;
			npc.lifeMax = 300;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 90f;
			npc.knockBackResist = 1.0f;
			npc.aiStyle = 26;
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
			
			item = mod.ItemType("EggPlantCrystal");
			
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 2);

		}

	}
}
