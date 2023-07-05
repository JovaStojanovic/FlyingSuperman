using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip hitSound, jumpSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("Dead");
        jumpSound = Resources.Load<AudioClip>("Jump");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Dead":
                audioSrc.PlayOneShot(hitSound); break;
            case "Jump":
                audioSrc.PlayOneShot(jumpSound); break;
        }
    }
}
