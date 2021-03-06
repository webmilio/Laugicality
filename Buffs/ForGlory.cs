using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class ForGlory : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("For Glory");
			Description.SetDefault("+15% Damage \nNo life Regen");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			//player.GetModPlayer<LaugicalityPlayer>(mod).mysticDamage += 0.15f;
            player.bleed = true;
            player.thrownDamage += 0.15f;
            player.rangedDamage += 0.15f;
            player.magicDamage += 0.15f;
            player.minionDamage += 0.15f;
            player.meleeDamage += 0.15f;
        }
        
	}
}
