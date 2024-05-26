using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] GridGenerator _gridGenerator;

    [SerializeField] GameObject _obstacle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int _i = 0; _i < _gridGenerator._grid._width; _i++)
        {
            for (int _j = 0; _j < _gridGenerator._grid._height; _j++)
            {
                if (_gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked)
                {
                    if (!_gridGenerator._grid._gridBlockArray[_i, _j]._isObstaclePlaced)
                    {
                        GameObject _newObstacle = GameObject.Instantiate(_obstacle, _gridGenerator._grid._gridBlockArray[_i, _j].transform.position + new Vector3(0, 1, 0), Quaternion.identity, _gridGenerator._grid._gridBlockArray[_i, _j].transform);

                        _gridGenerator._grid._gridBlockArray[_i, _j]._obstacle = _newObstacle;

                        _gridGenerator._grid._gridBlockArray[_i, _j]._isObstaclePlaced = true;
                    }
                }

                else if (_gridGenerator._grid._gridBlockArray[_i, _j]._isObstaclePlaced)
                {
                    Destroy(_gridGenerator._grid._gridBlockArray[_i, _j]._obstacle);

                    _gridGenerator._grid._gridBlockArray[_i, _j]._obstacle = null;

                    _gridGenerator._grid._gridBlockArray[_i, _j]._isObstaclePlaced = false;

                }

            }
        }
    }
}
