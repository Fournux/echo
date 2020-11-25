using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public abstract class Control : IGameComponent
{

    ///////////////////////////////////////////////////////////
    ///////////////////// PRIVATE FIELDS //////////////////////
    ///////////////////////////////////////////////////////////
    protected Vector2 _position;
    private List<Control> _children;

    ///////////////////////////////////////////////////////////
    /////////////////////// PROPERTIES ////////////////////////
    ///////////////////////////////////////////////////////////
    public Vector2 Position 
    {
        get => this._position; 
        set
        {
            this._position = value;

            for(int i = 0; i < this.Children.Count ; i++)
            {
                this.Children[i].AbsolutePositionPropagation(this.AbsolutePosition);
            }
        }
    }

    public Vector2 AbsolutePosition { get; private set; }
    public int Height {get; protected set;}
    public int Width {get; protected set;}
    public float Scale {get; set;}
    public Control Parent { get; private set; }
    public IList<Control> Children 
    {
        get
        {
            return this._children.AsReadOnly();
        }
    } 

    ///////////////////////////////////////////////////////////
    ////////////////////// CONSTRUCTORS ///////////////////////
    ///////////////////////////////////////////////////////////

    public Control(Vector2 position, float scale = 1.0f)
    {
        this._children = new List<Control>();
        this.Position = position;
        this.AbsolutePosition = position;
        this.Scale = scale;
    }

    public Control(int x, int y, float scale = 1.0f) : this(new Vector2(x, y), scale) {}

    public Control(Vector2 position, int width, int height, float scale = 1.0f) : this(position, scale)
    {
        this.Width = width;
        this.Height = height;
    }

    ///////////////////////////////////////////////////////////
    ///////////////////////// METHODS /////////////////////////
    ///////////////////////////////////////////////////////////

    protected void AbsolutePositionPropagation(Vector2 parentPosition)
    {
        this.AbsolutePosition = parentPosition + this.Position;
        foreach(Control child in this.Children)
        {
            child.AbsolutePositionPropagation(this.AbsolutePosition);
        }
    }
    public void Add(Control child)
    {
        this._children.Add(child);
        child.Parent?.Remove(child);
        child.Parent = this;
        child.AbsolutePositionPropagation(this.AbsolutePosition);
    }

    public void Remove(Control child)
    {
        this._children.Remove(child);
        child.Parent = null;
    }
    public void Update(KeyboardState keyBoardState, MouseState mouseState, MouseState previousMouseState) {}
    public virtual void Draw(SpriteBatch spritebatch)
    {
        foreach(Control child in this.Children)
        {
            child.Draw(spritebatch);
        }
    }
}