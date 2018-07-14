using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NasukoMod.Items
{
	//imported from my tAPI mod because I'm lazy
	public class NasukoOrb : ModItem
	{
	
			public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue EggPlant Wedge");
			Tooltip.SetDefault("Summon Boss.");
		}
	
		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.rare = 8;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}
		
		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Nasuko"));
			return true;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null,"EggPlantCrystal", 100);
                recipe.SetResult(this);
                recipe.AddRecipe();
        }

	}
}