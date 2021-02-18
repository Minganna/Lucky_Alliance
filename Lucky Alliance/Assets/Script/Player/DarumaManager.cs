using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarumaManager : MonoBehaviour
{
    public bool SecondDaruma;
    FindAllClosestObstacles[] fd;
    private GameObject[] Daruma;
    public Movements[] Players;
    public GameObject nextPart;

    [SerializeField] GameObject Win;
    private bool Ending=true;


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
        MoveDaruma();
        checkObjectivesforDarumas();
        GameWon();
        
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
        Debug.Log(gameWon);
        Win.SetActive(true);
        if(Ending)
        {
            Ending = false;
            StartCoroutine(BackToMenu());
        }
    }

    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
        
    }

    private void checkObjectivesforDarumas()
    {
        foreach (Movements player in Players)
        {
            Debug.Log(player.name);
            Vector3 objectivePos = new Vector3(player.ObjectiveToPush.transform.position.x, player.transform.position.y, player.ObjectiveToPush.transform.position.z);
            
            if (player.transform.position== objectivePos)
            {
                    player.ObjectiveToPush.transform.localPosition = player.nextPosition;
                    Debug.Log("ButtonPushed");
                    nextPart.SetActive(true);
                    SettingUp();
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
