using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObstacleDesignerWindow : EditorWindow
{
    GridGenerator _gridGenerator;

    Rect _headerSection;
    Rect _bodySection;

    [MenuItem("Window/Obstacle Designer")]

    static void OpenWindow()
    {
        ObstacleDesignerWindow window = (ObstacleDesignerWindow)GetWindow(typeof(ObstacleDesignerWindow));
        window.minSize = new Vector2 (300, 300);
        window.Show();
    }

    private void OnEnable() //Like Start Method
    {
        _gridGenerator = GameObject.Find("GameManager").GetComponent<GridGenerator>();
    }
    

    private void OnGUI() //Like Update Method
    {
        if (_gridGenerator == null)
        {
            _gridGenerator = GameObject.Find("GameManager").GetComponent<GridGenerator>();
        }

        DrawLayouts();
        DrawHeader();
        if(_gridGenerator._isGridGenerated)
        {
            DrawBody();
        }

        //Debug.Log(_gridGenerator._isGridGenerated);
        //Debug.Log(_gridGenerator._x);

    }

    void DrawLayouts()
    {
        _headerSection.x = 0;
        _headerSection.y = 0;
        _headerSection.width = Screen.width;
        _headerSection.height = 50;

        _bodySection.x = 0;
        _bodySection.y = 50;
        _bodySection.width = Screen.width;
        _bodySection.height = Screen.width - 50;
               
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(_headerSection);

        if (_gridGenerator._isGridGenerated)
        {
            GUILayout.Label("Add Obstacles by Selecting the Buttons.");
        }
        else GUILayout.Label("Press Play to use this Tool.");

        GUILayout.EndArea();

    }

    void DrawBody()
    {
        GUILayout.BeginArea(_bodySection);

        for (int _j = _gridGenerator._y - 1; _j >= 0 ; _j--)
        {

            EditorGUILayout.BeginHorizontal();

            for (int _i = 0; _i < _gridGenerator._x ; _i++)
            {
                if (GUILayout.Toggle(_gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked, "(" + _i + "," + _j + ")", GUILayout.MaxWidth(50)))
                {
                    _gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked = true;
                 
                }
                else
                {
                    _gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked = false;
                }


                //if (GUILayout.Button("("+_i+","+_j+")", GUILayout.Height(20), GUILayout.MaxWidth(50)))
                //{
                //    if (_gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked == true)
                //    {
                //        _gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked = false;
                //    }
                //    else
                //    {
                //        _gridGenerator._grid._gridBlockArray[_i, _j]._isBlocked = true;
                //    }

                //}

            }

            EditorGUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }
}
