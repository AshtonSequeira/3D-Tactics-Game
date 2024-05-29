using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AI Interface. Not Used.
public interface IAI
{
    //static int _MOVE_STRAIGHT_COST = 10;

    //static int _MOVE_DIAGONAL_COST = 14;

    List<SingleGridBlockScript> FindPath(int _startX, int _startY, int _endX, int _endY);

    List<SingleGridBlockScript> GetNeighbourList(SingleGridBlockScript _currentNode);

    List<SingleGridBlockScript> CalculatedPath(SingleGridBlockScript _endNode);

    int CalculateDistanceCost(SingleGridBlockScript _a, SingleGridBlockScript _b);

    SingleGridBlockScript GetLowestFCostNode(List<SingleGridBlockScript> _pathNodeList);
}
