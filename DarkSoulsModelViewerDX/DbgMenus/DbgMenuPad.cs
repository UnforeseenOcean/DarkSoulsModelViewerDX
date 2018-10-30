﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSoulsModelViewerDX.DbgMenus
{
    public static class DbgMenuPad
    {
        const float INIT_DELAY = 0.25f;
        const float REPEAT_DELAY = 0.075f;

        //public static bool Up = false;
        //public static bool Down = false;
        //public static bool Left = false;
        //public static bool Right = false;
        //public static bool Enter = false;
        //public static bool Cancel = false;
        //public static bool ResetDefault = false;

        public static bool MoveFastHeld = false;
        public static bool MoveFasterHeld = false;

        public static DbgMenuPadRepeater Up
            = new DbgMenuPadRepeater(Buttons.DPadUp, INIT_DELAY, REPEAT_DELAY);

        public static DbgMenuPadRepeater Down
            = new DbgMenuPadRepeater(Buttons.DPadDown, INIT_DELAY, REPEAT_DELAY);

        public static DbgMenuPadRepeater Left
            = new DbgMenuPadRepeater(Buttons.DPadLeft, INIT_DELAY, REPEAT_DELAY);

        public static DbgMenuPadRepeater Right
            = new DbgMenuPadRepeater(Buttons.DPadRight, INIT_DELAY, REPEAT_DELAY);

        public static DbgMenuPadRepeater Enter
            = new DbgMenuPadRepeater(Buttons.A, float.PositiveInfinity, float.PositiveInfinity);

        public static DbgMenuPadRepeater Cancel
            = new DbgMenuPadRepeater(Buttons.B, float.PositiveInfinity, float.PositiveInfinity);

        public static DbgMenuPadRepeater ResetDefault
            = new DbgMenuPadRepeater(Buttons.Start, float.PositiveInfinity, float.PositiveInfinity);

        public static DbgMenuPadRepeater ToggleMenu
            = new DbgMenuPadRepeater(Buttons.Back, float.PositiveInfinity, float.PositiveInfinity);

        public static Point MousePos = new Point();
        private static Point prevMousePos = new Point();
        public static bool IsMouseMovedThisFrame = false;
        public static float MouseWheelDelta = 0;
        private static float prevMouseWheel = 0;

        public static bool IsSpacebarHeld = false;

        public static DbgMenuPadRepeater ClickMouse
            = new DbgMenuPadRepeater(Buttons.A, float.PositiveInfinity, float.PositiveInfinity);

        public static DbgMenuPadRepeater MiddleClickMouse
            = new DbgMenuPadRepeater(Buttons.Y, float.PositiveInfinity, float.PositiveInfinity);

        public static Vector2 MenuRectMove = Vector2.Zero;
        public static Vector2 MenuRectResize = Vector2.Zero;

        public static void Update(float elapsedSeconds)
        {
            var gamepad = GamePad.GetState(0);
            var keyboard = Keyboard.GetState();
            var mouse = Mouse.GetState();

            

            if (DbgMenuItem.MenuOpenState == DbgMenuOpenState.Open)
            {
                Up.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Up));
                Down.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Down));
                Left.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Left));
                Right.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Right));
                Enter.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Enter));
                Cancel.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Back) || mouse.RightButton == ButtonState.Pressed);
                ResetDefault.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.Home));

                MoveFastHeld = gamepad.IsButtonDown(Buttons.LeftShoulder) || keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift);
                MoveFasterHeld = gamepad.IsButtonDown(Buttons.X) || keyboard.IsKeyDown(Keys.LeftControl) || keyboard.IsKeyDown(Keys.RightControl);

                ClickMouse.Update(gamepad, elapsedSeconds, mouse.LeftButton == ButtonState.Pressed);
                MiddleClickMouse.Update(gamepad, elapsedSeconds, mouse.MiddleButton == ButtonState.Pressed);

                MousePos = new Point(mouse.X, mouse.Y);

                IsMouseMovedThisFrame = (MousePos != prevMousePos);

                if (gamepad.IsButtonDown(Buttons.RightShoulder))
                {
                    var isFast = gamepad.IsButtonDown(Buttons.LeftShoulder);
                    MenuRectMove = gamepad.ThumbSticks.Left * new Vector2(1, -1) * (isFast ? 50 : 12);
                    MenuRectResize = gamepad.ThumbSticks.Right * new Vector2(1, -1) * (isFast ? 50 : 12);
                }
                else
                {
                    MenuRectMove = Vector2.Zero;
                    MenuRectResize = Vector2.Zero;
                }

                IsSpacebarHeld = keyboard.IsKeyDown(Keys.Space);

                float mouseWheel = mouse.ScrollWheelValue;
                MouseWheelDelta = (mouseWheel - prevMouseWheel);
                prevMouseWheel = mouseWheel;
            }
            else
            {
                MenuRectMove = Vector2.Zero;
                MenuRectResize = Vector2.Zero;
                prevMouseWheel = mouse.ScrollWheelValue;
            }

            if (ToggleMenu.Update(gamepad, elapsedSeconds, keyboard.IsKeyDown(Keys.OemTilde)))
            {
                if (DbgMenuItem.MenuOpenState == DbgMenuOpenState.Closed)
                    DbgMenuItem.MenuOpenState = DbgMenuOpenState.Open;
                else if (DbgMenuItem.MenuOpenState == DbgMenuOpenState.Open)
                    DbgMenuItem.MenuOpenState = DbgMenuOpenState.Visible;
                else if (DbgMenuItem.MenuOpenState == DbgMenuOpenState.Visible)
                    DbgMenuItem.MenuOpenState = DbgMenuOpenState.Closed;
            }

            prevMousePos = MousePos;
        }
    }
}
