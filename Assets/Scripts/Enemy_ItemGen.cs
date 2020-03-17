using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ItemGen : MonoBehaviour
{
    public GameObject enemyPrefabs, itemPrefabs;
    GameObject[] enemyTags, itemTags;
    int randomVale=0;
    float spawnTimer = 0.0f, interval = 0.8f,itemSpawnTimer=0.0f;
    void Start(){
        
    }

    void Update(){
        enemyTags = GameObject.FindGameObjectsWithTag("Enemy");
        itemTags = GameObject.FindGameObjectsWithTag("Heal");
        Debug.Log(enemyTags.Length);
        spawnTimer += Time.deltaTime;
        itemSpawnTimer += Time.deltaTime;
        randomVale = Random.Range(1, 5);
        if (spawnTimer >= interval){
            if (enemyTags.Length <= 8){
                GameObject enemy = Instantiate(enemyPrefabs) as GameObject;
                if (randomVale == 1) enemy.transform.position = new Vector3(Random.Range(12.5f, -12.5f), 12.0f, 0.0f);
                else if (randomVale == 2) enemy.transform.position = new Vector3(Random.Range(12.5f, -12.5f), -12.0f, 0.0f);
                else if (randomVale == 3) enemy.transform.position = new Vector3(14.7f, Random.Range(10.0f, -10.0f), 0.0f);
                else if (randomVale == 4) enemy.transform.position = new Vector3(-14.7f, Random.Range(10.0f, -10.0f), 0.0f);
            }
            spawnTimer = 0.0f;
        }
        if (itemSpawnTimer >= interval){
            if (itemTags.Length <= 1){
                GameObject item = Instantiate(itemPrefabs) as GameObject;
                item.transform.position = new Vector3(Random.Range(11.0f, -11.0f), Random.Range(7.0f, -7.0f), 0.0f);
                itemSpawnTimer = 0.0f;
            }
        }
    }
}
