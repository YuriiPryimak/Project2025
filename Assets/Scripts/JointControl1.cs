using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointControl1 : MonoBehaviour
{
    public GameObject _camera;
    public float distanse = 5f;
    public Ind indicators;

    private GameObject currentObj;
    private bool canPickUp;

   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) PickUp();
        if (Input.GetKeyDown(KeyCode.Mouse1)) Drop();
        if (Input.GetKeyDown(KeyCode.E)) Eat();
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, distanse))
        {
            if (hit.transform.CompareTag("food"))
            {
                if (canPickUp) Drop();
                currentObj = hit.transform.gameObject;
                currentObj.GetComponent<Rigidbody>().isKinematic = true;
                currentObj.transform.parent = transform;
                currentObj.transform.localPosition = Vector3.zero;
                currentObj.transform.localEulerAngles = Vector3.zero;
                canPickUp = true;

               
            }
        }
    }

    void Drop()
    {
        if (currentObj != null)
        {
            currentObj.transform.parent = null;
            currentObj.GetComponent<Rigidbody>().isKinematic = false;
            canPickUp = false;
            currentObj = null;

        }
    }

    void Eat()
    {
        if (currentObj != null && currentObj.CompareTag("food"))
        {
            

            if (indicators != null)
            {
                indicators.IncreaseFood(20);
            }
           
            Destroy(currentObj);
            canPickUp = false;
            currentObj = null;
        }
        else
        {
            
        }
    }
}

