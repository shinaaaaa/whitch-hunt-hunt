using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] AudioClip downSE = null, healSE = null;
    AudioSource sePlyer;
    int playerHP=3;
    string playerHP_string;
    GameObject hp_UI,enemy;
    void Start(){
        hp_UI = GameObject.Find("HP_UI");
        sePlyer = GetComponent<AudioSource>();
    }

    void Update(){
        if (playerHP == 3) playerHP_string = "iii";
        if (playerHP == 2) playerHP_string = "ii";
        if (playerHP == 1) playerHP_string = "i";
        if (playerHP == 0) SceneManager.LoadScene("Result");
        this.hp_UI.GetComponent<Text>().text = playerHP_string;
        enemy = GameObject.Find("Enemy");
        if(enemy==null)SceneManager.LoadScene("Result");
    }
        public void HP_UP() {
        if (playerHP != 3){
            playerHP += 1;
        }
        sePlyer.PlayOneShot(healSE);
    }
    public void HP_Down() {
        playerHP -=1;
        sePlyer.PlayOneShot(downSE);
    }
}
