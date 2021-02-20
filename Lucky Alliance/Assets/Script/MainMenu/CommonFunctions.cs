using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonFunctions 
{
    public void GoBack(string Action)
    {
        if (Action == "Exit")
        {
            SceneManager.LoadScene(0);
        }

    }
}
