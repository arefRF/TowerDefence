using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
[CustomEditor(typeof(HexMapCreator))]
[ExecuteInEditMode]
public class HexMapEditor : Editor
{
    HexMapCreator editor_target_;
    HexMapCreator target_
    {
        get
        {
            if (editor_target_ == null)
                editor_target_ = target as HexMapCreator;
            return editor_target_;
        }
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        
        GUILayout.Space(30);
        if(GUILayout.Button("Generate Map"))
            target_.GenerateMap();
        if(GUILayout.Button("Clear Map"))
            target_.Clear();
        target_.is_edit_mode_ = GUILayout.Toggle(target_.is_edit_mode_, "Edit", "Button");
        if (target_.is_edit_mode_ && !target_.is_registered_)
        {
            target_.is_registered_ = true;
            ToggleInspectorLock();
        }
        if (!target_.is_edit_mode_ && target_.is_registered_)
        {
            target_.is_registered_ = false;
            ToggleInspectorLock();
        }
        GUILayout.Space(5);
        var style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;
        GUILayout.Label("Tile Types", style);
        GUILayout.BeginVertical("Box");

        string[] s = { "Ground" , "Goal", "Crystal", "Road", "Spawner"};
        target_.selected_ = GUILayout.SelectionGrid(target_.selected_, s, 5);
        //target_.selected_ = GUILayout.Toggle(target_.selected_, "selected", "Button");
        GUILayout.EndVertical();
    }

    static public void ToggleInspectorLock()
    {
        var inspectorType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");

        var isLocked = inspectorType.GetProperty("isLocked", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

        var inspectorWindow = EditorWindow.GetWindow(inspectorType);

        var state = isLocked.GetGetMethod().Invoke(inspectorWindow, new object[] { });

        isLocked.GetSetMethod().Invoke(inspectorWindow, new object[] { !(bool)state });
    }

    public void OnSceneGUI()
    {
        if (!target_.is_edit_mode_)
            return;
        Event e = Event.current;

        if (e.type == EventType.MouseDown)
        {

            var mouse_pos = e.mousePosition;
            float ppp = EditorGUIUtility.pixelsPerPoint;
            mouse_pos.y = SceneView.lastActiveSceneView.camera.pixelHeight - mouse_pos.y * ppp;
            mouse_pos.x *= ppp;

            var ray = SceneView.lastActiveSceneView.camera.ScreenPointToRay(mouse_pos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var tile = hit.transform.gameObject.GetComponent<TileBase>();
                if (tile != null)
                {
                    if (e.button == 0)
                    {
                        target_.ChangeTileType(tile);
                    }
                    else if (e.button == 1)
                    {
                        target_.ChangeTileType(tile, true);
                    }
                }
            }

            e.Use();
        }
    }
}
