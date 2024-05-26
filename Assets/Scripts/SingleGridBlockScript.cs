using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGridBlockScript : MonoBehaviour
{
    public int _x;
    public int _y;
    public bool _isBlocked = false;
    public bool _isObstaclePlaced = false;

    public GameObject _obstacle;

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
