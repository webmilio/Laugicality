using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Placeable.MusicBoxes
{
    public class RagnarMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Ragnar)");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 1;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = mod.TileType("RagnarMusicBox");
            item.accessory = true;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(null, "LaugicalWorkbench");
            recipe.AddIngredient(1225, 20);
            recipe.AddIngredient(1006, 8);
            recipe.AddIngredient(2766, 8);
            recipe.AddIngredient(1508, 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}