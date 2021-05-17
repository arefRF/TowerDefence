using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
[CustomEditor(typeof(HexMapCreator))]
[ExecuteInEditMode]
public class HexMapEditor : Editor
{
    private bool is_enabled_;
    private void OnEnable()
    {
        if(is_enabled_)
            return;
        if(!Application.isEditor)
            Destroy(this);
        is_enabled_ = true;
        SceneView.duringSceneGui += OnScene;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Map"))
            ((HexMapCreator)target).GenerateMap();
        if(GUILayout.Button("Clear"))
            ((HexMapCreator)target).Clear();
    }

    public void OnScene(SceneView scene)
    {
        Event e = Event.current;

        if(e.type == EventType.MouseDown && e.button == 0)
        {
            
            var mouse_pos = e.mousePosition;
            float ppp = EditorGUIUtility.pixelsPerPoint;
            mouse_pos.y = scene.camera.pixelHeight - mouse_pos.y * ppp;
            mouse_pos.x *= ppp;

            var ray = scene.camera.ScreenPointToRay(mouse_pos);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                DestroyImmediate(hit.transform.gameObject);
            }
            
            e.Use();
        }
    }
}
