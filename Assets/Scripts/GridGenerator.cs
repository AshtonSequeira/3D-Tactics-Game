using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int _x = 5, _y = 5;
    [SerializeField] GameObject _basicBlock;
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _gridHolder;
    [HideInInspector] public bool _isGridGenerated = false;

    public GridScript _grid;

    // Start is called before the first frame update
    void Start()
    {
        //Constructor Generates a Custom Size Grid
        _grid = new GridScript(_x, _y, _basicBlock, _gridHolder.transform);

        //Place Player on the Grid
        GameObject.Instantiate(_playerPrefab, _grid._gridBlockArray[0, 0].transform.position + new Vector3(0f, 1.3f, 0f), Quaternion.identity);

        //Place Enemy on the Grid
        GameObject.Instantiate(_enemyPrefab, _grid._gridBlockArray[_grid._width - 1, _grid._height - 1].transform.position + new Vector3(0f, 1.3f, 0f), Quaternion.identity);

    }

    private void Update()
    {
        _isGridGenerated = _grid._isGridGenerated; //Check if grid is generated
    }
}
