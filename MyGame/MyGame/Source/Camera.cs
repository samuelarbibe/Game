using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    class Camera
    {
        Viewport vp;
        Drawer focus;
        Vector2 position;
        float rotation;
        float zoom;

        public Camera(Viewport vp, Drawer focus, Vector2 position, float zoom)
        {
            this.vp = vp;
            this.focus = focus;
            this.position = position;
            this.zoom = zoom;
        }

        public Matrix GetMatrix()
        {

            position = Vector2.Lerp(focus.position, position, 0.9f);

            //rotation = Math.LerpAngle

            return
                Matrix.CreateTranslation(-this.position.X, -this.position.Y, 0) *
                //Matrix.CreateRotationZ(/*-focus.rotation -*/ 1.6f) *
                Matrix.CreateScale(this.zoom) *
                Matrix.CreateTranslation(vp.Width / 2, vp.Height / 2, 0);
        }
    }
}
