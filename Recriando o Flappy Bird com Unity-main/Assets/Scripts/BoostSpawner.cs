using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    //private Rigidbody thisRigidBodyBoost;
    

    // Start is called before the first frame update
    void Start()
    {
    //thisRigidBodyBoost=GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        var gameManager=GameManager.Instance;
            if(gameManager.IsGameOver()){
            return;
            }


       
        if(gameManager.countedTime>=gameManager.boostTimeSpawn){
            //thisRigidBodyBoost.WakeUp();
            gameManager.boostTimeSpawn+=3f;
            gameManager.obstacleSpeed=7;
            gameManager.obstacleInterval=3;
            Debug.Log("Boost: "+gameManager.boostTimeSpawn);
            }   
    }


    


}
