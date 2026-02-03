using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject menuList;

    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgm;
    // Start is called before the first frame update
    public void OnSetButtonClick()
    {
        if (menuKeys)
        {
            menuList.SetActive(true);
            menuKeys = false;
            Time.timeScale = 0;
            bgm.Pause();
        }
        else { 
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;
            bgm.Play();
        }
    }
    public void Return()
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;
        bgm.Play();
    }
    public void Restart()
    {
        Scene currentSence = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentSence.name);
        Time.timeScale = 1;
    }
    public void Exit()
    {

        SceneManager.LoadScene(0);
    }
}
