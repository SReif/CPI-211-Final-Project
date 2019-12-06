using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudio : MonoBehaviour
{
    private AudioManager audio;
    private SceneLoader scene;

    void Awake()
    {
        audio = FindObjectOfType<AudioManager>();
        scene = FindObjectOfType<SceneLoader>();

        audio.Stop();
        scene.playing = false;
    }
}
