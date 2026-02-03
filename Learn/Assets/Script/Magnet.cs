using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    /*private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    [SerializeField] private GameObject magnet;
    [SerializeField] private string magnetName;
    bool judeg1 = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        //bc1=GetComponent<boxCollider2D>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == magnetName)
        {
            judeg1 = false;
        }
        else
        {
            judeg1 = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 magnet1pos = transform.position;
        Vector2 magnet2pos = magnet.transform.position;
        float distance = Vector2.Distance(magnet1pos, magnet2pos);
        if (distance >= 10f)//ÎÞÐ§
        {

        }
        else if (1f < distance && distance < 10f && judeg1 == true)//ÎüÒý
        {
            transform.position = Vector2.MoveTowards(
                magnet1pos,
                magnet2pos,
                Time.deltaTime * 1f);

        }
    }*/

        public bool N_redPole=true;
    
    
}