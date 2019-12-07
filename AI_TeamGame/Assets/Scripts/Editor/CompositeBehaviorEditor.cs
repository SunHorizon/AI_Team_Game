using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CompBehaviour2))]
public class CompositeBehaviorEditor : Editor {

    public override void OnInspectorGUI()
    {
        CompBehaviour2 cb = (CompBehaviour2)target;




        //check

        if (cb.behaviours == null || cb.behaviours.Length == 0)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("no behaviours in array", MessageType.Warning);
            EditorGUILayout.EndHorizontal();




        }

        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.EndHorizontal();

            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < cb.behaviours.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                cb.behaviours[i] = (FlockBehaviour2)EditorGUILayout.ObjectField(cb.behaviours[i], typeof(FlockBehaviour2), false, GUILayout.MinWidth(60f));
                cb.weights[i] = EditorGUILayout.FloatField(cb.weights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(cb);
            }

            //Rect r = EditorGUILayout.BeginHorizontal();
            //r.height = EditorGUIUtility.singleLineHeight;
            //r.x = 5f;
            //r.width = EditorGUIUtility.currentViewWidth - 10f;
            //r.y += EditorGUIUtility.singleLineHeight * 0.5f;

        }

        if (GUILayout.Button("Add Behaviour"))
        {
            AddBehaviour(cb);
            EditorUtility.SetDirty(cb);
        }

        //r.y += EditorGUIUtility.singleLineHeight * 1.5f;
        if (cb.behaviours != null && cb.behaviours.Length > 0)
        {
            if (GUILayout.Button("Remove Behaviour"))
            {
                RemoveBehaviour(cb);
                EditorUtility.SetDirty(cb);
            }
        }

    }

    void AddBehaviour(CompBehaviour2 cb)
    {
        int oldCount = (cb.behaviours != null) ? cb.behaviours.Length : 0;
        FlockBehaviour2[] newBehaviours = new FlockBehaviour2[oldCount + 1];
        float[] newWeights = new float[oldCount + 1];
        for (int i = 0; i < oldCount; i++)
        {
            newBehaviours[i] = cb.behaviours[i];
            newWeights[i] = cb.weights[i];

        }
        newWeights[oldCount] = 1f;
        cb.behaviours = newBehaviours;
        cb.weights = newWeights;
    }

    void RemoveBehaviour(CompBehaviour2 cb)
    {
        int oldCount = cb.behaviours.Length;
        if (oldCount == 1)
        {
            cb.behaviours = null;
            cb.weights = null;
            return;
        }
        FlockBehaviour2[] newBehaviours = new FlockBehaviour2[oldCount - 1];
        float[] newWeights = new float[oldCount - 1];
        for (int i = 0; i < oldCount - 1; i++)
        {
            newBehaviours[i] = cb.behaviours[i];
            newWeights[i] = cb.weights[i];

        }
        cb.behaviours = newBehaviours;
        cb.weights = newWeights;
    }
}



