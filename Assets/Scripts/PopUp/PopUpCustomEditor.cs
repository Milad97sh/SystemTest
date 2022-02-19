using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopUpSenario))]
[CanEditMultipleObjects]
public class PopUpCustomEditor : Editor
{

    private int identitiesCount;
    private const int rowCount = 8;
    private const int columnCount = 5;

    private static int selectedIndex;
    private static int activeId;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var popUp = (PopUpSenario)target;
        if (popUp == null) return;

        if (Event.current.type == EventType.MouseMove)
            Repaint();

        //foreach(var pnl in popUp.popUp)
        //{
        //    EditorGUILayout.BeginHorizontal();

        //    pnl.popUp = (GameObject)EditorGUI.ObjectField(new Rect(), "Find Dependency", pnl.popUp, typeof(GameObject),false);
        //    pnl.selected = GUILayout.Toggle(pnl.selected, "Select");

        //    EditorGUILayout.EndHorizontal();
        //}
    }

    
    //popUp.applyPrefab = GUILayout.Toggle(popUp.applyPrefab, "Apply Prefabs");
    //    if (popUp.applyPrefab)
    //    {
            //identitiesCount = Level.puzzlePieces.Length;
            #region
            /*EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Clear"))
            {
                Level.Clear();
                Level.numberOfHoles = 0;
            }
            if (GUILayout.Button("Clear Selected"))
            {
                Level.Senario[selectedIndex].fruitNumber = 0;
                AssetDatabase.SaveAssets();
                EditorUtility.SetDirty(target);
                AssetDatabase.Refresh();
            }
            EditorGUILayout.EndHorizontal();*/
            #endregion

        //    Event current = Event.current;
        //    for (int i = 0; i < rowCount; i++)
        //    {
        //        GUILayout.BeginHorizontal();
        //        for (int j = 0; j < columnCount; j++)
        //        {
        //            var id = Level.Senario[(i * columnCount) + j].fruitNumber;
        //            var texture = new Texture2D(70, 70);

        //            if (id > 0)
        //            {
        //                if (Level.Senario[(i * columnCount) + j].icon)
        //                    texture = AssetPreview.GetAssetPreview(Level.Senario[(i * columnCount) + j].icon);
        //            }
        //            var button = GUILayout.Button(texture, GUILayout.Width(70), GUILayout.Height(70));
        //            if (button)
        //            {
        //                if (current.button == 2)
        //                {
        //                    Level.ChangeIcon((i * columnCount) + j);
        //                }

        //                else if (current.button == 1)
        //                {
        //                    GenericMenu menu = new GenericMenu();
        //                    activeId = (i * columnCount) + j;

        //                    menu.AddItem(new GUIContent("Filled"), false, Activate);
        //                    menu.AddItem(new GUIContent("Hole"), false, Deactivate);
        //                    menu.ShowAsContext();
        //                    current.Use();
        //                }
        //                else
        //                {
        //                    Level.Senario[(i * columnCount) + j].fruitNumber = (Level.Senario[(i * columnCount) + j].fruitNumber + 1) % identitiesCount;
        //                    selectedIndex = (i * columnCount) + j;

        //                    if (Level.Senario[(i * columnCount) + j].fruitNumber > 0)
        //                    {
        //                        Level.Senario[(i * columnCount) + j].icon = Level.puzzlePieces[Level.Senario[(i * columnCount) + j].fruitNumber].myType[0].icon;
        //                        Level.Senario[(i * columnCount) + j].prefabSelectedNum = 0;
        //                    }
        //                    else Level.Senario[(i * columnCount) + j].icon = null;
        //                }
        //                //AssetDatabase.SaveAssets();
        //                //EditorUtility.SetDirty(target);
        //                //AssetDatabase.Refresh();
        //            }
        //            void Deactivate()
        //            {
        //                if (Level.Senario[activeId].Filled)
        //                {
        //                    Level.Senario[activeId].Filled = false;
        //                    Level.numberOfHoles++;
        //                }
        //            }
        //            void Activate()
        //            {
        //                if (!Level.Senario[activeId].Filled)
        //                {
        //                    Level.Senario[activeId].Filled = true;
        //                    if (Level.numberOfHoles > 0) Level.numberOfHoles--;
        //                }
        //            }
        //        }
        //        GUILayout.EndHorizontal();
        //    }
        //    if (GUILayout.Button("Apply"))
        //    {
        //        AssetDatabase.SaveAssets();
        //        EditorUtility.SetDirty(target);
        //        AssetDatabase.Refresh();
        //    }
        //}

private void OnValidate()
    {
#if UNITY_EDITOR 
        if (Application.isPlaying) return;
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
    }

}
