using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField] protected string sceneName;
    [SerializeField] private GameObject continueButton;
    [SerializeField] protected UI_FadeScreen fadeScreen;

    protected AudioSource fadeAudioSource;
    protected void Start()
    {
        if (SaveManager.instance.HasSavedData() == false)
            continueButton.SetActive(false);
        AudioSource audioSource = GetComponent<AudioSource>();
    }

    protected void ContinueGame()
    {
        
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    protected void NewGame()
    {
        SaveManager.instance.DeleteSavedData();
        StartCoroutine(LoadSceneWithFadeEffect(1.5f));
    }

    protected void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    protected IEnumerator LoadSceneWithFadeEffect(float _delay)
    {
        fadeAudioSource.PlayOneShot(fadeAudioSource.clip);
        fadeScreen.FadeOut();

        yield return new WaitForSeconds(_delay);

        SceneManager.LoadScene(sceneName);
    }
}
