using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public const float GravitySpeed = 9.8f;

    public enum LEFTHAND
    {
        AXE1 = 0,
        AXE2 = 1,
        BOW1 = 2, 
        BOW2 = 3,
        HAMMER1 = 4,
        HAMMER2 = 5,
        SHIELD1 = 6,
        SHIELD2 = 7,
        SHIELD3 = 8,
        SHIELD4 = 9,
        SHIELD5 = 10,
        SHIELD6 = 11,
        SHIELD7 = 12,
        SHIELD8 = 13,
        SWORD1 = 14,
        SWORD2 = 15,
        SWORD3 = 16,
        SWORD4 = 17,
        SWORD5 = 18,
        SWORD6 = 19,
        SWORD7 = 20,
        WAND1 = 21,
        WAND2 = 22,
        WAND3 = 23,
        END
    }

    public enum RIGHTHAND
    {
        ARROW1 = 0,
        ARROW2 = 1,
        AXE1 = 2,
        AXE2 = 3,
        HAMMER1 = 4,
        HAMMER2 = 5,
        SWORD1 = 6,
        SWORD2 = 7,
        SWORD3 = 8,
        SWORD4 = 9,
        SWORD5 = 10,
        SWORD6 = 11,
        SWORD7 = 12,
        WAND1 = 13,
        WAND2 = 14,
        WAND3 = 15,
        END
    }

    public enum MAINBUTTON
    {


    }

    public enum PLAYBUTTON
    {
        BUTTON1 = 0,
        BUTTON2 = 1,
        BUTTON3 = 2,
        BUTTON4 = 3,
        END
    }

    public enum ANIMLAYER
    {
        NOWEAPON = 0,
        BOW = 1,
        DOUBLESWORD = 2,
        MAGICWAND = 3,
        TWOHANDSWORD = 4,
        SWORDSHIELD = 5,
        END
    }

}
