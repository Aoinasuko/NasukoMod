using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class EggPlantFairy2 : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("EggPlant Fairy");
        }

		public override void SetDefaults()
		{
			npc.width = 72;
			npc.height = 120;
			npc.damage = 40;
			npc.defense = 20;
			npc.lifeMax = 350;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.noGravity = true;
			npc.noTileCollide = true;
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 2;
		}

		public override void AI()
		{
        npc.ai[0] += 1;
        Player player = Main.player[npc.target];
        
        if (npc.ai[0] == 150 || (Main.expertMode && npc.ai[0] >= 100 && npc.ai[0] % 25 == 0)){
			int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("EggPlantMeteor"), 75, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
		}
        
        if (npc.ai[0] == 200)
		{
        	npc.ai[0] = 0;
        }
        
        }
	}
}
