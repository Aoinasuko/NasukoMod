using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class Counstar3 : ModNPC
	{
	
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Counstar");
        }

		public override void SetDefaults()
		{
			npc.width = 30;
			npc.height = 30;
			npc.damage = 30;
			npc.defense = 999;
			npc.lifeMax = 3;
			npc.HitSound = SoundID.NPCHit5;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 1.3f;
			npc.aiStyle = 2;
			npc.noGravity = true;
			npc.noTileCollide = true;
			aiType = NPCID.Pixie;
		}
	}
}
