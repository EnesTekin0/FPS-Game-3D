using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;
    public float openSpeed;
    private bool doorOpen;
 
    void Update()
    {
        if (doorOpen && doorModel.position.z != -2f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y,-2f), openSpeed * Time.deltaTime);
             
            if(doorModel.position.z == -2f)
            {
                colObject.SetActive(false);
            }
        }
        else if (!doorOpen && doorModel.position.z != -0f)
        {
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y,-0f), openSpeed * Time.deltaTime);
             
            if(doorModel.position.z == -0f)
            {
                colObject.SetActive(true);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.tag == "Player")
        {
        doorOpen = true;
        }
    }
    private void OnTriggerExit2D (Collider2D other)
    {
    if (other.tag == "Player")
        {
        doorOpen = false;
        }
    }
    
}
