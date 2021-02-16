using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    public Transform Obstruction;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        Obstruction = Target;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ViewObstucted();
    }

    void ViewObstucted()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,Target.position-transform.position,out hit,10.0f))
        {
            if(hit.collider.tag =="Enviroment")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            else
            {
                MakeVisible();
            }

        }

    }

    public void MakeVisible()
    {
        Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
    }
}
