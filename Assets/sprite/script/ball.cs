using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100.0f;

    public int score = 0;
    public Text scoreText;


    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    float hitFactor(Vector2 ballpos, Vector2 racketpos ,float racketWidth)
    {
        return (ballpos.x - racketpos.x) / racketWidth;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "the player")
        {
            float x = hitFactor(transform.position, other.transform.position, other.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }

        if (other.gameObject.tag == "block")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "score :" + score.ToString();
        }

        if (other.gameObject.tag == "finish")
        {
            SceneManager.LoadScene("SampleScene");
        }


        if (other.gameObject.tag == "block2pts")
        {
            Destroy(other.gameObject);
            score= score+2;
            scoreText.text = "score :" + score.ToString();
        }

        if (other.gameObject.tag == "block3pts")
        {
            Destroy(other.gameObject);
            score= score+3;
            scoreText.text = "score :" + score.ToString();
        }
    }





}
