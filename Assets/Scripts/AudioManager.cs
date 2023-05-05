using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource enemyTheme;

    private void Awake()
    {
        enemyTheme = GetComponent<AudioSource>();
        enemyTheme.playOnAwake = true;
        enemyTheme.loop = true;
        enemyTheme.volume = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
