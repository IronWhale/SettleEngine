﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SettleEngine.src.Ui;
using SettleEngine.src.WorldSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SettleEngine.src.Screen;
using SettleEngine.src;

namespace SettleEngine
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        public static GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        public static ContentManager manager;

        #region DisplayParameters
        //Display
        private string windowTitle = "Remnants";
        //Real Dimensions
        private int WIDTH = 1280;
        private int HEIGHT = 720;
        //Virtual Dimensions
        private int vWidth = 1920;
        private int vHeight = 1080;
        public static Vector2 scale { get; set; }
        private RenderTarget2D target;
        #endregion

        //GameMode and UI Menus
        private bool devMode = true;
        private static GameMode gameMode;


        public static TransitionManager transitionManager = new TransitionManager();
        private static bool isTransitioning;
        private MainMenu mainMenu = new MainMenu();
        private SettingsMenu settingMenu = new SettingsMenu();
        private StudioScreen studioScreen;
        private SpriteFont titleFont;
        private SpriteFont conFont;
        private WorldSpaceManager wsManager;

        //Inputs
        private KeyboardState k;
        private MouseState m;

        #region FPSFields
        //FPS COUNTER
        private bool showFps = true;
        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;
        #endregion


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            manager = new ContentManager(Content.ServiceProvider);

            #region SetUpDisplay
            //Display Setup
            Window.Title = windowTitle;
            graphics.PreferredBackBufferHeight = HEIGHT;
            graphics.PreferredBackBufferWidth = WIDTH;
            IsMouseVisible = true;
            //graphics.IsFullScreen = true;
            scale = new Vector2(((float)WIDTH / (float)vWidth), ((float)HEIGHT / (float)vHeight));
            Debug.WriteLine("Virtual Scaling X: " + scale.X + " Y: " + scale.Y);
            #endregion


            gameMode = GameMode.Studio; //Set the beginning gameMode
            wsManager = new WorldSpaceManager();

            studioScreen = new StudioScreen();

            manager.RootDirectory = "Content";
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            Debug.WriteLine("[Begin] Game1.Initialize");

            //Create Render Target for scaling the screen to any resoltion
            PresentationParameters pp = graphics.GraphicsDevice.PresentationParameters;
            target = new RenderTarget2D(graphics.GraphicsDevice, vWidth, vHeight, false, SurfaceFormat.Color, DepthFormat.None, pp.MultiSampleCount, RenderTargetUsage.DiscardContents );

            transitionManager.Initalize();

            //Create the Screens and menus
            studioScreen.Initialize();
            mainMenu.Initialize();
            settingMenu.Initialize();
            wsManager.Initialize(graphics.GraphicsDevice);


            
            base.Initialize();

            Debug.WriteLine("[End] Game1.Initialize");
        }

        protected override void LoadContent()
        {
            Debug.WriteLine("[Begin] Game1.LoadContent");

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            studioScreen.Load(Content);

            titleFont = Content.Load<SpriteFont>("Fonts/Title");
            conFont = Content.Load<SpriteFont>("Fonts/Console");

            mainMenu.Load(Content);
            settingMenu.Load(Content);

            Debug.WriteLine("[End] Game1.LoadContent");
        }

        protected override void UnloadContent()
        { }
        

        protected override void Update(GameTime gameTime)
        {
            #region input_Updates
            //Update inputs
            k = Keyboard.GetState();
            m = Mouse.GetState();
            #endregion

            #region FPS_COUNTER
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }
            #endregion

            //Update the transistions
            transitionManager.Update(gameTime, m , k);

            if (!isTransitioning)
            {
                switch (gameMode)
                {
                    case GameMode.Studio:
                        studioScreen.Update(gameTime);
                        break;
                    case GameMode.MainMenu:
                        mainMenu.Update(gameTime, m, k);
                        break;
                    case GameMode.NewGame:
                        break;
                    case GameMode.LoadGame:
                        break;
                    case GameMode.Settings:
                        settingMenu.Update(gameTime, m, k);
                        break;
                    case GameMode.Exit:
                        Exit();
                        break;
                    case GameMode.Running:
                        break;
                    case GameMode.Testing:
                        wsManager.Update(gameTime, m, k);
                        break;
                }
            }
            else
            {

            }

            //Emergancy Exit
            if (k.IsKeyDown(Keys.F12))
            { Exit(); }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            frameCounter++;

            GraphicsDevice.SetRenderTarget(target);
            graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 1.0f, 0);

            //TODO: Move the begin to inside the switch statement.
            switch (gameMode)
            {
                case GameMode.Studio:
                    studioScreen.Draw(spriteBatch);
                    break;
                case GameMode.MainMenu:
                    mainMenu.Draw(spriteBatch);
                    break;
                case GameMode.NewGame:
                    break;
                case GameMode.LoadGame:
                    break;
                case GameMode.Settings:
                    settingMenu.Draw(spriteBatch);
                    break;
                case GameMode.Exit:
                    break;
                case GameMode.Running:
                    break;
                case GameMode.Testing:
                    wsManager.Draw(spriteBatch);
                    break;
            }

            #region DrawExtras
            spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointWrap, null, null, null, null);

            if (devMode)
            { spriteBatch.DrawString(conFont, ("Mouse X: " + m.X + "  Mouse Y: " + m.Y), new Vector2(10, 10), Color.Black); }

            if (showFps)
            { spriteBatch.DrawString(conFont, ("FPS: " + frameRate), new Vector2(10, 30), Color.Black); }
            #endregion 

            transitionManager.Draw(spriteBatch);

            #region ResetRenderTarget
            GraphicsDevice.SetRenderTarget(null);
            graphics.GraphicsDevice.Clear(ClearOptions.Target, Color.Black, 1.0f, 0);
            spriteBatch.Draw(target,Vector2.Zero, Color.White);

            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }


        //@CLEANUP MOVE TO UPDATE METHOD
        //Changes the GameMode using the default Fadeout parameters
        public static void ChangeAction(string s)
        {
            isTransitioning = true;
            Action<string>action = Game1.UpdateGameMode;
            transitionManager.Add(new FadeOut(action, s));
        }
        //@CLEANUP
        //Changes the GameMode using Custom Fadeout params
        public static void ChangeAction(string s, FadeOut fOut)
        {
            isTransitioning = true;
            Action<string> action = Game1.UpdateGameMode;
            transitionManager.Add(fOut);
        }
        //@CLEANUP
        public static void UpdateGameMode(string action)
        {
            Enum.TryParse(action, out GameMode mode);
            Debug.WriteLine("[Update GameMode]: " + mode);
            gameMode = mode;
            isTransitioning = false;
        }
    }

    


}
