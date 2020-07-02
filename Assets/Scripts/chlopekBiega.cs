using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class chlopekBiega : MonoBehaviour
{
    private float minX = -2.8f;
    private float maxX = 2.8f;
    private Animator anim;
    private SpriteRenderer sr;

    float speed = 3f;

    public Text timer_Text;
    public Text pointText;
    private int timer;
    public int points = 0;
    public GameObject restartPanel;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(CountTime());
        timer = 0;
        restartPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        PlayerBounce();
        pointText.text = "x " + points.ToString();
    }

    void PlayerBounce()
    {
        Vector3 temp = transform.position;

        if( temp.x > maxX)
        {
            temp.x = maxX;
        }
        else if (temp.x < minX)
        {
            temp.x = minX;
        }

        transform.position = temp;

    }

    public void move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 temp = transform.position;

        if (h > 0)
        {
            temp.x += speed * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("chodzi", true);
        }
        else if (h < 0)
        {
            temp.x -= speed * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("chodzi", true);
        }
        else if (h == 0)
        {
            anim.SetBool("chodzi", false);
        }

        transform.position = temp;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(1f);
        timer++;

        timer_Text.text = "Czas:  " + timer;
        StartCoroutine(CountTime());
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Knife")
        {
            restartPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
            
            //StartCoroutine(RestartGame());
            
        }

        if (collider.tag == "Apple")
        {
            points++;
            Destroy(collider.gameObject);
        }

        
    }

    

    
}
