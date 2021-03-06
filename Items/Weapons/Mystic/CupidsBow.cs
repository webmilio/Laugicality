using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Laugicality.Items.Weapons.Mystic
{
	public class CupidsBow : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cupid's Bow");
            Tooltip.SetDefault("'Make them fall for you' \nArrows inflict 'Lovestruck', which makes enemies drop Hearts on death" +
                "\nFires different projectiles based on Mysticism\nThe amount of angels that can be conjured is based on Mystic Duration");
        }
        
        public override void SetMysticDefaults()
		{
			item.damage = 40;
            item.width = 44;
			item.height = 74;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 6f;
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;

            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 3)
            {
                for (int p = 0; p < 1000; p++)
                {
                    if (Main.projectile[p].type == mod.ProjectileType("CupidConjurationAngel"))
                    {
                        if (player.ownedProjectileCounts[mod.ProjectileType("CupidConjurationAngel")] >= modPlayer.mysticDuration * 4)
                        {
                            Main.projectile[p].Kill();
                            break;
                        }
                    }
                }
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 1;
            item.damage = 48;
            item.useTime = 18;
            item.useAnimation = item.useTime;
            item.knockBack = 4;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("CupidDestruction");
            item.noUseGraphic = true;
            luxCost = 4;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 42;
            item.useTime = 16;
            item.useAnimation = item.useTime;
            item.knockBack = 1;
            item.shootSpeed = 12f;
            item.shoot = mod.ProjectileType("CupidIllusion");
            item.noUseGraphic = false;
            visCost = 5;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.useStyle = 5;
            item.damage = 35;
            item.useTime = 20;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 0f;
            item.shoot = mod.ProjectileType("CupidConjurationAngel");
            item.noUseGraphic = false;
            mundusCost = 24;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 24);
            recipe.AddRecipeGroup("SilverBars", 8);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(null, "SoulOfSought", 4);
            recipe.AddIngredient(ItemID.CrystalShard, 4);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
        }
    }
}