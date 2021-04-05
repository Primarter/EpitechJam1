using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAnimation : MonoBehaviour
{
    public AudioClip voice;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void PlayVoice()
    {
        GetComponent<AudioSource>().PlayOneShot(voice   );
    }

    void GoToGameScene()
    {
        SceneManager.LoadScene("Level_01");
    }
}
