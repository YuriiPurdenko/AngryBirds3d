using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    public static GamePlayManager instance;
    [SerializeField] Vector3 shootPosition;
    public int maxScore;
    public bool inAir = false;

    [SerializeField] public GameObject[] players;
    [HideInInspector] public int score = 0, enemy;
    [SerializeField] public int alivePlayersCount;

    void Awake() {
        makeInstance();
        alivePlayersCount = players.Length;
    }

    void Start(){
        nextPlayerToShoot();
    }


    void makeInstance(){
         if(instance == null){
            instance = this;
        }
    }

    void Update(){
        GameControllerScript.instance.setScore(score);
        if(alivePlayersCount == 0 && (maxScore / 2) > score){
            enabled = false;
            GameControllerScript.instance.gameOver(score,maxScore);
        }
        else if(alivePlayersCount == 0){
            int spriteNumber = chooseMedal();
            enabled = false;
            GameControllerScript.instance.completeLevel(score, maxScore, spriteNumber);
        }
        else if(enemy == 0){
            int spriteNumber = chooseMedal();
            enabled = false;
            GameControllerScript.instance.completeLevel(score + alivePlayersCount * 100, maxScore, spriteNumber);
        }
    }



    int chooseMedal(){
        if(score >= maxScore){
            return 0;
        }
        else if(score > (maxScore / 2)){
            return 1;
        }
        else{
            return 2;
        }
    }

    public void nextPlayerToShoot(){
        for(int i = 0; i < players.Length ; i++){
            if(players[i].activeInHierarchy){
                 players[i].GetComponent<Player>().enabled = true;
                 players[i].GetComponent<Rigidbody>().isKinematic = false;   
                 players[i].transform.position = shootPosition;
                 break;
            }
        }
    } 
}
