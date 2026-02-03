using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_platform : MonoBehaviour
{
    [SerializeField] bool platcharge;
    //[SerializeField] private BoxCollider2D targetCollider;
    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void EnableCollider()
    {
        boxCollider.enabled = true;
    }
    private void ProhibitedCollider()
    {
        boxCollider.enabled = false;
    }
    /*private void OnTriggerStay2D(Collider2D collision)//改进通过碰撞进行触发的问题，防止转换性质后第一次碰撞仍然会碰到
    {
        if(collision.gameObject.name== "player"&&AllControl.charge.positive_charge==platcharge)
        {
            EnableCollider();
        }
        else
        {
            ProhibitedCollider();
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        if (AllControl.charge.positive_charge == platcharge)
            EnableCollider();
        else if (AllControl.charge.positive_charge != platcharge)
            ProhibitedCollider();
    }
}
