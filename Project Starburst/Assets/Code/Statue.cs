using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    /*
     * Need:
     * Follow the player by saving player object
     * When not in camera, move towards the player
     */

    [SerializeField]
    private GameObject m_playerObj;

    // This is on the object itself
    private Renderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (m_renderer.isVisible)
        {
            print("In view");
        }
        else
        {
            print("Not in view");
        }
    }
}
