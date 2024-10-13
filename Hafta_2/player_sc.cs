using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_scr : MonoBehaviour
{
    public float speed = 5;

    public GameObject laserPrefab;

    float fireRate = 0.5f;

    float nextFire = 0f;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
     CalculateMovement();
     shoting();
    }
    void shoting(){
    if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire){
        Instantiate(laserPrefab, transform.position + new Vector3(0,0.8f,0),Quaternion.identity);
        nextFire = Time.time + fireRate;
        }
    }

    void CalculateMovement(){

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical,0);
        transform.Translate(direction*Time.deltaTime*speed);

        if(transform.position.y >= 0){// y nin maximum değeri
            transform.position = new Vector3(transform.position.x,0,0);
        }
        else if(transform.position.y <=-3.9f){// y nin minimum değeri
            transform.position = new Vector3(transform.position.x,-3.9f,0);
        }
        if(transform.position.x >=15.2f){// x in maximum değeri
            transform.position = new Vector3(-15.2f,transform.position.y,0);
        }
        else if(transform.position.x <=-15.2f){// x nin minimum değeri
            transform.position = new Vector3(15.2f,transform.position.y,0);
        }
    }
}
