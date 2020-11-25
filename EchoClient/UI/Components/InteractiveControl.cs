using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class InteractiveControl : Control
{
    ///////////////////////////////////////////////////////////
    ////////////////////// CONSTRUCTORS ///////////////////////
    ///////////////////////////////////////////////////////////

    public InteractiveControl(Vector2 position, float scale = 1) : base(position, scale)
    {
    }

    public InteractiveControl(int x, int y, float scale = 1) : base(x, y, scale)
    {
    }

    public InteractiveControl(Vector2 position, int width, int height, float scale = 1) : base(position, width, height, scale)
    {
    }

    ///////////////////////////////////////////////////////////
    ///////////////////////// METHODS /////////////////////////
    ///////////////////////////////////////////////////////////

    protected bool IsMouseOver(MouseState state)
    {
        Vector2 position = this.AbsolutePosition;
        if (state.X >= position.X && state.X <= position.X + this.Width && state.Y >= position.Y && state.Y <= position.Y + this.Height)
        {
            return true;
        }
        return false;
    }

    public new virtual void Update(KeyboardState keyBoardState, MouseState mouseState, MouseState previousMouseState)
    {
        if (IsMouseOver(mouseState))
        {
            if (!IsMouseOver(previousMouseState))
            {
                this.OnMouseEnter(EventArgs.Empty);
            }

            if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                this.OnLeftMouseDown(EventArgs.Empty);
            }
            else if (mouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
            {
                this.OnLeftMouseUp(EventArgs.Empty);
                this.OnLeftMouseClick(EventArgs.Empty);
            }
        }
        else if (!IsMouseOver(mouseState) && IsMouseOver(previousMouseState))
        {
            this.OnMouseLeave(EventArgs.Empty);
        }
    }

    ///////////////////////////////////////////////////////////
    ///////////////////////// EVENTS //////////////////////////
    ///////////////////////////////////////////////////////////

    public event EventHandler LeftMouseDown;
    public event EventHandler LeftMouseUp;
    public event EventHandler LeftMouseClick;
    public event EventHandler MouseEnter;
    public event EventHandler MouseLeave;

    protected void OnLeftMouseDown(EventArgs eventArgs)
    {
        if (LeftMouseDown != null)
        {
            LeftMouseDown(this, eventArgs);
        }
    }
    protected void OnLeftMouseUp(EventArgs eventArgs)
    {
        if (LeftMouseUp != null)
        {
            LeftMouseUp(this, eventArgs);
        }
    }
    protected void OnLeftMouseClick(EventArgs eventArgs)
    {
        if (LeftMouseClick != null)
        {
            LeftMouseClick(this, eventArgs);
        }
    }
    protected void OnMouseEnter(EventArgs eventArgs)
    {
        if (MouseEnter != null)
        {
            MouseEnter(this, eventArgs);
        }
    }
    protected void OnMouseLeave(EventArgs eventArgs)
    {
        if (MouseLeave != null)
        {
            MouseLeave(this, eventArgs);
        }
    }

}