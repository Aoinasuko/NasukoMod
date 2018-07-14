using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class TrueEternasuSword : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Eternasu Sword");
			Tooltip.SetDefault("Add 5% damage of maximum HP additionally." + "\nWhen you kill an enemy, You will not receive damage for a while." + "\n'Even if you have a lot of physical strength, it makes no sense.'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 80;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 6;
			item.useAnimation = 6;
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.value = Item.sellPrice(10, 0, 0, 0);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
		
		if(target.boss == false){
		
			target.StrikeNPC(target.lifeMax / 20, 0, 0);
		
		}else{
		
			target.StrikeNPC(target.lifeMax / 200, 0, 0);
		
		}
		
		if(target.life <= 0){
		
			player.immuneTime = 100;
            player.immune = true;
		
		}
		
		}

	}
}