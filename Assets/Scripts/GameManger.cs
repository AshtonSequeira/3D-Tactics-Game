using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    int _move = 1;

    public bool _movePlayer = true;
    
    public void DecideMove()  //Decides who Makes the Next Move
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
