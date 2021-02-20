using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAllClosestObstacles : MonoBehaviour
{
    public GameObject[] Obstacles;
    private Vector3[] ClosestObstaclepos;

    public float distx=0;
    public float distz=0;
    // Start is called before the first frame update
    void Start()
    {
         Obstacles= GameObject.FindGameObjectsWithTag("Enviroment");
        ClosestObstaclepos = new Vector3[Obstacles.Length];
        for (int i = 0; i < Obstacles.Length; i++)
            {
            if (Obstacles[i].transform.position != this.transform.position)
            {
                ClosestObstaclepos[i] = Obstacles[i].transform.position;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        CheckHorizontal();
        CheckVertical();
    }

    void CheckVertical()
    {
        foreach (Vector3 obstacle in ClosestObstaclepos)
        {
            if ((this.transform.position - obstacle).magnitude == 1 && (this.transform.position.x == obstacle.x))
            {
                Debug.DrawLine(this.transform.position, obstacle, Color.blue);
                distz = this.transform.position.z - obstacle.z;
                return;
            }
            else
            {
                distz = 0;
            }
        }
    }

    void CheckHorizontal()
    {
        foreach (Vector3 obstacle in ClosestObstaclepos)
        {
            if ((this.transform.position - obstacle).magnitude == 1&&(this.transform.position.z==obstacle.z))
            {
                Debug.DrawLine(this.transform.position, obstacle, Color.red);
                distx = this.transform.position.x - obstacle.x;
                return;
            }
            else
            {
                distx = 0;
            }
        }
    }
}
