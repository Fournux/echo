using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EchoClient
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private MouseState previousMouseState;
        Control test;
        Control test2;

        public Game1()
        {
            ServiceProvider.Current = this.Services;
            _graphics = new GraphicsDeviceManager(this);
            this.Services.AddService<IContentManager>(new SmartContentManager(this.Content));
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "Echo Online";
            _graphics.PreferredBackBufferWidth = 1400;  
            _graphics.PreferredBackBufferHeight = 900;  
            _graphics.ApplyChanges();

            _graphics.SynchronizeWithVerticalRetrace = true;
            base.IsFixedTimeStep = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D mouseTexture = this.Content.Load<Texture2D>("Cursor/cursor");
            MouseCursor cursor = MouseCursor.FromTexture2D(mouseTexture, 0, 0);
            
            Mouse.SetCursor(cursor);

            // test = new Window(100, 100, 500, 500, "coucou", 0.5f);
            // test2 = new Button(50, 70, "Connexion", 0.5f);
            // test = new Label(50,50, "coucou", Color.Black, 1f);
            test = new Button(50, 50, "coucou");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();



            test.Update(keyboardState, mouseState, previousMouseState);

            // TODO: Add your update logic here



            base.Update(gameTime);
            previousMouseState = mouseState;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            test.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
