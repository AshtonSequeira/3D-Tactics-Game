using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int _posX, _posY;

    GridScript _grid;

    PlayerController _player;

    GameManger _gameManger;

    const int _MOVE_STRAIGHT_COST = 10;
    const int _MOVE_DIAGONAL_COST = 14;

    List<SingleGridBlockScript> _openList;
    List<SingleGridBlockScript> _closedList;

    // Start is called before the first frame update
    void Start()
    {
        _grid = GameObject.FindWithTag("GameManager").GetComponent<GridGenerator>()._grid;
        _gameManger = GameObject.FindWithTag("GameManager").GetComponent<GameManger>();
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _posX = _grid._width - 1;
        _posY = _grid._height - 1;
    }

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

        List<SingleGridBlockScript> FindPath(int _startX, int _startY, int _endX, int _endY)
        {
            SingleGridBlockScript _startNode = _grid._gridBlockArray[_startX, _startY];
            SingleGridBlockScript _endNode = _grid._gridBlockArray[_endX, _endY];

            _openList = new List<SingleGridBlockScript> { _startNode };
            _closedList = new List<SingleGridBlockScript>();

            for (int i = 0; i < _grid._width; i++)
            {
                for (int j = 0; j < _grid._height; j++)
                {
                    SingleGridBlockScript _pathNode = _grid._gridBlockArray[i, j];

                    _pathNode._gCost = int.MaxValue;
                    _pathNode.CalculateFCost();
                    _pathNode._cameFromNode = null;

                }
            }

            _startNode._gCost = 0;
            _startNode._hCost = CalculateDistanceCost(_startNode, _endNode);
            _startNode.CalculateFCost();

            while (_openList.Count > 0)
            {
                SingleGridBlockScript _currentNode = GetLowestFCostNode(_openList);

                if (_currentNode == _endNode) //Reached Final Node
                {
                    return CalculatedPath(_endNode);
                }

                _openList.Remove(_currentNode);
                _closedList.Add(_currentNode);

                foreach (SingleGridBlockScript _neighbourNode in GetNeighbourList(_currentNode))
                {
                    if (_closedList.Contains(_neighbourNode))
                    {
                        continue;
                    }

                    if (_neighbourNode._isBlocked)
                    {
                        _closedList.Add(_neighbourNode);
                        continue;
                    }

                    int _tGCost = _currentNode._gCost + CalculateDistanceCost(_currentNode, _neighbourNode);

                    if (_tGCost < _neighbourNode._gCost)
                    {
                        _neighbourNode._cameFromNode = _currentNode;
                        _neighbourNode._gCost = _tGCost;
                        _neighbourNode._hCost = CalculateDistanceCost(_neighbourNode, _endNode);
                        _neighbourNode.CalculateFCost();

                        if (!_openList.Contains(_neighbourNode))
                        {
                            _openList.Add(_neighbourNode);
                        }
                    }
                }

            }

            //Out of nodes on the open list
            return null;
        }

        List<SingleGridBlockScript> GetNeighbourList(SingleGridBlockScript _currentNode)
        {
            List<SingleGridBlockScript> _neighbourList = new List<SingleGridBlockScript>();

            if (_currentNode._x - 1 >= 0)
            {
                //Left
                _neighbourList.Add(_grid._gridBlockArray[_currentNode._x - 1, _currentNode._y]);

                //LeftDown
                if (_currentNode._y - 1 >= 0)
                {
                    _neighbourList.Add(_grid._gridBlockArray[_currentNode._x - 1, _currentNode._y - 1]);

                }

                //LeftUP
                if (_currentNode._y + 1 < _grid._height)
                {
                    _neighbourList.Add(_grid._gridBlockArray[_currentNode._x - 1, _currentNode._y + 1]);

                }
            }

            if (_currentNode._x + 1 < _grid._width)
            {
                //Right
                _neighbourList.Add(_grid._gridBlockArray[_currentNode._x + 1, _currentNode._y]);

                //RightDown
                if (_currentNode._y - 1 >= 0)
                {
                    _neighbourList.Add(_grid._gridBlockArray[_currentNode._x + 1, _currentNode._y - 1]);

                }

                //LeftUP
                if (_currentNode._y + 1 < _grid._height)
                {
                    _neighbourList.Add(_grid._gridBlockArray[_currentNode._x + 1, _currentNode._y + 1]);

                }
            }

            //Down
            if (_currentNode._y - 1 >= 0)
            {
                _neighbourList.Add(_grid._gridBlockArray[_currentNode._x, _currentNode._y - 1]);
            }

            //Up
            if (_currentNode._y + 1 < _grid._height)
            {
                _neighbourList.Add(_grid._gridBlockArray[_currentNode._x, _currentNode._y + 1]);

            }

            return _neighbourList;
        }

        List<SingleGridBlockScript> CalculatedPath(SingleGridBlockScript _endNode)
        {
            List<SingleGridBlockScript> _path = new List<SingleGridBlockScript>();

            _path.Add(_endNode);

            SingleGridBlockScript _currentNode = _endNode;

            while (_currentNode._cameFromNode != null)
            {
                _path.Add(_currentNode._cameFromNode);
                _currentNode = _currentNode._cameFromNode;
            }

            _path.Reverse();

            return _path;
        }

        int CalculateDistanceCost(SingleGridBlockScript _a, SingleGridBlockScript _b)
        {
            int _xDistance = Mathf.Abs(_a._x - _b._x);
            int _yDistance = Mathf.Abs(_a._y - _b._y);
            int _remaining = Mathf.Abs(_xDistance - _yDistance);

            return _MOVE_DIAGONAL_COST * Mathf.Min(_xDistance, _yDistance) + _MOVE_STRAIGHT_COST * _remaining;

        }

        SingleGridBlockScript GetLowestFCostNode(List<SingleGridBlockScript> _pathNodeList)
        {
            SingleGridBlockScript _lowestFCostNode = _pathNodeList[0];

            for (int i = 1; i < _pathNodeList.Count; i++)
            {
                if (_pathNodeList[i]._fCost < _lowestFCostNode._fCost)
                {
                    _lowestFCostNode = _pathNodeList[i];
                }
            }

            return _lowestFCostNode;
        }

    }
}
