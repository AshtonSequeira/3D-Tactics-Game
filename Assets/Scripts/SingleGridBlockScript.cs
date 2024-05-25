using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGridBlockScript : MonoBehaviour
{
    public int _x;
    public int _y;

    [SerializeField] Material[] _materials;
    public int _colour = 0;
    Renderer _renderer;

    public void SetColour()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
        _renderer.material = _materials[_colour];
    }

    
}
