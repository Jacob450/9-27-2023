using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkMove : MonoBehaviour
{
    private float rotationSpeed;
    private float limit;
    private float current;
    bool down;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        rotationSpeed = 200;
        limit = 90;
        down = true;
    }

    // Update is called once per frame
    void Update()
    {
        forkmove();
    }

    private void forkmove()
    {
        if (current < limit && down == true ) 
        {
            transform.rotation = Quaternion.Euler(0, 0, (current));
            current += (rotationSpeed * Time.deltaTime);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, (current));
            current -= (rotationSpeed * Time.deltaTime);
        }
        
    }
}
