using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.NPCs
{
	public class NasuGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public bool Neutralization = false;

		public override void ResetEffects(NPC npc)
		{
			Neutralization = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (Neutralization)
			{
				npc.damage = 0;
			}
		}

	}
}
