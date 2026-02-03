using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static AllControl;

public class FInish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelCompleted = false;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("chufa");
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.name=="player"&&!levelCompleted))
        {
            finishSound.Play();  
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
