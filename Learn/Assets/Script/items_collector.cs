using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AllControl;

public class items_collector : MonoBehaviour
{
    int cherries = GameManager.Instance.score;

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;

            GameManager.Instance.score = cherries;

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cherriesText.text = "Cherries:" + cherries;//实际游戏中初始值设为cherries：0，但是该代码将覆盖并显示正确计数
    }
}
