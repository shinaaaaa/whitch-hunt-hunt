using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {
    GameObject Player;
    float speed=80;
    public GameObject c_pointPrefab;
    Rigidbody2D playerRB2D;
    bool ATK=false,drag=false;
    GameObject director,score;
    [SerializeField] AudioClip moveSE = null;
    AudioSource sePlyer;

    void Start () {
        playerRB2D = gameObject.GetComponent<Rigidbody2D> ();
        director=GameObject.Find("GameDirector");
        score = GameObject.Find("Score");
        score.GetComponent<Score>().DeleteScore();
        sePlyer = GetComponent<AudioSource>();
    }
    void Update() {
        if(Input.GetMouseButtonUp(0))drag = false;
        if(Input.GetMouseButtonDown(0))this.ClickToMove ();
        this.DragToMove();
    }
    void OnTriggerEnter2D (Collider2D other) {
        if(other.gameObject.tag=="c_point"){ //c_pointに衝突したら
            GameObject c_pointDestroy = GameObject.FindGameObjectWithTag("c_point");
            Destroy(c_pointDestroy); //c_pointを削除
            playerRB2D.velocity=Vector2.zero; //playerRB2Dを停止
            ATK = false; //ATK判定を停止
        }else if(other.gameObject.tag=="Enemy"){ //Enemyに衝突
            if (ATK == true){ //ATK判定があれば
                score.GetComponent<Score>().PointsUP(); //PointsUpを実行
            }else if(ATK==false){//ATK判定がなければ
                director.GetComponent<GameDirector>().HP_Down();//PointsDownを実行
            }
            Destroy(other.gameObject);
        }else if(other.gameObject.tag=="Heal"){
            Destroy(other.gameObject);
            director.GetComponent<GameDirector>().HP_UP();
        }
    }
    void ClickToMove () {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//マウス座標をワールド座標へ変換
            RaycastHit2D hit = Physics2D.Raycast(pos, new Vector2(0, 0), 100);//Rayを放つ
            //Debug.Log(hit.collider.gameObject.name);
        if(hit.collider==null||hit.collider.tag=="Enemy"||hit.collider.tag=="Heal"){//Rayが当たったのがnullならば
            GameObject c_point = Instantiate(c_pointPrefab) as GameObject;//c_pointを生成
            c_point.transform.position = new Vector3(pos.x, pos.y, 0);//クリックした座標へ配置
            Vector2 p1 = playerRB2D.position;//playerRB2Dの座標
            Vector2 MoveDir = Vector2.Scale((pos - p1), new Vector2(1, 1)).normalized;//移動する方向を求める
            playerRB2D.velocity = MoveDir * speed;//playerRB2Dに加速度を与える
            ATK = true;//攻撃判定を発生させる
        }else if(hit.collider.gameObject.name=="Player")//playerならば
        drag = true;//ドラッグ判定を発生させる
        sePlyer.PlayOneShot(moveSE);
    }
    void DragToMove(){
        if(drag==true){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerRB2D.transform.position = pos;
        }
    }
}