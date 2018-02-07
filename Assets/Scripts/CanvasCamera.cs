using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    private Canvas _Canvas;

    private void Awake()
    {
        _Canvas = GetComponent<Canvas>();
        _Canvas.worldCamera = Camera.main;
    }
}
