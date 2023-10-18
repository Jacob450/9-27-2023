using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public int buildingHeightLimit;
    private int builingHeight;
    

    public GameObject building;
    public GameObject location;
    

    // Start is called before the first frame update
    void Start()
    {
        
        spawnBuilding();

    }

    // Update is called once per frame
    private void spawnBuilding()
    {
        GameObject spawnedBuilding;
        int randomHeight = Random.Range(1,buildingHeightLimit);
        for(int i = 0; i < randomHeight; i++)
        {
            spawnedBuilding = Instantiate(building);

            spawnedBuilding.transform.position = new Vector2(location.transform.position.x, location.transform.position.y + i );
        }
        
    }

}
