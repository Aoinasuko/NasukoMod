using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace NasukoMod.Tiles
{
	public class EggplantDirt : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			drop = mod.ItemType("EggplantDirt");
			AddMapEntry(new Color(150, 30, 150));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.2f;
			g = 0.0f;
			b = 0.2f;
		}
		
	}
}