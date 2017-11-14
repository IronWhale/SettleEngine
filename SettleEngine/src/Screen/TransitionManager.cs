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

namespace SettleEngine.src.Screen
{
    public class TransitionManager
    {
        List<Transition> transitions = new List<Transition>();
        

        public void Initalize()
        {
            foreach (var transition in transitions)
            { transition.Initialize(); }
        }

        public void Add(Transition t)
        {
            Debug.WriteLine("[Transition Manager]: Transition Added" + t.GetType().ToString());
            t.Initialize();
            transitions.Add(t);
        }



        public void checkForCompletionStatus()
        {
            List<int> cullList = new List<int>();
            int i = 0;
            foreach (var transition in transitions)//Get all the positions of complete transitions
            {
                if (transition.isComplete) { cullList.Add(i); }
                i++;//Must be done last            
            }

            foreach (var x in cullList)//Remove the transitions that are finished
            {
                Debug.WriteLine("[Transition Manager]: Transition Removed" + transitions[x].GetType().ToString());
                transitions.RemoveAt(x);
            }
        }


        public void Update(GameTime gameTime, MouseState m, KeyboardState k) {

            //Update the active transitions
            foreach (var transition in transitions)
            {
                transition.Update(gameTime, m, k);
            }

            //Check to remove transitions
            checkForCompletionStatus();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            foreach (var transition in transitions)
            { transition.Draw(spriteBatch); }

        }

    }
}
