using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DarumaManager : MonoBehaviour
{
    public bool SecondDaruma;
    FindAllClosestObstacles[] fd;
    private GameObject[] Daruma;
    public Movements[] Players;
    public GameObject nextPart;
    public Sprite Suggestions1;
    public Sprite Suggestions2;
    public Sprite nextSugg;
    public GameObject ImageColor;
    StaticVariables sv = new StaticVariables();
    CommonFunctions cf = new CommonFunctions();

    [SerializeField] GameObject Win;
    [SerializeField] GameObject FireWorks1;
    [SerializeField] GameObject FireWorks2;
    [SerializeField] GameObject GameUI;
    [SerializeField] GameObject GamePause;

    public bool DarumaLevel, CloverLevel, HorseShoe;

    private bool Ending=true;

    private bool pausemenu=false;
    private bool secondImage = false;



    // Start is called before the first frame update
    void Start()
    {
        SettingUp();

    }

    private void SettingUp()
    {
        Players = FindObjectsOfType<Movements>();
        fd = new FindAllClosestObstacles[Players.Length];
        Daruma = new GameObject[Players.Length];
        for (int i = 0; i < Players.Length; i++)
        {
            Daruma[i] = Players[i].Daruma;
            fd[i] = Players[i].GetComponent<FindAllClosestObstacles>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!pausemenu)
        {
            MoveDaruma();
        }

        GameWon();
        checkObjectivesforDarumas();
        PauseMenu();
        
    }


    public void Back(string Action)
    {
        if (Action == "Exit")
        {
            cf.GoBack(Action);
        }
        else
        {
            pausemenu = !pausemenu;
        }
           
    }

    private void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu = !pausemenu;
        }
        if(pausemenu)
        {
            GameUI.SetActive(false);
            GamePause.SetActive(true);
            GameObject.Find("MovementsText").GetComponent<TextMeshProUGUI>().text = "Movements: " + '\n' + sv.GetUp() + sv.GetLeft()+sv.GetDown()+sv.GetRight();
            GameObject.Find("InvertMovements").GetComponent<TextMeshProUGUI>().text = "Invert Movements: " + '\n' + sv.GetMirror();
        }
        else
        {
            GameUI.SetActive(true);
            GamePause.SetActive(false);
        }
    }    

    private void GameWon()
    {
        bool gameWon = false;

        if(Players.Length<2)
        {
            return;
        }
        else
        {
            foreach (Movements player in Players)
            {
                if(player.OnPosition)
                {
                    gameWon = true;
                }
                else
                {
                    gameWon = false;
                    return;
                }    
            }

        }
        Win.SetActive(true);
        FireWorks1.SetActive(true);
        FireWorks2.SetActive(true);
        if(Ending)
        {
            Debug.Log("Won");
            Ending = false;
            ImageColor.GetComponent<Image>().sprite = Suggestions2;
            if (HorseShoe)
            {
                sv.CompleteHorseShoe(true);
            }
            if(DarumaLevel)
            {
                sv.CompleteDaruma(true);
            }
            if(CloverLevel)
            {
                sv.CompleteClover(true);
            }
            StartCoroutine(BackToMenu());
        }
    }

    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
        
    }

    private void checkObjectivesforDarumas()
    {
        SettingUp();
        foreach (Movements player in Players)
        {
            Vector3 objectivePos = new Vector3(player.ObjectiveToPush.transform.position.x, player.transform.position.y, player.ObjectiveToPush.transform.position.z);
            
            if (player.transform.position== objectivePos)
            {
                    player.ObjectiveToPush.transform.localPosition = player.nextPosition;
                    Debug.Log("ButtonPushed");
                    nextPart.SetActive(true);
                    GameObject.Find("SuggestionImage").GetComponent<Image>().sprite = nextSugg;
                if (!secondImage)
                {
                    Debug.Log("Changing Image");
                    secondImage = true;
                    ImageColor.GetComponent<Image>().sprite = Suggestions1;
                }
                   

                    player.OnPosition = true;
                
            }
            else
            {
                player.OnPosition = false;
            }
            
        }
    }

    private void MoveDaruma()
    {
        Vector3 LookRotation=new Vector3(0,0,0);

        bool canMoveLeft=true,canMoveRight=true,canMoveUp=true,canMoveDown=true;
        bool canMoveLeftSwitched = true, canMoveRightSwitched = true, canMoveUpSwitched = true, canMoveDownSwitched = true;

        foreach (Movements player in Players)
        {
            if (player.fd.distx == 1)
            {
                if(!player.switched)
                {
                    canMoveLeft = false;
                }
                else
                {
                    canMoveLeftSwitched = false;
                }
            }
            if (player.fd.distx == -1)
            {
                if(!player.switched)
                {
                    canMoveRight = false;
                }
                else
                {
                    canMoveRightSwitched = false;
                }

            }
            if (player.fd.distz == -1)
            {
                if(!player.switched)
                {
                    canMoveUp = false;
                }
                else
                {
                    canMoveUpSwitched = false;
                }
                

            }
            if (player.fd.distz == 1)
            {
                if(!player.switched)
                {
                    canMoveDown = false;
                }
                else
                {
                    canMoveDownSwitched = false;
                }
            }
        }


        foreach (Movements player in Players)
        {
            if(!player.switched)
            {
                if (Input.GetKeyDown(player.Left) && canMoveLeft)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();
                    player.MoveLeft(LookRotation);


                }
                if (Input.GetKeyDown(player.Right) && canMoveRight)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();
                    player.MoveRight(LookRotation);

                }
                if (Input.GetKeyDown(player.Up) && canMoveUp)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();

                    player.MoveUp(LookRotation);

                }
                if (Input.GetKeyDown(player.Down) && canMoveDown)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();
                    player.MoveDown(LookRotation);

                }
            }
            else
            {
                if (Input.GetKeyDown(player.Left) && canMoveLeftSwitched)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();
                    player.MoveLeft(LookRotation);


                }
                if (Input.GetKeyDown(player.Right) && canMoveRightSwitched)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();
                    player.MoveRight(LookRotation);

                }
                if (Input.GetKeyDown(player.Up) && canMoveUpSwitched)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();

                    player.MoveUp(LookRotation);

                }
                if (Input.GetKeyDown(player.Down) && canMoveDownSwitched)
                {
                    FindObjectOfType<PlayerView>().MakeVisible();
                    player.MoveDown(LookRotation);

                }
            }

        }
    }
}
