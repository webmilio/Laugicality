using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Loot
{
    public class MagmaticCrystal : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 22;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.value = 0;
        }
        
    }
}