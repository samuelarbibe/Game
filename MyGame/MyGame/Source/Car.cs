using System;
using MyGame.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    class Car : MovableObject
    {
        Engine engine;
        float mass;

        public Car(BaseKeys directionKeys, Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth, float speed) : base(directionKeys, texture,  position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth, speed)
        {
            this.engine = new Engine();
            mass = 1200;
            Game1.Updated += this.update;
        }

        void update()
        {
            engine.Update(directionKeys);

            // Torque* NGR = Torque on wheels(T)
            float wheelTorque = engine.NGR * engine.actualTorque;

            // Acceleration = (wheel power - drag power - rolling resistance power)/(mass x speed)
            accelaration = wheelTorque / mass;

            //if (speed < 1) rotation += 0;
            rotation += engine.steeringRotation/100 * speed;
        }
    }
}
