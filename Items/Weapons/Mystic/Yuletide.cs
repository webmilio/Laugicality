using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader.IO;
using Laugicality;

namespace Laugicality.Items.Weapons.Mystic
{
	public class Yuletide : MysticItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yuletide");
            Tooltip.SetDefault("'Holiday Cheer'\nIllusion inflicts 'Frostburn'\nFires different projectiles based on Mysticism");
			Item.staff[item.type] = true;
		}

		public override void SetMysticDefaults()
		{
			item.damage = 32;
            item.width = 48;
			item.height = 48;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Nothing");
			item.shootSpeed = 6f;
		}


        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>(mod);
            if (modPlayer.mysticMode == 3)
            {
                for(int i = 0; i < 3; i++)
                {
                    if(Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile((int)(Main.MouseWorld.X) - 8 + Main.rand.Next(0, 16), (int)(Main.MouseWorld.Y) - 360 - 8 + Main.rand.Next(0, 16), 0, 0, mod.ProjectileType("YuleConjuration"), (int)(item.damage), 3, Main.myPlayer);
                }
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            item.damage = 30;
            item.useTime = 12;
            item.useAnimation = item.useTime;
            item.knockBack = 2;
            item.shootSpeed = 10;
            item.shoot = mod.ProjectileType("YuleDestruction");
            luxCost = 4;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            item.damage = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.knockBack = 1;
            item.shootSpeed = 8f;
            item.shoot = mod.ProjectileType("YuleIllusion");
            visCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            item.damage = 36;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 5;
            item.shootSpeed = 2f;
            item.shoot = mod.ProjectileType("Nothing");
            mundusCost = 4;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(null, "FrostShard", 1);
            recipe.AddIngredient(null, "ChilledBar", 6);
            recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}