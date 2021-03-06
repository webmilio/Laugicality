using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class SteamsparkJetboots : ModItem
    {
        Mod calMod = ModLoader.GetMod("CalamityMod");
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Steam powered! \nWearer can run super fast \nImmunity to lava, can walk on liquids \nIncreases flight time and flight acceleration if worn under wings");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = 100;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.waterWalk = true;
            player.buffImmune[24] = true;
            player.maxRunSpeed += 3.5f;
            player.moveSpeed += 1.75f;
            player.wingTimeMax += 180;
            player.jumpSpeedBoost += 3f;
        }

        public override void AddRecipes()
        {

            if (calMod != null)
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(calMod.ItemType("AngelTreads"), 1);
                recipe.AddIngredient(ItemID.Jetpack, 1);
                recipe.AddIngredient(null, "SteamBar", 15);
                recipe.AddIngredient(null, "Gear", 20);
                recipe.AddIngredient(null, "CogOfKnowledge", 1);
                recipe.AddIngredient(null, "SteamTank", 1);
                recipe.AddIngredient(null, "Pipeworks", 1);
                recipe.AddIngredient(null, "SoulOfThought", 5);
                recipe.AddIngredient(null, "SoulOfWrought", 5);
                recipe.AddIngredient(null, "SoulOfFraught", 5);
                recipe.AddTile(134);
                recipe.SetResult(this);
                recipe.AddRecipe();


                ModRecipe Srecipe = new ModRecipe(mod);
                Srecipe.AddRecipeGroup("WingsGroup");
                Srecipe.AddIngredient(null, "SteamsparkJetboots", 1);
                Srecipe.AddIngredient(calMod.ItemType("CoreofCalamity"), 3);
                Srecipe.AddIngredient(calMod.ItemType("BarofLife"), 5);
                Srecipe.AddIngredient(ItemID.LunarBar, 5);
                Srecipe.AddTile(TileID.LunarCraftingStation);
                Srecipe.SetResult(calMod.ItemType("InfinityBoots"));
                Srecipe.AddRecipe();

            }
            else
            {
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(ItemID.FrostsparkBoots, 1);
                recipe.AddIngredient(ItemID.LavaWaders, 1);
                recipe.AddIngredient(ItemID.Jetpack, 1);
                recipe.AddIngredient(null, "SteamBar", 15);
                recipe.AddIngredient(null, "Gear", 20);
                recipe.AddIngredient(null, "CogOfKnowledge", 1);
                recipe.AddIngredient(null, "SteamTank", 1);
                recipe.AddIngredient(null, "Pipeworks", 1);
                recipe.AddIngredient(null, "SoulOfThought", 5);
                recipe.AddIngredient(null, "SoulOfWrought", 5);
                recipe.AddIngredient(null, "SoulOfFraught", 5);
                recipe.AddTile(134);
                recipe.SetResult(this);
                recipe.AddRecipe();
            }
        }
    }
}