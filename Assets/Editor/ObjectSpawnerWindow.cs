#if (UNITY_EDITOR)
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawnerWindow : EditorWindow
{
    public GameObject prefab1ToSpawn;
    public GameObject prefab2ToSpawn;
    public GameObject prefab3ToSpawn;
    public GameObject parentInScene;
    private string newObjectNamePrefix = "spawned_";
    public int spawnCount = 5;
    public int spawnedCount = 0;
    private int maxSpawnDistance = 40;
    private float minScaleFactor = 0.5f;
    private float maxScaleFactor = 10.0f;
    
    // Add menu item named "Object Spawner Window" to the Window menu
    [MenuItem ("Window/Object Spawner Window")]
    public static void  ShowWindow () {
        EditorWindow.GetWindow(typeof(ObjectSpawnerWindow));
    }

    private void OnEnable()
    {
        prefab1ToSpawn = new GameObject();
        prefab2ToSpawn = new GameObject();
        prefab3ToSpawn = new GameObject();
        parentInScene = new GameObject();
    }

    void OnGUI () {
        GUILayout.Label ("What to spawn", EditorStyles.boldLabel);
        prefab1ToSpawn = EditorGUILayout.ObjectField("Prefab 1 to spawn", prefab1ToSpawn, typeof(GameObject), false) as GameObject;
        prefab2ToSpawn = EditorGUILayout.ObjectField("Prefab 2 to spawn", prefab2ToSpawn, typeof(GameObject), false) as GameObject;
        prefab3ToSpawn = EditorGUILayout.ObjectField("Prefab 3 to spawn", prefab3ToSpawn, typeof(GameObject), false) as GameObject;
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
        int r = 0;
        GameObject prefab;
        for (int i = spawnedCount; i < spawnedCount + spawnCount; i++)
        {
            // Select random prefab
            r = Random.Range(1, 4);
            switch (r)
            {
                case 1:
                    prefab = prefab1ToSpawn;
                    break;
                case 2:
                    prefab = prefab2ToSpawn;
                    break;
                case 3:
                    prefab = prefab3ToSpawn;
                    break;
                default:
                    prefab = prefab1ToSpawn;
                    break;
            }
            
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