using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject _basicBlock;
    // Start is called before the first frame update
    void Start()
    {
        GridScript _grid = new GridScript(5,4,_basicBlock);
    }
        
}
