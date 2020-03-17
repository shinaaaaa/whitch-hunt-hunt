using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    Vector3 enemyPos,movePos;
    bool pos_setted = false;
    Rigidbody2D enemyRB2D;
    float timer = 0.0f, destroyTime = 3.0f;
    void Start(){
        enemyPos = this.transform.position;
        enemyRB2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        SetPos();
        timer += Time.deltaTime;
        if(timer>=destroyTime){
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate(){
        if(pos_setted==true){
            Move();
        }
    }
    void SetPos(){
        if (pos_setted == false){
            if (enemyPos.y == 12.0f){
                movePos = new Vector3(Random.Range(12.0f, -12.0f), -12.0f, 0.0f);
            }
            if (enemyPos.y == -12.0f){
                movePos = new Vector3(Random.Range(12.0f, -12.0f), 12.0f, 0.0f);
            }
            if (enemyPos.x == 14.7f){
                movePos = new Vector3(-14.0f, Random.Range(11.0f, -11.0f), 0.0f);
            }
            if (enemyPos.x == -14.7f){
                movePos = new Vector3(14.0f, Random.Range(11.0f, -11.0f), 0.0f);
            }
        }
        pos_setted = true;
        }
    void Move(){
        Vector2 MoveDir = Vector2.Scale((movePos - enemyPos), new Vector2(1, 1)).normalized;//移動する方向を求める
        enemyRB2D.velocity = MoveDir * 20;
    }
}
