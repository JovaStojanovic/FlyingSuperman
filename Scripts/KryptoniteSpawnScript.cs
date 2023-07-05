using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KryptoniteSpawnScript : MonoBehaviour
{

    public GameObject kryptonite;
    public float spawnRate;
    private float timer = 0;    
    public float heightOffset;

    // Start is called before the first frame update
    void Start()
    {
        spawnKryptonite();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } else
        {
            spawnKryptonite();
            timer = 0;
        }
    }
    void spawnKryptonite()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(kryptonite, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
    }
}
