using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GridScript
{
    public int _width, _height;
    public int[,] _gridArray;
    public bool _isGridGenerated = false;

    public SingleGridBlockScript[,] _gridBlockArray;
    //[SerializeField] GameObject _gridParent;

 public GridScript(int _width, int _height, GameObject _blockPrefab , Transform _gridHolder)
    {
        this._width = _width;
        this._height = _height;

        _gridArray = new int[_width, _height];

        _gridBlockArray = new SingleGridBlockScript[_width, _height];

        //Debug.Log(_width+ " "+ _height);

        for (int i = 0; i < _gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < _gridArray.GetLength(1); j++)
            {
                //Debug.Log(_i +" "+ _j);

                Vector3 _currentPos = new Vector3(i, 0f,j);

                GameObject _basicBlock = GameObject.Instantiate(_blockPrefab,_currentPos,Quaternion.identity, _gridHolder);
                SingleGridBlockScript _singleGridBlock = _basicBlock.GetComponent<SingleGridBlockScript>();

                _gridBlockArray[i, j] = _singleGridBlock; 

                if ( i%2 == 0)
                {
                    if ( j%2 == 0)
                    {
                        _singleGridBlock._colour = 1;
                    }
                }
                else
                {
                    if (j % 2 != 0)
                    {
                        _singleGridBlock._colour = 1;
                    }
                }


                _singleGridBlock.SetColour();
                _singleGridBlock._x = i;
                _singleGridBlock._y = j;

                _isGridGenerated = true;
                
            }
        }
    }

}
