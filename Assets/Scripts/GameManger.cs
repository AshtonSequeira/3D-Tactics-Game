using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField]PlayerController _player;
    [SerializeField] EnemyAI _enemy;

    [SerializeField] GridGenerator _grid;

    [SerializeField]int _move = 0;

    public bool _movePlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        //DecideMove();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);


        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyAI>();
        _grid = GetComponent<GridGenerator>();
    }

    public void DecideMove()
    {
        if(_move%2 == 0)
        {
            _movePlayer = true;
            _move++;
        }
        else
        {
            _movePlayer = false;
            _move++;
        }
    }
}
