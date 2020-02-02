using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSelector : MonoBehaviour
{
    public List<AudioClip> SoundList;
    List<AudioClip> availableSounds;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        availableSounds = SoundList;
        roundRobinQueue();
    }

    // Update is called once per frame
    void Update()
    {
         if(!audioSource.isPlaying){
         roundRobinQueue();   
        }        
    }
    void roundRobinQueue(){
        if(availableSounds.Count == 0){
            availableSounds = SoundList;
        }
        int number = Random.Range(0, availableSounds.Count);
        AudioClip sound = availableSounds[number];
        availableSounds.RemoveAt(number);
        audioSource.clip = sound;
        audioSource.Play();
    }
}
