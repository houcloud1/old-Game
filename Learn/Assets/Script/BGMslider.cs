using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGMslider : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bgmAudio;
    public Slider volumeSlider;


    // Update is called once per frame
    void Update()
    {
        bgmAudio.volume = volumeSlider.value;
    }
}
