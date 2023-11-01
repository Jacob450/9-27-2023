using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    private float time;
    public float spawntime;
    public GameObject[] enemy;

    int randomNum;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer();
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        if (time > spawntime)
        {
            time = 0;
            randomNum = Random.Range(0, enemy.Length);
            GameObject spawnedEnemy = Instantiate(enemy[randomNum]);
            spawnedEnemy.transform.position = transform.position;
        }
    }



    private void timer()
    {
        time += Time.deltaTime;
        

        
    }
}
