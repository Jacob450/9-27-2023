using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    public bool didCollide;
    // Start is called before the first frame update
    void Start()
    {
        didCollide = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("True");
            didCollide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("False");
        didCollide = false;
    }

    public bool getCollide()
    {
        return didCollide;
    }

    public void setCollide(bool value)
    {
        didCollide=value;
    }
}