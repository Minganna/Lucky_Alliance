using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables 
{

    static KeyCode Left, Right, Up, Down,Mirror;
    static bool HorseShoe, Daruma, Clover;

    public void LeftKey(KeyCode newLeft)
    {
        Left = newLeft;
    }
    public void RightKey(KeyCode newRight)
    {
        Right = newRight;
    }
    public void UpKey(KeyCode newUp)
    {
        Up = newUp;
    }
    public void DownKey(KeyCode newDown)
    {
        Down = newDown;
    }

    public void Mirrorkey(KeyCode newMirror)
    {
        Mirror = newMirror;
    }


    public void CompleteHorseShoe(bool status)
    {
        HorseShoe = status;
    }

    public void CompleteDaruma(bool status)
    {
        Daruma = status;
    }

    public void CompleteClover(bool status)
    {
        Clover = status;
    }

    public bool HorseShoeStatus()
    {
        return HorseShoe;
    }

    public bool DarumaStatus()
    {
        return Daruma;
    }

    public bool CloverStatus()
    {
        return Clover;
    }

    public KeyCode GetLeft()
    {
        return Left;
    }

    public KeyCode GetRight()
    {
        return Right;
    }

    public KeyCode GetUp()
    {
        return Up;
    }
    public KeyCode GetDown()
    {
        return Down;
    }

    public KeyCode GetMirror()
    {
        return Mirror;
    }




}
