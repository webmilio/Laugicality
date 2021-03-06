using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Projectiles
{
	public class BrassArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Arrow");     
		}
        
        public override void SetDefaults()
        {
            projectile.width = 18;               
			projectile.height = 18;              
			projectile.aiStyle = 1;             
			projectile.friendly = true;         
			projectile.hostile = false;         
			projectile.ranged = true;           
			projectile.penetrate = 3;           
			projectile.timeLeft = 600;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = true;          
			//aiType = 1;           
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            projectile.penetrate--;
            Vector2 targetPos;
            targetPos.X = Main.MouseWorld.X;
            targetPos.Y = Main.MouseWorld.Y;
            projectile.velocity = projectile.DirectionTo(targetPos) * 22f;

            return false;
		}
        

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Vector2 targetPos;
            targetPos.X = Main.MouseWorld.X;
            targetPos.Y = Main.MouseWorld.Y;
            projectile.velocity = projectile.DirectionTo(targetPos) * 22f;
        }
    }
}
