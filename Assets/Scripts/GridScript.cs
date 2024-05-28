using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

//Generates Grids
public class GridScript
{
    public int _width, _height;
    public bool _isGridGenerated = false;

    public SingleGridBlockScript[,] _gridBlockArray;

    //Parameterized Constructor to generate Grid
    public GridScript(int _width, int _height, GameObject _blockPrefab , Transform _gridHolder)
    {
        this._width = _width;
        this._height = _height;

        _gridBlockArray = new SingleGridBlockScript[_width, _height];

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                Vector3 _currentPos = new Vector3(i, 0f, j);

                GameObject _basicBlock = GameObject.Instantiate(_blockPrefab,_currentPos,Quaternion.identity, _gridHolder);
                SingleGridBlockScript _singleGridBlock = _basicBlock.GetComponent<SingleGridBlockScript>();

                _gridBlockArray[i, j] = _singleGridBlock; 

                if ( i%2 == 0) //Check if Even or Odd
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


                _singleGridBlock.SetColour(); //Set Colour accordingly
                _singleGridBlock._x = i;
                _singleGridBlock._y = j;

                _isGridGenerated = true;
                
            }
        }
    }

}
