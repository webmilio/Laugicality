using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class BysmalDrill : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 34;
			projectile.height = 82;
			projectile.scale = 1.25f;
			projectile.aiStyle = 20;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            float mag = 14f;
            Player player = Main.player[projectile.owner];
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            float mag = 14f;
            Player player = Main.player[projectile.owner];
            player.velocity = mag * player.DirectionTo(Main.MouseWorld);
        }
    }
}