using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    enum backgroundType { Road, NotRoad, Water };

    public class Map
    {
        
        backgroundType[,] mask;

        public Map(Texture2D texture)
        {
            Color[] c = new Color[texture.Width * texture.Height];
            texture.GetData<Color>(c);

            this.mask = new backgroundType[texture.Height, texture.Width];

            Color temp;

            for (int x = 0; x < texture.Height; x++)
            {
                for (int y = 0; y < texture.Width; y++)
                {
                    temp = c[x * texture.Width + y];

                    //road
                    if (temp == Color.Black)
                    {
                        this.mask[x, y] = backgroundType.Road;
                        Console.Write("+");
                    }
                    if (temp == Color.White)
                    {
                        this.mask[x, y] = backgroundType.NotRoad;
                        Console.Write("-");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
