using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private Slider soundVFX;
    [SerializeField] private Slider soundGame;

    [SerializeField] GameObject soundPlayer;
    [SerializeField] GameObject soundBullet;

    // Start is called before the first frame update
    void Start()
    {
        soundVFX.value = 0.5f;
        soundGame.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        soundPlayer.GetComponent<AudioSource>().volume = soundGame.value;
        soundBullet.GetComponent<AudioSource>().volume = soundVFX.value;
    }


}
