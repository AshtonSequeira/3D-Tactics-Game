using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] int _x = 5, _y = 5;
    [SerializeField] GameObject _basicBlock;
    // Start is called before the first frame update
    void Start()
    {
        GridScript _grid = new GridScript(_x,_y,_basicBlock);
    }
        
}
