using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;


    [SerializeField]
    GameObject tripleShotBonusPrefab;

    [SerializeField]
    GameObject enemyContainer;

    bool stopSpawning = false;

    // Start is called before the first frame update
    IEnumerator SpawnRoutine(){
        
        while(stopSpawning == false){

            Vector3 position = new Vector3(Random.Range(-9.4f, 9.4f), 7.4f, 0);
            GameObject new_enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            new_enemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnBonusRoutine(){
        while(stopSpawning == false){

            Vector3 position = new Vector3(Random.Range(-9.4f, 9.4f), 7.4f, 0);
            Instantiate(tripleShotBonusPrefab, position, Quaternion.identity);
            yield return new WaitForSeconds(20.0f); // bonusun gelme süresi
        }
    }

    public void OnPlayerDeath(){
        stopSpawning = true;
    }

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
