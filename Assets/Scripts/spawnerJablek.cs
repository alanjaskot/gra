using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerJablek : MonoBehaviour
{

    public GameObject apple;
    private float minX = -2.8f;
    private float maxX = 2.8f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zacznijSpawn());
    }

    IEnumerator zacznijSpawn()
    {
        yield return new WaitForSeconds(Random.Range(4f, 9f));

        GameObject k = Instantiate(apple);

        float x = Random.Range(minX, maxX);

        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(zacznijSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
