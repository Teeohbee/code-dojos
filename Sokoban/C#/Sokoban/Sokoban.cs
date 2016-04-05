using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sokoban
{
    public class Sokoban
    {
        public List<string> Grid { get; set; }

        public const char Man = '@';
        public const char Crate = 'o';
        public const char Storage = '.';
        public const char CrateOnStorage = '*';
        public const char ManOnStorage = '+';



        public Sokoban(int x, int y)
        {
            Grid = new List<string>();
            Grid.Add(("#####"));
            Grid.Add(("#   #"));
            Grid.Add(("#####"));
        }

        public void PlaceMan(int x, int y)
        {
            Grid[y] = Grid[y].Remove(x, 1).Insert(x, Man.ToString());
        }

        public void Move(char c)
        {
            var positionOfMan = Grid[1].IndexOf(Man.ToString());

            Grid[1] = Grid[1].Remove(positionOfMan, 1).Insert(positionOfMan, " ");
            if (Grid[1][positionOfMan - 1] == Storage)
            {
                Grid[1] = Grid[1].Remove(positionOfMan - 1, 1).Insert(positionOfMan - 1, ManOnStorage.ToString());

            }
            if (Grid[1][positionOfMan - 1] == Crate)
            {
                if (Grid[1][positionOfMan - 2] == Storage)
                {
                    Grid[1] = Grid[1].Remove(positionOfMan - 2, 1).Insert(positionOfMan - 2, CrateOnStorage.ToString());
                }
                else
                {

                    Grid[1] = Grid[1].Remove(positionOfMan - 2, 1).Insert(positionOfMan - 2, Crate.ToString());
                }
            }
            Grid[1] = Grid[1].Remove(positionOfMan-1, 1).Insert(positionOfMan-1, Man.ToString());
        }

        public void PlaceCrate(int x, int y)
        {
            Grid[y] = Grid[y].Remove(x, 1).Insert(x, Crate.ToString());
        }

        public void PlaceStorage(int x, int y)
        {
            Grid[y] = Grid[y].Remove(x, 1).Insert(x, Storage.ToString());
        }
    }
}