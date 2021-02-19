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
    public float moveSpeed;
    private bool isMoving = false;
    StaticVariables sv=new StaticVariables();
    void Start()
    {
        Left = sv.GetRight();
        Right = sv.GetLeft();
        Up = sv.GetDown();
        Down = sv.GetUp();
        fd = this.GetComponent<FindAllClosestObstacles>();
    }

    // Update is called once per frame
    void Update()
    {

        if (SecondDaruma)
        {
            if (Input.GetKeyDown(sv.GetMirror()))
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
        if(!isMoving)
        {
            StartCoroutine(StartMovement(transform.position + Vector3.left));
            LookRotation = new Vector3(0, 180, 0);
            Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
        }
    }
    public void MoveRight(Vector3 LookRotation)
    {
        if(!isMoving)
        {
            Vector3 newPos = transform.position + Vector3.right;
            StartCoroutine(StartMovement(newPos));
            LookRotation = new Vector3(0, 0, 0);
            Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
        }
        
    }
    public void MoveUp(Vector3 LookRotation)
    {
        if(!isMoving)
        {
            StartCoroutine(StartMovement(transform.position + Vector3.forward));
            //transform.position += Vector3.forward;
            Daruma.transform.Rotate(Daruma.transform.rotation * Vector3.forward);
            LookRotation = new Vector3(0, 270, 0);
            Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
        }
    }
    public void MoveDown(Vector3 LookRotation)
    {
        if(!isMoving)
        {
            StartCoroutine(StartMovement(transform.position + Vector3.back));
            //transform.position += Vector3.back;
            LookRotation = new Vector3(0, 90, 0);
            Daruma.transform.rotation = Quaternion.Euler(LookRotation.x, LookRotation.y, LookRotation.z);
        }
    }


    IEnumerator StartMovement(Vector3 Position)
    {
        isMoving = true;
        while (transform.position.x != Position.x)
        {
            Debug.Log("Moving from: " + transform.position.x + " " + transform.position.y +" "+ transform.position.z + " to: " + Position.x+ " " +Position.y+" " +Position.z);
            transform.position = Vector3.MoveTowards(transform.position, Position, moveSpeed * Time.deltaTime);
            yield return null;
            
        }
        while (transform.position.z != Position.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, Position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;


    }
}
