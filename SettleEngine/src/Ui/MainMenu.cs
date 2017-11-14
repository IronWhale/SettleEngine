using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace SettleEngine.src.Ui
{
    public class MainMenu
    {
        private List<Panel> panels = new List<Panel>();

        public void Initialize()
        {
            //Top bar panel just says the brand title Remnants possibly also a version number 
            Panel tPanel = new Panel(true,new Rectangle(0,0,1920,100), new Color(205,205,205,205));
            tPanel.Add(new Text("-Remnants-", Fonts.Brand, UILocation.Absolute, new Vector2(1920/2, 50), new Color(0,0,0,255)));


            //Middle bar is not drawn just has some text that says Settle in the for ground and the animated
            //Content is the background
            Panel mPanel = new Panel(false, new Rectangle(0,100,1920,680), Color.TransparentBlack);
            

            //Bottom Bar contains all the buttons for the menu
            Panel bPanel = new Panel(false, new Rectangle(0, 780, 1920, 300), new Color(45,45,45,255));
            ControllableGroup cGroup = new ControllableGroup(new Rectangle(1500, 300, 400, 300));
            cGroup.Add(new Button("Intro",true,Fonts.Console, UILocation.Absolute, new Vector2(1500,800),new Color(205,205,205,255),new Color(255,255,255,255), Game1.ChangeAction, "Intro"));
            cGroup.Add(new Button("Continue", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 835), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "Continue"));
            cGroup.Add(new Button("New Game", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 870), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "NewGame"));
            cGroup.Add(new Button("Load Game", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 905), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "LoadGame"));
            cGroup.Add(new Button("Settings", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 940), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "Settings"));
            cGroup.Add(new Button("Credits", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 975), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "Credits"));
            cGroup.Add(new Button("Exit", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 1010), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "Exit"));
            cGroup.Add(new Button("TESTING", true, Fonts.Console, UILocation.Absolute, new Vector2(1500, 1045), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "Testing"));


            //Add the Panels 
            panels.Add(tPanel);
            panels.Add(mPanel);
            panels.Add(bPanel);
            panels.Add(cGroup);

            foreach (var panel in panels)
            {
                panel.Initialize();
            }
        }

        public void Load(ContentManager Content)
        {
            foreach (var panel in panels)
            { panel.Load(Content); }

        }

        public void Update(GameTime gameTime, MouseState m, KeyboardState k)
        {
            foreach (var panel in panels)
            { panel.Update(gameTime, m, k); }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var panel in panels)
            { panel.Draw(spriteBatch); }
        }


    }
}
