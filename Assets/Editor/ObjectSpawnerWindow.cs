#if (UNITY_EDITOR)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnerWindow : EditorWindow
{
    public GameObject prefabToSpawn;
    public GameObject parentInScene;
    private string newObjectNamePrefix = "spawned_";
    public int spawnCount = 1000;
    public int spawnedCount = 0;
    private int maxSpawnDistance = 1000;
    private float minScaleFactor = 5f;
    private float maxScaleFactor = 20f;
    
    // Add menu item named "Object Spawner Window" to the Window menu
    [MenuItem ("Window/Object Spawner Window")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(ObjectSpawnerWindow));
    }

    private void OnEnable()
    {
        prefabToSpawn = new GameObject();
        parentInScene = new GameObject();
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
        EditorGUILayout.MinMaxSlider(ref minScaleFactor, ref maxScaleFactor, 0, 20);

        if(GUILayout.Button("Spawn " + spawnCount + " objects"))
        {
            InstantiatePrefabs();
        }

        EditorGUILayout.LabelField("Spawned count:  " + spawnedCount);
        
        if(GUILayout.Button("Reset spawned count"))
        {
            spawnedCount = 0;
        }
    }

    public void InstantiatePrefabs()
    {
        for (int i = spawnedCount; i < spawnedCount + spawnCount; i++)
        {
            // Get prefab to spawn
            GameObject prefab = prefabToSpawn;
            // Set random position
            Vector3 position = new Vector3(Random.Range(-maxSpawnDistance, maxSpawnDistance), Random.Range(-maxSpawnDistance, maxSpawnDistance), Random.Range(-maxSpawnDistance, maxSpawnDistance));
            // Set random scale
            float scaleFactor = Random.Range(minScaleFactor, maxScaleFactor);
            prefab.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            // Instantiate the prefab with all this parameters
            GameObject instantiatedPrefab = Instantiate(prefab, position, Random.rotation, parentInScene.transform);
            // Rename instantiated prefab
            instantiatedPrefab.name = newObjectNamePrefix + prefab.name + "_" + i;
        }

        spawnedCount += spawnCount;
        Debug.Log("Spawned " + spawnCount + " objects for a total of " + spawnedCount + " spawned objects!");
    }
}
#endif