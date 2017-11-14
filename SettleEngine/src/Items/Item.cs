using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SettleEngine.src.Items
{
    public class Item
    {
    #region Fields
        private string name;
        private int ID; //master data item reference id
        private Texture2D texture;
        private int count; //if stackable item keeps the count of how many the player has
        private string discription; //short text about the item
        private Boolean isQuestItem;
        private ItemType type;
        
    #endregion

        public Item(string name, int id, Texture2D texture, int count, string disc, Boolean isQuest)
        {
            this.name = name;
            this.ID = id;
            this.texture = texture;
            this.count = count;
            this.discription = disc;
            this.isQuestItem = isQuest;
        }

        #region GettersAndSetters
        public void setName(string i)
        { this.name = i; }
        public void setID(int i)
        { this.ID = i; }
        public void setTexture(Texture2D i)
        { this.texture = i; }
        public void setCount(int i)
        { this.count = i; }
        public void setDiscription(string i)
        { this.discription = i; }
        public void setIsQuestionItem(Boolean i)
        { this.isQuestItem = i; }

        public string getName()
        { return name; }
        public int getID()
        { return ID;}
        public Texture2D getTexture()
        { return texture; }
        public int getCount()
        { return count; }
        public string getDiscription()
        { return discription; }
        public Boolean getIsQuestItem()
        { return isQuestItem; }
        #endregion
    }
}
