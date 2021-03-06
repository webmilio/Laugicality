using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MagmaticLongcoat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Immunity to lava, 'On Fire!', and 'Burning'\n+10% Throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 22;
			item.value = 10000;
			item.rare = 3;
			item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            player.thrownCrit += 10;
        }
        

		public override void AddRecipes()
		{
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ObsidiumLongcoat", 1);
            recipe.AddRecipeGroup("TitaniumBars", 18);
            recipe.AddIngredient(null, "MagmaticCrystal", 3);
            recipe.AddIngredient(null, "MagmaticCluster", 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}