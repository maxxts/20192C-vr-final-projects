using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipabbleItem : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();        
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
