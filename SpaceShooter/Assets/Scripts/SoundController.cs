using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eSoundEffectID
{
    ExpAst, ExpEnemy, ExpPlayer, FireEnemy, FirePlayer
}

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public AudioSource BGM, EffectSound;
    public AudioClip[] BGMClip, EffectClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeBGM(0);
    }

    public void ToggleEffectSound(bool On)
    {
        if (On)
        {
            EffectSound.volume = 1;
        }
        else
        {
            EffectSound.volume = 0;
        }
    }

    public void ChangeBGM(int bgmID)
    {
        BGM.clip = BGMClip[bgmID];
        BGM.volume = 1;
        BGM.Play();
    }

    public void PlayEffectSound(int effectID)
    {
        EffectSound.PlayOneShot(EffectClip[effectID]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
