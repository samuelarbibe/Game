using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    public interface IFocus
    {
        Vector2 position { get; }
        float rotation { get; }
    }

    public class Camera
    {
        Viewport vp;
        List<IFocus> focus;
        Vector2 pos;
        float rotation;
        float zoom;
        float maxZoom;
        float minZoom;

        public Camera(Viewport vp, List<IFocus> focus, Vector2 position, float zoom)
        {
            this.vp = vp;
            this.focus = focus;
            this.pos = position;
            this.zoom = zoom;
            this.maxZoom = 20f;
            this.minZoom = 0.1f;
        }

        public Matrix GetMatrix()
        {
            int count = 0;
            float maxDist = 0f;
            Vector2 sum = new Vector2();

            for(count = 0; count < focus.Count; count++)
            {
                sum += focus[count].position;
            }

            sum /= focus.Count;

            for (count = 0; count < focus.Count; count++)
            {
                float temp = Vector2.Distance(this.pos, focus[count].position);

                if (temp > maxDist)
                {
                    maxDist = temp;
                }
            }

            if (maxDist > ((vp.Height / 2) - 100f) && zoom > 0.6f)
            {
                zoom -= (maxDist / ((vp.Height / zoom)))/100;
            }

            else if(maxDist < ((vp.Height / 2) + 100f) && zoom < 0.8f)
            {
                zoom += (maxDist / ((vp.Height / zoom))) / 100;
            }

            if (zoom > maxZoom) zoom = maxZoom;
            if (zoom < minZoom) zoom = minZoom;

            pos = sum;

            //pos = Vector2.Lerp(pos, sum, 0.9f);

            //rotation = Math.LerpAngle

            return
                Matrix.CreateTranslation(-this.pos.X, -this.pos.Y, 0) *
                Matrix.CreateScale(this.zoom) *
                Matrix.CreateTranslation(vp.Width / 2, vp.Height / 2, 0);
        }
    }
}
