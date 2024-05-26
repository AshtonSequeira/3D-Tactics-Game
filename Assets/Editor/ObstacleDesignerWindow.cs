using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObstacleDesignerWindow : EditorWindow
{
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

    }

    private void OnGUI() //Like Update Method
    {
        DrawLayouts();
        DrawHeader();
        DrawBody();
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

        GUILayout.Label("Add Obstacles by Selecting the Buttons");

        GUILayout.EndArea();

    }

    void DrawBody()
    {
        GUILayout.BeginArea(_bodySection);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("(0,0)", GUILayout.Height(20), GUILayout.MaxWidth(50)))
        {

        }

        if (GUILayout.Button("(0,1)", GUILayout.Height(20), GUILayout.MaxWidth(50)))
        {

        }

        if (GUILayout.Button("(0,2)", GUILayout.Height(20), GUILayout.MaxWidth(50)))
        {

        }

        if (GUILayout.Button("(0,3)", GUILayout.Height(20), GUILayout.MaxWidth(50)))
        {

        }

        if (GUILayout.Button("(0,4)", GUILayout.Height(20), GUILayout.MaxWidth(50)))
        {

        }



        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
}
