using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int _x = 5, _y = 5;
    [SerializeField] GameObject _basicBlock;

    public GridScript _grid;

    //public SingleGridBlockScript[,] _gridBlockArray1;
    // Start is called before the first frame update
    void Start()
    {
        _grid = new GridScript(_x,_y,_basicBlock);

        //_gridBlockArray1 = new SingleGridBlockScript[_x, _y];

        Debug.Log(_grid._gridBlockArray[0, 1]._x +" , " + _grid._gridBlockArray[0, 1]._y);

        //_grid._gridBlockArray[0, 1]._isBlocked = true;
    }
        
}
