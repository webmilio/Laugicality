﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Laugicality;

namespace Laugicality.Structures
{
    public class LivingLycoris
    {
        private static readonly int[,] StructureArray = new int[,]
        {
                {0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0}
,                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0}
,                {0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1}
,                {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,0,0,0}
,                {0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,0,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,0,0}
,                {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0}
,                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
,                {0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1,1,1}
,                {0,0,0,0,0,0,2,2,2,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1}
,                {0,0,0,0,0,0,0,2,2,2,0,0,0,1,1,1,1,2,2,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,2,2,2,2,0,1,2,2,2,9,9,2,1,1,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,9,9,9,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,2,2,9,9,9,9,9,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,0,2,2,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,0,0,2,2,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,2,2,0,0,2,2,0,0,0,0,1,1,1,1,1,1,1,1,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,2,2,0,0,2,2,2,0,0,1,1,2,2,2,1,1,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,9,2,2,2,0,0,2,2,2,2,2,2,2,1,1,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,9,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,9,9,9,9,9,9,2,2,2,2,0,0,2,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,9,9,9,9,9,9,9,2,2,0,2,2,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,9,9,9,9,9,2,2,2,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,9,2,2,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,0,0,0,2,2,9,9,9,2,2,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,2,2,2,9,9,9,9,2,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,2,2,9,9,9,9,9,2,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,9,9,9,3,9,2,2,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,9,9,9,2,2,2,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0}
,                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0}

        };

        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 1 = Lycoris
             * 2 = Radiata
             * 3 = Obsidium Chest
             * 9 = Kill tile
             * */
            

            for (int i = 0; i < StructureArray.GetLength(1); i++)
            {
                for (int j = 0; j < StructureArray.GetLength(0); j++)
                {
                    if (mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + StructureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("Lycoris"), true, true);
                            }
                            if (StructureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("Radiata"), true, true);
                            }
                            if (StructureArray[j, i] == 3)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + StructureArray.GetLength(1) - i, yPosO + j, (ushort)Laugicality.instance.TileType("Radiata"));
                            }
                            if (StructureArray[j, i] == 9)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                            }
                        }
                    }
                    else
                    {
                        if (TileCheckSafe((int)(xPosO + i), (int)(yPosO + j)))
                        {
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("Lycoris"), true, true);
                            }
                            if (StructureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("Radiata"), true, true);
                            }
                            if (StructureArray[j, i] == 3)
                            {
                                LaugicalityWorld.PlaceObsidiumChest(xPosO + i, yPosO + j, (ushort)Laugicality.instance.TileType("Radiata"));
                            }
                            if (StructureArray[j, i] == 9)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                            }
                        }
                    }
                }
            }
        }
        
        //Making sure tiles arent out of bounds
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 1 && i < Main.maxTilesX - 1 && j > 1 && j < Main.maxTilesY - 1)
            {
                if(LaugicalityVars.ObsidiumTiles.Contains(Main.tile[i, j].type))
                    return true;
            }
            return false;
        }
    }
}