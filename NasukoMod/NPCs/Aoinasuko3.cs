using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace NasukoMod.NPCs
{

	public class Aoinasuko3 : ModNPC
	{

		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aoi Nasuko");
        }

		public override void SetDefaults()
		{
			npc.width = 64;
			npc.height = 80;
			npc.damage = 110;
			npc.defense = 1000;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 0.0f;
			npc.aiStyle = 2;
			npc.alpha = 100;
			npc.noTileCollide = true;
			Main.npcFrameCount[npc.type] = 2;
			animationType = 1;
			npc.dontTakeDamage = true;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}

		public override void AI()
		{
				NPC owner = Main.npc[(int)npc.ai[0]];
				if (!owner.active || owner.type != mod.NPCType("Aoinasuko"))
				{
				npc.active = false;
				return;
				}
                npc.ai[1] += 1;
                Player player = Main.player[npc.target];
                npc.position.Y = owner.position.Y - 100;
                npc.position.X = owner.position.X + 200;
        
        if (npc.ai[1] == 350)
		{
            int proj = 0;
				
								for (int k = 0; k < 10; k++)
								{
								
								proj = Projectile.NewProjectile(npc.Center.X + (Main.rand.Next(1000) - 500), npc.Center.Y-750, Main.rand.Next(20) - 10, Main.rand.Next(20) - 10, mod.ProjectileType("EggPlantMeteor2"), 70, 1f);
								
								}
	
		if (NPC.CountNPCS(mod.NPCType("Counstar2")) < 10)
		{
        	NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Counstar2"), 0, npc.whoAmI, 0, 0);
        }
	
		    npc.ai[1] = 0;
        }

        }

         public override void NPCLoot()
		{
		
			if(Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
		
			int item = 0;
		
			item = mod.ItemType("BlueEggPlantCrystal");

			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item);
			
			item = mod.ItemType("EggPlantCrystal");
		
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, item, 10);
			
			}
		}

	}

}
