using System.Collections;
using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;

    [CustomEditor(typeof(Unit))]
public class fowEditor : Editor
{

    void OnSceneGUI()
    {
        Unit FOW = (Unit)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(FOW.transform.position, Vector3.up,Vector3.forward,360,FOW.viewRad);
        Handles.color = Color.red;
        foreach (Transform visibletarget in FOW.onRange_target)
        {
            Handles.DrawLine(FOW.transform.position, visibletarget.position);
        }


    }
}