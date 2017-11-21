using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettleEngine.src
{
    public class GlobalEnums
    {


    }

    public enum GameMode
    { Studio, MainMenu, NewGame, LoadGame, Running, Settings, Exit, Testing }

    public enum WorldSpaceMode
    { Normal, Combat, Dialogue}

    public enum StructureType
    { Wall, Floor, Ceiling, Doorway, Object}

    public enum SnappingDirection
    { N, NE, E, SE, S, SW, W, NW}

    public enum ItemType
    { Junk, MeleeWeapon, RangedWeapon, Clothing, Medical, Quest}

    public enum Procedure
    { }

    public enum Fonts
    { Title, Console, Brand, Studio }

    public enum UIElementType
    { Text, Button, Slider, Input}

    public enum UILocation
    { Relative, Absolute}

    public enum ActorDirection
    { Up, Left, Right, Down}

}
