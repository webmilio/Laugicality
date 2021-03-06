using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Equipables
{
    public class SupremeNinjaEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% throwing damage");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.value = 100;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.thrownDamage += .2f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NinjaEmblem", 1);
            recipe.AddIngredient(null, "EtherialEssence", 5);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}