using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int ghostCount = 0;
    public GameObject ghostPrefab;
    float timer = 0f;
    public GameObject character;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(spawnEnemyCoroutine());
    }

    //IEnumerator spawnEnemyCoroutine()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(10);
    //    }
    //}

    void Update()
    {
        
        if (timer <= 10f)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            spawner();
        }
    }

    public void spawner()
    {
        GameObject gP = Instantiate(ghostPrefab, SetRandomPosition(), Quaternion.identity);
        ghostCount++;
        gameManager.GetComponent<KillTarget>().targets.Add(gP);
        gP.GetComponent<Wanderer>().myTarget = character;
    }

    Vector3 SetRandomPosition()
    {
        float x = Random.Range(-35.0f, 35.0f);
        float z = Random.Range(-35.0f, 35.0f);
        float y = .7f;

        Vector3 newVector = new Vector3(x, y, z);

        return newVector;
    }    

}
