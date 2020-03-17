using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] AudioClip upSE = null;
    AudioSource sePlayer;
    int points;
    GameObject pointsUI;
    void Start(){
        pointsUI= GameObject.Find("PointsUI");
        points=PlayerPrefs.GetInt ("Score", 0);
        sePlayer = GetComponent<AudioSource>();
    }
    void Update(){
        this.pointsUI.GetComponent<Text>().text = points+" points";
        if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("Main");
        }
    }
    public void PointsUP(){
        points += 10;
        Debug.Log("PointGet");
        sePlayer.PlayOneShot(upSE);
    }
    void OnDestroy(){
    // スコアを保存
    PlayerPrefs.SetInt ("Score", points);
    PlayerPrefs.Save ();
    }
    public void DeleteScore(){
        PlayerPrefs.DeleteKey("Score");
    }
}
