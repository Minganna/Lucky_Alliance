using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables 
{

    static KeyCode Left, Right, Up, Down,Mirror;

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
