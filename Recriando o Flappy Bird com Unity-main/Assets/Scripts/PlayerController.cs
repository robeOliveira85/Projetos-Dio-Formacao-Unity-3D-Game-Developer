using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidBody;
    public float jumpPower = 10f;
    public float jumpInterval = 0.2f;
    private float jumpCooldown = 0;

   
    // Start is called before the first frame update
    void Start()
    {
    thisRigidBody=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
      var gameManager=GameManager.Instance;
            if(gameManager.IsGameOver()){
            return;
            }


      var IsGameActive=GameManager.Instance.IsGameActive();
      jumpCooldown -= Time.deltaTime;
      bool canJump = jumpCooldown <=0&&IsGameActive;

      if(canJump){
      bool jumpInput = Input.GetKey(KeyCode.Space);  
        if(jumpInput){
          Jump();          
        }
       }
       thisRigidBody.useGravity=IsGameActive;
    }


 

    void OnCollisionEnter(Collision other) {
      OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other) {
      OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other){
      bool isSensor=other.gameObject.CompareTag("Sensor");
      bool isBoost=other.gameObject.CompareTag("Boost"); 
      if(isSensor){
        GameManager.Instance.score++;
        Debug.Log("Score: "+GameManager.Instance.score);
      }else if(isBoost){
        var gameManager=GameManager.Instance;
        if(gameManager.countedTime>=gameManager.boostTimeSpawn){
            gameManager.boostTimeSpawn+=3f;
            gameManager.obstacleSpeed=7f;
            gameManager.obstacleInterval=3f;
            gameManager.countBoost++;
            } 
        Destroy(other.gameObject);
      }else{
        GameManager.Instance.EndGame();
       }

    }
    private void Jump(){
      jumpCooldown = jumpInterval;
      thisRigidBody.velocity = Vector3.zero;
      thisRigidBody.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
      
    }

}
