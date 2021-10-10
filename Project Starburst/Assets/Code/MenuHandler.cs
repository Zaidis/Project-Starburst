using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_normalTextElements, m_tutorialTextElements;

    // Start is called before the first frame update
    void Start()
    {
        //ToggleTutorial(false);
    }    

    public void ToggleTutorial(bool enableTutorial)
    {
        LoadLevel.instance.buttonPress.Play(0);
        foreach (GameObject obj in m_normalTextElements)
        {
            obj.SetActive(!enableTutorial);
        }

        foreach (GameObject obj in m_tutorialTextElements)
        {
            obj.SetActive(enableTutorial);
        }
    }
}
