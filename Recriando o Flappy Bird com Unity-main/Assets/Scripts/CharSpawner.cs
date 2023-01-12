using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpawner : MonoBehaviour
{
    // Start is called before the first frame update
private float cooldown = 0f;
    void Start()
    {
    var gameManager=GameManager.Instance;
    

    int prefabIndex = Random.Range(0,gameManager.charPrefabs.Count);
    GameObject prefab = gameManager.charPrefabs[prefabIndex];
    float x=gameManager.charOffsetX;
    float y=gameManager.charOffsetY;
    float z=gameManager.charOffsetZ;
    Vector3 position=new Vector3(x,y,z);
    Quaternion rotation = prefab.transform.rotation;
    Instantiate(prefab,position,rotation);    
    }

    // Update is called once per frame
    void Update()
    {
     var gameManager=GameManager.Instance;
     if(gameManager.IsGameOver()){
        return;
     }
    
      
    }
}
