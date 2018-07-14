using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items.Weapons
{
	public class SpeedBooster : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("EggPlant Speed Booster");
			Tooltip.SetDefault("'Dush! Dush!'");
		}
	
		public override void SetDefaults()
		{
			item.damage = 6;
			item.magic = true;
			item.mana = 7;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 9;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shootSpeed = 16f;
			item.value = Item.sellPrice(0, 20, 0, 0);
			item.shoot = mod.ProjectileType("Pixie6");
			item.expert = true;
		}
                
         public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
        player.velocity.X += (speedX / 5f);
                if(player.velocity.X > 15f){
			player.velocity.X = 15f;
                }
		if(player.velocity.X < -15f){
			player.velocity.X = -15f;
                }
			return true;
			}

	}
}