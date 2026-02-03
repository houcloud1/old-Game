using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AllControl;


public class CharacterProperties : MonoBehaviour
{
    private GameObject ElecCircle;
    private SpriteRenderer spriteRenderer;
    Color ElecColor;
    // Start is called before the first frame update
    void Start()
    {
        // 步骤1：查找名为 "ElecCircle" 的游戏对象
        ElecCircle = GameObject.Find("ElecCircle");
        if (ElecCircle == null)
        {
            Debug.LogError("未找到名为 ElecCircle 的对象！");
            return;
        }

        // 步骤2：获取 SpriteRenderer 组件
        spriteRenderer = ElecCircle.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("ElecCircle 上没有 SpriteRenderer 组件！");
            return;
        }

        // 步骤3：获取颜色（Color 类型，包含 r, g, b, a 分量）
        ElecColor = spriteRenderer.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        //使人物进行正负转换
        if (Input.GetKeyDown(KeyCode.E))
        {
            charge.positive_charge = !charge.positive_charge;
            Debug.Log(charge.positive_charge);
            Debug.Log("Before:"+$"ElecCircle 颜色：R={ElecColor.r}, G={ElecColor.g}, B={ElecColor.b}, A={ElecColor.a}");
        }
        if(charge.positive_charge==true)
        {
            ElecColor = new Color(1, 1, 1, 1);
            spriteRenderer.color = ElecColor;
        }
        else if(charge.positive_charge==false)
        {
            ElecColor = new Color(0, 0, 0, 1);
            spriteRenderer.color = ElecColor;
        }
        
    }
}
