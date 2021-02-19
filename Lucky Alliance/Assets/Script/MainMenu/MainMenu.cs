using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class MainMenu :MonoBehaviour
{
    StaticVariables sv=new StaticVariables();
    [SerializeField]
    TextMeshProUGUI Up, Down, Left, Right, Mirror;
    [SerializeField]
    GameObject Menu, Settings;
    bool changingkeyUp=false,changingkeyDown=false, changingkeyLeft = false, changingkeyRight = false, changingkeyMirror = false;

    // Start is called before the first frame update
    void Start()
    {
        sv.LeftKey(KeyCode.A);
        sv.RightKey(KeyCode.D);
        sv.UpKey(KeyCode.W);
        sv.DownKey(KeyCode.S);
        sv.Mirrorkey(KeyCode.Space);
        UpdateKey();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingsMenu()
    {
        Menu.SetActive(false);
        Settings.SetActive(true);
    }    
    public void ExitButton(string Action)
    {
        if(Action=="Exit")
        {
            Application.Quit();
        }
        if(Action=="Menu")
        {
            Settings.SetActive(false);
            Menu.SetActive(true);
        }
    }

    public void Changekey(string name)
    {
        if(name=="Up")
        {
            Up.text = "Press a key";
            changingkeyUp = true;
        }
        if(name=="Down")
        {
            Down.text= "Press a key";
            changingkeyDown = true;
        }
        if(name=="Left")
        {
            Left.text= "Press a key";
            changingkeyLeft = true;
        }
        if(name=="Right")
        {
            Right.text = "Press a key";
            changingkeyRight = true;
        }
        if(name=="Mirror")
        {
            Mirror.text = "Press a key";
            changingkeyMirror = true;
        }
    }
    
    void UpdateKey()
    {
        Up.text = sv.GetUp().ToString();
        Down.text = sv.GetDown().ToString();
        Left.text = sv.GetLeft().ToString();
        Right.text = sv.GetRight().ToString();
        Mirror.text = sv.GetMirror().ToString();
    }

    private void Update()
    {
        if(changingkeyUp&&Input.anyKeyDown)
        {
            changingkeyUp = false;
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    Up.text = kcode.ToString();
                    sv.UpKey(kcode);
                }
            }
        }
        if (changingkeyDown && Input.anyKeyDown)
        {
            changingkeyDown = false;
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    Down.text = kcode.ToString();
                    sv.DownKey(kcode);
                }
            }
        }
        if (changingkeyLeft && Input.anyKeyDown)
        {
            changingkeyLeft = false;
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    Left.text = kcode.ToString();
                    sv.LeftKey(kcode);
                }
            }
        }
        if (changingkeyRight && Input.anyKeyDown)
        {
            changingkeyRight = false;
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    Right.text = kcode.ToString();
                    sv.RightKey(kcode);
                }
            }
        }
        if (changingkeyMirror && Input.anyKeyDown)
        {
            changingkeyMirror = false;
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    Mirror.text = kcode.ToString();
                    sv.Mirrorkey(kcode);
                }
            }
        }
    }



}
