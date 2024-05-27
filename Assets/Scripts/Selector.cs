using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Selector : MonoBehaviour
{
    [SerializeField] Material _highlightMaterial;
    [SerializeField] Material _selectMaterial;
    [SerializeField] GridGenerator _grid;

    Material _originalMaterial;
    Material _originalMaterial2;
    Transform _highlighted;
    public Transform _selected;
    public bool _isSelected = false;
    RaycastHit _raycastHit;

    [SerializeField] TMP_Text _coords;

    // Update is called once per frame
    void Update()
    {
        if(_highlighted != null)
        {
            _highlighted.GetComponent<Renderer>().material = _originalMaterial;
            _highlighted = null;

            _coords.text = "X : , Y : ";
        }

        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(_ray, out _raycastHit))
        {
            _highlighted = _raycastHit.transform;
            if(_highlighted.CompareTag("Selectable") && _highlighted != _selected)
            {
                if(_highlighted.GetComponent<MeshRenderer>().material != _highlightMaterial)
                {
                    _originalMaterial = _highlighted.GetComponent<MeshRenderer>().material;
                    _highlighted.GetComponent<MeshRenderer>().material = _highlightMaterial;

                    _coords.text = "X : " + _highlighted.GetComponent<SingleGridBlockScript>()._x + ", Y : " + _highlighted.GetComponent<SingleGridBlockScript>()._y;

                }
            }
            else
            {
                _highlighted = null;
            }

            if(_selected && _raycastHit.transform == _selected)
            {
                _coords.text = "X : " + _selected.GetComponent<SingleGridBlockScript>()._x + ", Y : " + _selected.GetComponent<SingleGridBlockScript>()._y;

            }

        }

        if (Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && _grid._isGridGenerated)
        {
            PlayerController _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

            if(_player._canMove)
            {
                if (_selected != null)
                {
                    _selected.GetComponent<Renderer>().material = _originalMaterial2;
                    _selected = null;
                    _isSelected = false;
                }

                if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(_ray, out _raycastHit))
                {
                    _selected = _raycastHit.transform;
                    if (_selected.CompareTag("Selectable"))
                    {
                        _originalMaterial2 = _originalMaterial;
                        _selected.GetComponent<MeshRenderer>().material = _selectMaterial;

                        _isSelected = true;

                    }
                    else
                    {
                        _selected = null;
                        _isSelected = false;
                    }

                }
            }
            

            // Debug.Log("Selected: " + _selected.name);

        }
    }
}
