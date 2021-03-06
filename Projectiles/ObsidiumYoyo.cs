﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class ObsidiumYoyo : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 240f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}

        public Vector2 getPosition()
        {
            return projectile.position;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 80);      //Add Onfire buff to the NPC for 1 second
        }
    }
}
