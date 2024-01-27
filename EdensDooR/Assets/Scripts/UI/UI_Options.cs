using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Options : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] UI_FadeScreen fadeScreen;

    AudioSource fadeAudioSource;
    void Start()
    {
        fadeAudioSource = GetComponent<AudioSource>();
    }
    public void ExitGame()
    {
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }
    IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeAudioSource.PlayOneShot(fadeAudioSource.clip);
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
    }
}