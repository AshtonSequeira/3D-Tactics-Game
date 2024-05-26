using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Selector : MonoBehaviour
{
    [SerializeField] Material _highlightMaterial;
    [SerializeField] Material _selectMaterial;

    Material _originalMaterial;
    Material _originalMaterial2;
    Transform _highlighted;
    Transform _selected;
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

        }

        //if(Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject())
        //{
        //    if (_selected != null)
        //    {
        //        _selected.GetComponent<Renderer>().material = _originalMaterial2;
        //        _selected = null;
        //    }

        //    if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(_ray, out _raycastHit))
        //    {
        //        _selected = _raycastHit.transform;
        //        if (_selected.CompareTag("Selectable"))
        //        {
        //            _originalMaterial2 = _originalMaterial;
        //            _selected.GetComponent<MeshRenderer>().material = _selectMaterial;
        //        }                
        //        else
        //        {
        //            _selected = null;
        //        }

        //    }

        //   // Debug.Log("Selected: " + _selected.name);

        //}
    }
}
