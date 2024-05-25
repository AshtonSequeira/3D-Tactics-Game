using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GridScript
{
    int _width, _height;
    int[,] _gridArray;
    //[SerializeField] GameObject _gridParent;

 public GridScript(int _width, int _height, GameObject _blockPrefab)
    {
        this._width = _width;
        this._height = _height;

        _gridArray = new int[_width, _height];

        Debug.Log(_width+ " "+ _height);

        for (int _i = 0; _i < _gridArray.GetLength(0); _i++)
        {
            for (int _j = 0; _j < _gridArray.GetLength(1); _j++)
            {
                Debug.Log(_i +" "+ _j);

                Vector3 _currentPos = new Vector3(_i, 0f,_j);

                GameObject _basicBlock = GameObject.Instantiate(_blockPrefab,_currentPos,Quaternion.identity);
                SingleGridBlockScript _singleGridBlock = _basicBlock.GetComponent<SingleGridBlockScript>();
                _singleGridBlock._x = _i;
                _singleGridBlock._y = _j;
            }
        }
    }

}
