using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class spawnerNozy : MonoBehaviour
{ 
    public GameObject knife;
    private float minX = -2.8f;
    private float maxX = 2.8f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zacznijSpawn());
    }
    
    IEnumerator zacznijSpawn()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));

        GameObject k = Instantiate(knife);

        float x = Random.Range(minX, maxX);

        k.transform.position = new Vector2(x, transform.position.y);

        StartCoroutine(zacznijSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
