using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public GameObject Daruma;
    public KeyCode Left, Right, Up, Down;
    public bool SecondDaruma;
    public FindAllClosestObstacles fd;
    public bool switched=false;
    public GameObject ObjectiveToPush;
    public Vector3 nextPosition;
    public bool OnPosition=false;
    void Start()
    {
        Left = KeyCode.D;
        Right = KeyCode.A;
        Up = KeyCode.S;
        Down = KeyCode.W;
        fd = this.GetComponent<FindAllClosestObstacles>();



    }

    // Update is called once per frame
    void Update()
    {

        if (SecondDaruma)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                KeyCode LeftTemp, RightTemp, UpTemp, DownTemp;
                LeftTemp = Right;
                RightTemp = Left;
                UpTemp = Down;
                DownTemp = Up;
                Right = RightTemp;
                Left = LeftTemp;
                Up = UpTemp;
                Down = DownTemp;
                switched = !switched;
            }
        }
    }


   public  void MoveLeft(Vector3 LookRotation)
    {
        transform.position += Vector3.left;
        LookRotation = new Vector3(0, 180, 0);
        Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);

    }
    public void MoveRight(Vector3 LookRotation)
    {
        transform.position += Vector3.right;
        Daruma.transform.Rotate(Daruma.transform.rotation * Vector3.right);
        LookRotation = new Vector3(0, 0, 0);
        Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
    }
    public void MoveUp(Vector3 LookRotation)
    {
        transform.position += Vector3.forward;
        Daruma.transform.Rotate(Daruma.transform.rotation * Vector3.forward);
        LookRotation = new Vector3(0, 270, 0);
        Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
    }
    public void MoveDown(Vector3 LookRotation)
    {
        transform.position += Vector3.back;
        LookRotation = new Vector3(0, 90, 0);
        Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
    }
}
