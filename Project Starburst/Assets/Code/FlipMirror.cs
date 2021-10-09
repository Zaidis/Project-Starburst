using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMirror : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void Start()
    {
        cam.projectionMatrix *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
    }

}
