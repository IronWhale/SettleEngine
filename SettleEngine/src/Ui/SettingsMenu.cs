using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Ui
{
    public class SettingsMenu
    {

        private List<Panel> panels = new List<Panel>();

        public void Initialize()
        {
            //Top bar panel just says the brand title Remnants possibly also a version number 
            Panel tPanel = new Panel(true, new Rectangle(0, 0, 1920, 100), new Color(205, 205, 205, 205));
            tPanel.Add(new Text("-Settings-", Fonts.Brand, UILocation.Absolute, new Vector2(1920 / 2, 50), new Color(0, 0, 0, 255)));

            //Middle Panel for game options

            //Has Apply, and Done buttons and GameVersion
            Panel bPanel = new Panel(true, new Rectangle(0, 980, 1920, 200), new Color(45, 45, 45, 255));
            bPanel.Add(new Button("Done", false ,Fonts.Brand, UILocation.Relative, new Vector2(1500, 0), new Color(205, 205, 205, 255), new Color(255, 255, 255, 255), Game1.ChangeAction, "MainMenu"));



            //Add the Panels 
            panels.Add(tPanel);
            panels.Add(bPanel);

            //Send the Refernce to the parents panel for relative sizing
            foreach (var panel in panels)
            {
                panel.passRefernce();
            }

            //Initialize all the panels
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
