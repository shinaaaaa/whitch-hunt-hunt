using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    float itemTimer = 0.0f, itemDestroy = 1.5f;
    void Start(){
        
    }

    void Update(){
        itemTimer += Time.deltaTime;
        if(itemTimer>=itemDestroy){
            Destroy(this.gameObject);
        }
    }
}
