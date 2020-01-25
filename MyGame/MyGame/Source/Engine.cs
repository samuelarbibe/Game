using System;
using MyGame.Source;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    public class Engine
    {
        public float steeringRotation;
        public float maxSteeringRotation;
        public float NGR; // net gear ratio
        public float Torque;
        public float actualTorque;
        public float brakeTorque;

        
        public Engine(float maxSteeringRotation = 0.7f, float NGR = 1)
        {
            // calculate Torque
            this.Torque = 60;
            this.brakeTorque = -170;
            this.maxSteeringRotation = maxSteeringRotation;
            this.NGR = NGR;
        }
        

        public void Update(BaseKeys keys)
        {
            actualTorque = -20;

            if (keys.GoLeft()) steeringRotation += -0.1f;
            else if (keys.GoRight()) steeringRotation += 0.1f;
            else if (steeringRotation > 0) steeringRotation += -0.1f;
            else if (steeringRotation < 0) steeringRotation += 0.1f;

            //else if (steeringRotation < 0) steeringRotation += 0.2f;
            //else if (steeringRotation > 0) steeringRotation -= 0.2f;

            //steeringRotation += 1 / 100;

            steeringRotation = MathHelper.Clamp(steeringRotation * 0.97f, -maxSteeringRotation, maxSteeringRotation);

            if (keys.GoUp()) // push gas
            {
                // Acceleration = (wheel power - drag power - rolling resistance power)/(mass x speed)
                actualTorque = Torque;
            }

            if (keys.GoDown()) // push break
            {
                actualTorque = brakeTorque;
            }
        }
    }
}
