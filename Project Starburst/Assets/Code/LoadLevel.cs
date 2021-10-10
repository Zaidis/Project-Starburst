using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public Animator transition;
    public float waitTime = 1f;

    public static LoadLevel instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) {
           ReloadCurrentLevel(); 
        }
    }

    public void LoadNextLevel() 
    {
        
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
        if (MusicManager.instance != null)
            MusicManager.instance.Transition(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadNextLevel(0));
        if (MusicManager.instance != null)
            MusicManager.instance.LoadMenuMusic();
    }

    public void ReloadCurrentLevel()
    {
        StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void GoToDeathScreen()
    {
        // Enter state
    }

    IEnumerator LoadNextLevel(int levelIndex) 
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelIndex);
    }
}
