using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{
        get;private set;
    }
    [FormerlySerializedAs("prefabs")]
    public float obstacleInterval=3f;

    public float charInterval=1f;

    public float obstacleSpeed=7f;
    public Vector2 obstacleOffsetY = new Vector2(0,0);
    public float obstacleOffsetX = 0f;

    public float charOffsetY = 0f;
    public float charOffsetX = 0f;
    public float charOffsetZ = 0f;

    [HideInInspector]
    public float score;

    private bool isGameOver = false;
    public List<GameObject> obstaclePrefabs;
    public List<GameObject> charPrefabs;

    [HideInInspector]
    public float countedTime = 0f;

    private float lastTime = 0f;

    public float boostTimeSpawn = 3f;

    [HideInInspector]
    public float countBoost=0f;

    void Awake() {
        if(Instance!=null&&Instance!=this){
            Destroy(this);
        }else{
            Instance = this;
        }
        
    }


    public bool IsGameActive(){
       return !isGameOver;
    }

    public bool IsGameOver(){
        return isGameOver;
    }
    public void EndGame(){
        isGameOver = true;
        Debug.Log("Game Over... Your Score is "+GameManager.Instance.score+"\n Your count of boosters: "+countBoost);
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay){
        yield return new WaitForSeconds(delay);
        
        string sceneName=SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload Scene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countedTime += Time.deltaTime;
        lastTime=2;
        if(countedTime>=lastTime){
        obstacleSpeed+=0.008f;
        obstacleInterval-=0.0015f;
        lastTime+=2;
        }
        //Debug.Log("C T: "+countedTime);
        //Debug.Log("O I: "+obstacleInterval);
    }
}
