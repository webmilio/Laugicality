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
    public class LycorisCave
    {
        private static readonly int[,] StructureArray = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,9,9,5,5,1,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,9,9,1,1,1,1},
            {0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,9,9,5,5,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,9,9,9,9,9,1,1,0},
            {0,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,9,9,9,5,5,9,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,9,9,9,9,9,9,1,1,0},
            {1,1,1,1,1,1,1,9,1,1,1,1,1,9,9,9,9,5,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,9,9,9,5,5,9,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,9,9,9,9,9,9,9,1,0},
            {0,1,1,1,1,9,9,9,9,9,1,1,9,9,9,9,9,5,5,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,9,9,9,9,5,5,9,9,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,9,9,9,9,9,9,9,9,1,0},
            {0,1,1,1,9,9,9,9,9,9,1,1,9,9,9,9,9,5,5,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,9,9,9,9,5,5,9,9,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,9,9,9,9,9,9,9,0,0,0},
            {0,0,1,9,9,9,9,9,9,9,1,1,9,9,9,9,9,5,5,5,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,0,0,0},
            {0,0,1,9,9,9,9,9,9,9,1,9,9,9,9,9,9,5,5,5,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,0,0,0},
            {0,0,1,9,9,9,9,9,9,9,1,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,9,9,9,9,9,9,9,9,9,0,0,0,0},
            {0,0,0,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,0,0,0,0},
            {0,0,0,0,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,1,9,9,0,0,0,0},
            {0,0,0,0,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,9,9,0,0,0},
            {0,0,0,0,0,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,9,9,0,0},
            {0,0,0,0,0,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,9,9,0,0},
            {0,0,0,0,0,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,0,0},
            {0,0,0,0,0,9,9,9,9,1,1,1,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1,1,0},
            {0,0,0,0,9,9,1,1,1,1,1,1,1,1,1,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,9,9,9,2,2,2,2,2,2,2,2,2,2,9,9,9,9,1,1,1,1,1,1,1},
            {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,2,2,2,2,2,2,3,3,2,2,2,3,3,9,9,9,9,9,1,1,1,1,1,1},
            {0,0,0,1,1,1,1,1,1,1,1,1,1,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,5,5,9,9,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,9,9,9,9,9,9,9,9,1,1,1,1,1},
            {0,0,0,1,1,1,1,1,1,1,9,9,9,9,9,9,9,5,5,5,9,9,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,9,9,5,5,9,9,3,2,2,2,3,3,3,3,3,3,3,2,2,2,3,3,9,9,9,9,9,9,9,9,9,1,1,1,1,1},
            {0,0,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,2,2,2,3,3,2,2,3,3,2,2,2,2,3,3,9,9,9,5,5,9,9,9,3,3,3,3,2,3,3,3,3,3,3,3,3,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1},
            {0,0,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,3,3,3,3,3,3,2,3,3,3,3,3,9,9,9,9,9,5,5,9,9,9,9,9,3,3,3,2,2,3,3,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,1},
            {0,0,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,3,3,2,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,2,2,3,2,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9,1,1,1,1,0},
            {0,0,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,5,5,5,9,9,9,9,9,9,9,9,2,3,2,9,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,2,3,3,2,2,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,1,1,0},
            {0,0,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,2,3,2,2,9,9,9,9,9,9,9,9,5,5,9,9,9,9,9,9,9,9,2,3,3,2,2,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,1,0,0},
            {0,0,1,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,2,3,3,2,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,2,1,3,1,2,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,0,0,0},
            {0,0,0,1,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,1,3,3,3,3,3,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,1,1,3,3,1,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,1,0,0,0},
            {0,0,0,1,1,1,1,1,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,1,1,3,3,3,3,1,3,3,1,1,4,4,4,4,4,4,4,4,4,4,4,4,1,1,1,1,1,3,3,3,3,1,4,4,4,4,4,4,4,4,1,1,1,1,1,1,1,0,0,0},
            {0,0,0,0,1,1,1,1,1,1,4,4,4,4,4,4,4,4,4,4,1,1,1,1,3,3,1,1,3,1,1,3,3,3,1,1,1,1,4,4,4,4,4,4,1,1,1,1,3,3,3,3,1,1,3,3,1,1,1,1,4,4,1,1,1,1,1,1,1,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,1,1,1,1,1,4,4,4,4,4,1,1,1,1,1,1,1,1,1,1,3,3,1,1,1,3,3,3,3,1,1,1,1,1,1,1,1,1,1,3,3,1,3,3,3,1,1,3,3,3,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,3,1,1,1,1,1,3,3,1,1,1,1,1,1,1,1,3,3,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,3,1,1,1,1,1,3,3,1,1,1,1,1,1,1,1,3,3,1,1,1,1,3,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,3,3,0,0,1,1,1,1,1,1,1,1,1,1,1,1,3,1,1,0,0,0,3,3,3,3,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0},

        };

        public static void StructureGen(int xPosO, int yPosO, bool mirrored)
        {
            //Obsidium Heart
            /**
             * 0 = Do Nothing
             * 1 = Obsidium Rock
             * 2 = Lycoris
             * 3 = Radiata
             * 4 = Lava
             * 5 = Lavafall
             * 9 = Kill tile
             * */
            

            for (int i = 0; i < StructureArray.GetLength(1); i++)
            {
                for (int j = 0; j < StructureArray.GetLength(0); j++)
                {
                    if(mirrored)
                    {
                        if (TileCheckSafe((int)(xPosO + StructureArray.GetLength(1) - i), (int)(yPosO + j)))
                        {
                            if (StructureArray[j, i] == 1)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("ObsidiumRock"), true, true);
                            }
                            if (StructureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("Lycoris"), true, true);
                            }
                            if (StructureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j, Laugicality.instance.TileType("Radiata"), true, true);
                            }
                            if (StructureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                Main.tile[xPosO + StructureArray.GetLength(1) - i, yPosO + j].lava(true);
                                Main.tile[xPosO + StructureArray.GetLength(1) - i, yPosO + j].liquid = 255;
                            }
                            if (StructureArray[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.KillWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + StructureArray.GetLength(1) - i, yPosO + j, 137, true); //Lavafall Wall
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
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("ObsidiumRock"), true, true);
                            }
                            if (StructureArray[j, i] == 2)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("Lycoris"), true, true);
                            }
                            if (StructureArray[j, i] == 3)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.PlaceTile(xPosO + i, yPosO + j, Laugicality.instance.TileType("Radiata"), true, true);
                            }
                            if (StructureArray[j, i] == 4)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                Main.tile[xPosO + i, yPosO + j].lava(true);
                                Main.tile[xPosO + i, yPosO + j].liquid = 255;
                            }
                            if (StructureArray[j, i] == 5)
                            {
                                WorldGen.KillTile(xPosO + i, yPosO + j);
                                WorldGen.KillWall(xPosO + i, yPosO + j);
                                WorldGen.PlaceWall(xPosO + i, yPosO + j, 137, true); //Lavafall Wall
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
            if (i > 0 && i < Main.maxTilesX && j > 0 && j < Main.maxTilesY)
                return true;
            return false;
        }
    }
}