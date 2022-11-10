using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectSpawnerWindow : EditorWindow
{
    private GameObject prefabToSpawn;
    private GameObject parentInScene;
    private string newObjectNamePrefix;
    private int spawnCount;
    private int spawnedCount = 0;
    private int maxSpawnDistance;
    private float minScaleFactor;
    private float maxScaleFactor;
    
    // Add menu item named "Object Spawner Window" to the Window menu
    [MenuItem ("Window/Object Spawner Window")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(ObjectSpawnerWindow));
    }
    
    void OnGUI () {
        GUILayout.Label ("What to spawn", EditorStyles.boldLabel);
        prefabToSpawn = EditorGUILayout.ObjectField("Prefab to spawn", prefabToSpawn, typeof(GameObject), false) as GameObject;
        parentInScene = EditorGUILayout.ObjectField("Parent in scene", parentInScene, typeof(GameObject), true) as GameObject;
        
        GUILayout.Label ("Spawn options", EditorStyles.boldLabel);
        newObjectNamePrefix = EditorGUILayout.TextField ("New Object Name Prefix", newObjectNamePrefix);
        spawnCount = EditorGUILayout.IntField("Spawn count", spawnCount);
        maxSpawnDistance = EditorGUILayout.IntField("Maximum spawn distance", maxSpawnDistance);
        minScaleFactor = EditorGUILayout.FloatField("Minimum scale factor", minScaleFactor);
        maxScaleFactor = EditorGUILayout.FloatField("Maximum scale factor", maxScaleFactor);

        if(GUILayout.Button("Spawn " + spawnCount + " objects"))
        {
            spawnedCount += spawnCount;
        }

        GUILayout.TextArea("Spawned count: " + spawnedCount);
        
        if(GUILayout.Button("Reset spawned count"))
        {
            spawnedCount = 0;
        }
    }
}
