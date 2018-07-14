
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace NasukoMod.NPCs
{
    [AutoloadHead]
    class Blueeggplantfairy : ModNPC
    {
    
    
    	public static bool Shop1 = true;
		public static bool Shop2 = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BlueEggplantFairy");
      
        }

        public override void SetDefaults()
        {
            npc.width = 27;
            npc.height = 47;
            npc.townNPC = true; //This defines if the npc is a town Npc or not
            npc.friendly = true;  //this defines if the npc can hur you or not()
            npc.defense = 9999;
            npc.lifeMax = 200;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.0f;
            Main.npcFrameCount[npc.type] = 3;
            animationType = NPCID.Zombie;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = 7;

        }
        
        public override string TownNPCName()
		{
			return "Nasuko";
			
		}
        
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("BlueEggPlantCrystal"))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override string GetChat()
		{
		
			if(Main.bloodMoon){
				return "Tonight is Blood Moon. How about unholy items? Nasunasu...";
			}
		
			switch (Main.rand.Next(7))
			{
				case 0:
					return "That? Where did my clothes go?";
				case 1:
					return "I am a Blue Eggplant Fairy. Is there something I want?";
				case 2:
					return "Leave it to me if you are an accessory!";
				case 3:
					return "The guide of this world is a nice person ...In the meaning that there is a frenzy.";
				case 4:
					return "If you bring EggPlant Crystal, I will exchange it for something useful.";
				case 5:
					return "I have fun stuff in various worlds.";
				default:
					return "Nasunasu?";
			}
		}

        public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window.
        {
        
        	if(Shop1){
        	 button = "Nasuko Shop";   //this defines the buy button name
        	}else{
        	 button = "Fairy Tinker Shop";   //this defines the buy button name
        	}
        
            button2 = "Change Shop";   //this defines the buy button name
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool openShop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
        {

            if (firstButton)
            {
                openShop = true;   //so when you click on buy button opens the shop
            }else{
            
            if(Shop1){
            	Shop2 = true;
				Shop1 = false;
            }else{
            
            	Shop1 = true;
            	Shop2 = false;
            
            }
            
            }
            
        }
        public override void SetupShop(Chest shop, ref int nextSlot)       //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
        {
           
           if(Shop1){
           shop.item[nextSlot].SetDefaults(mod.ItemType("Acornbaitofnasuko"));  //an example of how to add a vanilla terraria item
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("NasukoFishingPole"));  //an example of how to add a vanilla terraria item
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("AeroflakSentinel"));
           nextSlot++;
           if(Main.hardMode){
           shop.item[nextSlot].SetDefaults(mod.ItemType("AeroflakGuardian"));
           nextSlot++;
           }
           shop.item[nextSlot].SetDefaults(mod.ItemType("UndyneSpear"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("CaveMachinegun"));
           if(Main.hardMode){
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("Bubburin"));
           if(NPC.downedPlantBoss){
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("BowofVinderre"));
           }
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("Legcea"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("IceaArrow"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("IceaAmmo"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("Zoneofsafe"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("BlueEggPlantCrystal"));
           if(NPC.downedPlantBoss){
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("EternasuSword"));
           }
           if(Main.expertMode){
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("ChocolateWings"));
           }
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("EggPlantHat"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("RedEggPlantHat"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("BlueEggPlantHat"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("EggPlantCoverings"));
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("EggPlantLoincloth"));
           
           if(Main.bloodMoon){
           
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("MiserableShotgun"));
           if(Main.hardMode){
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("MiserableMaker"));
           }
           
           }
           
           if((DateTime.Today.Month == 2 && (DateTime.Today.Day >= 10 || DateTime.Today.Day <= 16)) || NPC.downedMoonlord){
           
           nextSlot++;
           shop.item[nextSlot].SetDefaults(mod.ItemType("SweeetChocolate"));
           
           }
           
           }
           }
           
           if(Shop2){
           		shop.item[nextSlot].SetDefaults(54);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(950);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(285);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(100);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(212);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(100);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(906);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(976);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(158);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(53);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(100);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(159);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(100);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3310);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(897);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		 if(Main.hardMode){
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3334);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		}
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(156);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		if(Main.hardMode){
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3034);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(999);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(855);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(999);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(854);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(999);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(485);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(500);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(497);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(500);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(900);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(500);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(1612);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(500);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		}
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(49);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(100);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(111);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(2219);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3102);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3099);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3119);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3095);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3118);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(3084);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(300);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           		nextSlot++;
           		shop.item[nextSlot].SetDefaults(50);//何売るか
           		shop.item[nextSlot].shopCustomPrice = new int?(200);//プレイヤーが渡すアイテムの個数
           		shop.item[nextSlot].shopSpecialCurrency = NasukoMod.EggPlantCrystalID;//プレイヤーが渡すアイテム
           }

         }


    }

    }

