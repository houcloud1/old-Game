using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclusionMagnet : MonoBehaviour
{
    [SerializeField] private float repelforce = 5f;
    [SerializeField] private int distan = 5;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    //[SerializeField] private char[] magnetProperty = { 'N', 'S' };
    //下方代码试图获取所有含magnet组件的游戏对象（已完成），并使其自动选择其他对象进行作用，产生磁力效果（未完成）
    [Header("包含 Magnet 组件的所有游戏对象")] // 可选：添加标题提高可读性
    public List<GameObject> magnetGameObjects = new List<GameObject>();

    // 收集并显示游戏对象
    public void AddForceToMagnetObjects()
    {
        
        // 清空现有列表
        magnetGameObjects.Clear();

        // 1. 先获取所有 Magnet 组件
        Magnet[] allMagnets = FindObjectsOfType<Magnet>();//目前仅仅获取所有magnet组件
        
        // 2. 提取每个组件所属的游戏对象，添加到列表
        foreach (Magnet magnet in allMagnets)
        {
            magnetGameObjects.Add(magnet.gameObject);
        }
        Vector3[] magnetpos = new Vector3[allMagnets.Length];//建立vector3数组
        for(int t = 0; t < magnetGameObjects.Count; t++)
        {
            // 检查对象是否存在（避免空引用错误）
            if (magnetGameObjects[t] != null)
            {
                magnetpos[t] = magnetGameObjects[t].transform.position;//获取所有磁力组件的方位
            }
        }
        for (int i=0;i< allMagnets.Length;i++)//bug出现如果都是S，无反应，都是N，一方排斥一方，同时一方吸引一方，相异时，s吸引n的同时N排斥S（两个物体受到同一方向的力）
        {
            for (int j = i + 1; j < allMagnets.Length; j++) //两个for循环补充不漏地遍历每一个i,j组合，每组排序唯一如0和1，只存在（0，1），不存在（1，0）
                                                            //也不存在两个相同的数组合如（1，1），（0，0）
            {
                GameObject targetObj = rb.gameObject;
                int index = magnetGameObjects.IndexOf(targetObj);
                float distance = Vector3.Distance(magnetpos[i], magnetpos[j]);
                if(index==i)
                {
                    if (0 < distance && distance < distan && (allMagnets[i].N_redPole == allMagnets[j].N_redPole))//排斥
                    {
                        Vector2 repelDirection = (magnetpos[i] - magnetpos[j]).normalized;
                        rb.AddForce(repelDirection * repelforce * 1/(distance * distance));//库伦磁定律F=k*q1q2/r^2,1/(distance * distance)模拟1/r^2，磁力和距离的变化关系
                    }
                    else if (0 < distance && distance < distan && (allMagnets[i].N_redPole || allMagnets[j].N_redPole))//吸引
                    {
                        Vector2 repelDirection = -(magnetpos[i] - magnetpos[j]).normalized;
                        rb.AddForce(repelDirection * repelforce * 1 / (distance * distance));
                    }
                }
                else if(index == j)//关于index的if和else if是为了防止两个物体受同一方向的力
                {
                    if (0 < distance && distance < distan && (allMagnets[i].N_redPole == allMagnets[j].N_redPole))//排斥
                    {
                        Vector2 repelDirection = -(magnetpos[i] - magnetpos[j]).normalized;
                        rb.AddForce(repelDirection * repelforce * 1 / (distance * distance));
                    }
                    else if (0 < distance && distance < distan && (allMagnets[i].N_redPole || allMagnets[j].N_redPole))//吸引
                    {
                        Vector2 repelDirection = (magnetpos[i] - magnetpos[j]).normalized;
                        rb.AddForce(repelDirection * repelforce * 1 / (distance * distance));
                    }
                }

            }
                
        }
        
    }
    /*void GetActionGameObject()//获取所有game object组件
    {
        foreach (GameObject magnetObj in magnetGameObjects)
        {
            // 检查对象是否存在（避免空引用错误）
            if (magnetObj != null)
            {
                magnetObj
            }
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        // 可选：游戏启动时自动收集一次
        //AddForceToMagnetObjects();  
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AddForceToMagnetObjects();
        /*else
        {
            rb.velocity = Vector2.zero;
        }*/
    }
}