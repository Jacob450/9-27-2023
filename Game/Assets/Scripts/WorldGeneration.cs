using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject floor;
    public GameObject player;
    private PlayerMovement pm;
    
    private float basePos;
    // Start is called before the first frame update
    void Start()
    {
        
        pm = player.GetComponent<PlayerMovement>();
        basePos = pm.getplayerposx();
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pm.getplayerposx() - basePos) ;
        gen();
    }

    private void gen()
    {
        if(pm.getplayerposx() - basePos > 20) 
        {
            GameObject floorgen;

            floorgen = Instantiate(floor);

            floorgen.transform.position = new Vector2 (pm.getplayerposx()+40, 20);
            basePos = pm.getplayerposx();
        
        }
    }
}
