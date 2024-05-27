using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGridBlockScript : MonoBehaviour
{
    public int _x;
    public int _y;
    public bool _isBlocked = false;
    [HideInInspector] public bool _isObstaclePlaced = false;

    public GameObject _obstacle;

    [SerializeField] Material[] _materials;
    [HideInInspector] public int _colour = 0;
    Renderer _renderer;

    public int _gCost;
    public int _hCost;
    public int _fCost;

    public SingleGridBlockScript _cameFromNode;

    public void SetColour()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.enabled = true;
        _renderer.material = _materials[_colour];
    }

    public void CalculateFCost()
    {
        _fCost = _gCost + _hCost;
    }


}
