using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class BitterDragon2 : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bitter Dragon");
        }

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 145;
			npc.damage = 20;
			npc.defense = 0;
			npc.lifeMax = 100;
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
        
        if (npc.ai[0] >= 300 && npc.ai[0] <= 360)
		{
            npc.velocity.Y = 0;
            
            if(npc.velocity.X > 0f){
			npc.velocity.X = 8f;
                }
			if(npc.velocity.X < 0f){
			npc.velocity.X = -8f;
                }
        }
        
        }
        }

}
