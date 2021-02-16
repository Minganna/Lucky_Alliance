using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarumaManager : MonoBehaviour
{
    public bool SecondDaruma;
    FindAllClosestObstacles[] fd;
    private GameObject[] Daruma;
    public Movements[] Players;
    // Start is called before the first frame update
    void Start()
    {
     
        Players = FindObjectsOfType<Movements>();
        fd = new FindAllClosestObstacles[Players.Length];
        Daruma = new GameObject[Players.Length];
        for(int i=0;i<Players.Length;i++)
        {
            Daruma[i] = Players[i].Daruma;
            fd[i]= Players[i].GetComponent<FindAllClosestObstacles>();

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        MoveDaruma();
    }

    private void MoveDaruma()
    {
        Vector3 LookRotation=new Vector3(0,0,0);
        foreach (Movements player in Players)
        {
            if (Input.GetKeyDown(player.Left) && player.fd.distx != 1)
            {
                FindObjectOfType<PlayerView>().MakeVisible();
                player.MoveLeft(LookRotation);


            }
            if (Input.GetKeyDown(player.Right) && player.fd.distx != -1)
            {
                FindObjectOfType<PlayerView>().MakeVisible();
                player.MoveRight(LookRotation);

            }
            if (Input.GetKeyDown(player.Up) && player.fd.distz != -1)
            {
                FindObjectOfType<PlayerView>().MakeVisible();

                player.MoveUp(LookRotation);

            }
            if (Input.GetKeyDown(player.Down) && player.fd.distz != 1)
            {
                FindObjectOfType<PlayerView>().MakeVisible();
                player.MoveDown(LookRotation);

            }
        }
    }
}
