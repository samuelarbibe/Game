using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame.Source
{
    abstract class BaseKeys
    {
        public abstract bool GoUp();
        public abstract bool GoDown();
        public abstract bool GoLeft();
        public abstract bool GoRight();
    }

    class UserKeys : BaseKeys
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
    }
}
