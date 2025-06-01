using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    // Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    public Text pickupText;

    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    // Update called once each frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
    }

    // Loop for playing audio proximity events - AudioSource Based
    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
        }
    }

    private void LevelCompleteCheck()
    {
        levelComplete = currentPickups >= maxPickups;
    }

    void Awake()
    {
        // No singleton here; no DontDestroyOnLoad.
        // This GameManager will be scene-specific.
    }
}
