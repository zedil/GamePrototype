using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    
    public GameObject boostPrefab; //defined boost prefab
    float TimeLeftToSpawn;  //defined remaining time to spawn 
    public float SpawnInterval;

    float randx, randy;

    void Start()
    {   
        //get the center of x position of the left wall
        //leftPos = GameObject.FindGameObjectWithTag("leftwall").transform.position.x;

        //get the width of the leftWall from its collider and add the half of it to the center of x position
        //leftPos += (GameObject.FindGameObjectWithTag("leftwall").transform.gameObject.GetComponent<BoxCollider2D>().size.x)/2;
        //Debug.Log(leftPos);
    }

    void Update()
    {
        //decrease the time left to spawn
        if(TimeLeftToSpawn >= 0)
        {
            TimeLeftToSpawn -= Time.deltaTime;
        }
        else
        {
            //when time left to spawn equals to zero spawn the object and set it to spawn interval
            SpawnAnObject();
            TimeLeftToSpawn = SpawnInterval;
        }

    }

    void SpawnAnObject()
    {
        
        //corners of the boost spawn points
        randx = Random.Range(-10.0f,+9.0f);
        randy = Random.Range(-4.0f,+2.0f);

        //spawn boost object randomly between the corners
        Instantiate(boostPrefab, new Vector3(randx, randy,0), Quaternion.identity);

        //boost.transform.position = new Vector2(randx,randy);
    }


}
