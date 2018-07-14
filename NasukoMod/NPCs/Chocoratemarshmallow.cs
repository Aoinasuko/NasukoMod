using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{
	public class Chocoratemarshmallow : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chocorate marsh mallow");
        }

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 30;
			npc.damage = 50;
			npc.defense = 0;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.knockBackResist = 0.0f;
		}
		
		public override void AI()
		{
        npc.ai[0] += 1;
        Player player = Main.player[npc.target];
        
        if (npc.ai[0] >= 200)
		{
					npc.life -= 1000;
					int shoot = mod.ProjectileType("choco");
					int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 4, 0, shoot, 25, 6, Main.myPlayer, 0f, 0f);
						proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -4, 0, shoot, 25, 6, Main.myPlayer, 0f, 0f);
						Main.PlaySound(6);
        }
        
        }
		
		public override void NPCLoot()
		{
			int item = 0;
			
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 967, 3);

		}
		
	}
}
