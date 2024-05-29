using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//This Class inherits Pathfinder class and helps solve code redundency
public class EnemyAI : PathFinder
{ 
    // Update is called once per frame
    void Update()
    {
        if (_gameManger._movePlayer == false)
        {
            _gameManger.DecideMove();

            List<SingleGridBlockScript> _neighbours = new List<SingleGridBlockScript>();

            //Check if Neighbours around the Player are available
            foreach (SingleGridBlockScript _neighbourNode in GetNeighbourList(_grid._gridBlockArray[_player._posX, _player._posY]))
            {
                if (!_neighbourNode._isBlocked)
                {
                    _neighbours.Add(_neighbourNode);
                    continue;
                }
            }

            int r = Random.Range(0, _neighbours.Count);

            //Calculate Path Using A* Algrithm
            List<SingleGridBlockScript> _path = FindPath(_posX, _posY, _neighbours[r]._x, _neighbours[r]._y);

            if (_path != null)
            {
                StartCoroutine(MoveUnit(_path, 0, _neighbours[r]));

                for (int i = 0; i < _path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(_path[i]._x, 0.6f, _path[i]._y), new Vector3(_path[i + 1]._x, 0.6f, _path[i + 1]._y), Color.cyan, 20);

                }
            }
        }

        //Moving the Enemy
        IEnumerator MoveUnit(List<SingleGridBlockScript> _path, int i, SingleGridBlockScript _endNode)
        {
            i++;

            yield return new WaitForSeconds(0.5f);

            transform.position = _grid._gridBlockArray[_path[i]._x, _path[i]._y].transform.position + new Vector3(0f, 1.3f, 0f);

            _posX = _path[i]._x;
            _posY = _path[i]._y;

            if (_posX == _endNode._x && _posY == _endNode._y)
            {
                // _gameManger.DecideMove();
                
            }

            if (i < _path.Count - 1)
            {
                StartCoroutine(MoveUnit(_path, i, _endNode));
            }
        }
    }

}
