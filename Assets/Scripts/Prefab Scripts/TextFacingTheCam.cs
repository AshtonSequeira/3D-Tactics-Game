using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFacingTheCam : MonoBehaviour
{
    Transform _mainCam;

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(_mainCam);
    }
}
