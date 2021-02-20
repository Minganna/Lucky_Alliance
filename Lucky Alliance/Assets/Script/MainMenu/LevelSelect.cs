using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    StaticVariables sv = new StaticVariables();
    [SerializeField]
    Sprite Daruma2, HorseShoe2, Clover2;
    CommonFunctions cf = new CommonFunctions();
   
    // Start is called before the first frame update
    void Start()
    {
        if(sv.HorseShoeStatus())
        {
            GameObject.Find("HorseShoe").GetComponent<Image>().sprite=HorseShoe2;
        }
        if(sv.DarumaStatus())
        {
            GameObject.Find("Daruma").GetComponent<Image>().sprite = Daruma2;
        }
        if(sv.CloverStatus())
        {
            GameObject.Find("Clover").GetComponent<Image>().sprite = Clover2;
        }
    }


    public void GoBack(string Action)
    {
        cf.GoBack(Action);
    }
    public void DarumaLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void HorseShoeLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void CloverLevel()
    {
        SceneManager.LoadScene(4);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(5);
    }
}
