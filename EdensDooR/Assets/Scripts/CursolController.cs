using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursolController : UI_MainMenu
{
    AudioSource audioSource;

    new void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Start();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(audioSource.clip);
            transform.Translate(0f, -150f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(audioSource.clip);
            transform.Translate(0f, 150f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y >= -115f)
                NewGame();
        }
    }
}