using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jablkoZnika : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Apple")
        {
            delay();
            Destroy(collider.gameObject);
        }    
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
    }

}
