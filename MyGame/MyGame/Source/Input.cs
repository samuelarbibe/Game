using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    public abstract class BaseKeys
    {
        public abstract bool GoUp();
        public abstract bool GoDown();
        public abstract bool GoLeft();
        public abstract bool GoRight();
        public abstract void SetMe(IFocus me);
    }

    public class UserKeys : BaseKeys
    {
        Keys upKey, downKey, leftKey, rightKey;

        public UserKeys(Keys up, Keys down, Keys left, Keys right)
        {
            this.upKey = up;
            this.downKey = down;
            this.leftKey = left;
            this.rightKey = right;
        }

        public override bool GoUp()
        {
            return G.keyboardState.IsKeyDown(upKey);
        }

        public override bool GoDown()
        {
            return G.keyboardState.IsKeyDown(downKey);
        }

        public override bool GoLeft()
        {
            return G.keyboardState.IsKeyDown(leftKey);
        }

        public override bool GoRight()
        {
            return G.keyboardState.IsKeyDown(rightKey);
        }

        public override void SetMe(IFocus me)
        {
        }
    }

    public class BotKeys : BaseKeys
    {
        bool up, down, left, right;
        IFocus target, me;

        public BotKeys(IFocus target, bool up = false, bool down = false, bool left = false, bool right = false)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
            this.target = target;
            Game1.Updated += this.AI;
        }

        public override bool GoUp()
        {
            return up;
        }

        public override bool GoDown()
        {
            return down;
        }

        public override bool GoLeft()
        {
            return left;
        }

        public override bool GoRight()
        {
            return right;
        }

        public override void SetMe(IFocus me)
        {
            this.me = me;
        }

        void AI()
        {
            left = right = up = down = false;

            Vector2 distance = target.position - me.position;
            float wantedRotation = (float)Math.Atan2(distance.X, -distance.Y);
            float rotationDelta = MathHelper.WrapAngle(wantedRotation - me.rotation);

            Console.WriteLine(wantedRotation);
            //Console.WriteLine("target->" + target.rotation);

            if (distance.Length() > 300)
            {
                up = true;
                if (rotationDelta > 0.1f)
                {
                    right = true;

                }
                else if (rotationDelta < 0.1f)
                {
                    left = true;
                }
                else
                {
                    right = left = false;
                }
            }
            else down = true;
        }
    }
}
