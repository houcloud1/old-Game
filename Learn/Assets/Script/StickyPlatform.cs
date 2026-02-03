using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //设置父子关系以实现黏性平台效果，影响稳定性，不允许角色死亡时（禁用角色组件）设置父对象
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
    
    //新的代码，通过设置角色速度规避错误（不可用，角色速度不变）
    /*
    private Rigidbody2D rb;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            rb.velocity =new Vector2(0,2f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject targetObj = GameObject.Find("player");
        if (targetObj == null)
        {
            Debug.LogError("找不到名为 player 的游戏对象！");
            return;
        }
        rb = targetObj.GetComponent<Rigidbody2D>();
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
