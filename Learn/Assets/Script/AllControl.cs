using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllControl : MonoBehaviour
{
    public static class charge
    {
        // 静态变量：属于 charge 类本身，全局唯一
        public static bool positive_charge = true;
    }
    public class GameManager
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameManager();
                return _instance;
            }
        }
        public int score = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
