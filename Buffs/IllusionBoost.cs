using Terraria;
using Terraria.ModLoader;
using Laugicality.NPCs;

namespace Laugicality.Buffs
{
	public class IllusionBoost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Illusion Power");
			Description.SetDefault("'The mind's energy strengthens you.'\n+100% Mystic Duration");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<LaugicalityPlayer>(mod).mysticDuration += 1f;
        }
        
	}
}
