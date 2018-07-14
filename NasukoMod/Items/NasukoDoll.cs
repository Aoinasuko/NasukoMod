using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class NasukoDoll : ModItem
	{
	
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nasuko Doll");
			Tooltip.SetDefault("+60 max mana." + "\nYou gain regeneration when life is 200 or less.");
		}
	
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 10000;
			item.useAnimation = 6;
			item.useTime = 6;
			item.useStyle = 2;
			item.UseSound = SoundID.Item44;
			item.accessory = true;
			item.defense = 10;
			item.rare = 11;
			item.expert = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
                     player.statManaMax2 += 60;
                     if(player.statLife <= 200){
                     player.lifeRegen += 20;
                     player.manaRegen += 20;
                     }
		}

	}
}