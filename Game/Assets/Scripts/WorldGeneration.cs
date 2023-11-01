using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    public GameObject ground;
    public GameObject[] obstacles; 
    bool isFloor;
    // Start is called before the first frame update
    void Start()
    {
       
        isFloor = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        createFloor();
        
        //Debug.Log(transform.position.x);
    }

    private void createFloor()
    {
        if (isFloor == false)
        {
            
            GameObject spawnedFloor = Instantiate(ground);
            spawnedFloor.transform.position = new Vector2(transform.position.x-1, 0);
        }
        isFloor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isFloor = false;
            //Debug.Log(isFloor);
        }

    }
    
}
