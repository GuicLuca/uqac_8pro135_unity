using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class EditModeTest
{
    [UnityTest]
    public IEnumerator PlayerMovement()
    {
        // Initialization
        GameObject gameObject = new GameObject();
        Player player = gameObject.AddComponent<Player>();
        yield return null;
        
        // Move N
        Assert.AreEqual(new Vector3(0, 0,player.speed), player.CalculateMovementVector(0f, 1f));
        yield return null;

        // Move NE
        Assert.AreEqual(new Vector3(player.speed, 0,player.speed), player.CalculateMovementVector(1f, 1f));
        yield return null;

        // Move E
        Assert.AreEqual(new Vector3(player.speed, 0,0), player.CalculateMovementVector(1f, 0f));
        yield return null;

        // Move SE
        Assert.AreEqual(new Vector3(player.speed, 0,-player.speed), player.CalculateMovementVector(1f, -1f));
        yield return null;

        // Move S
        Assert.AreEqual(new Vector3(0, 0,-player.speed), player.CalculateMovementVector(0f, -1f));
        yield return null;

        // Move SW
        Assert.AreEqual(new Vector3(-player.speed, 0,-player.speed), player.CalculateMovementVector(-1f, -1f));
        yield return null;

        // Move W
        Assert.AreEqual(new Vector3(-player.speed, 0,0), player.CalculateMovementVector(-1f, 0f));
        yield return null;

        // Move NW
        Assert.AreEqual(new Vector3(-player.speed, 0,player.speed), player.CalculateMovementVector(-1f, 1f));
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerJump()
    {
        // Initialization
        GameObject gameObject = new GameObject();
        Player player = gameObject.AddComponent<Player>();
        yield return null;
        
        // Jump
        Assert.AreEqual(Vector3.up * player.jumpForce, player.CalculateJumpVector());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator ProgressBarStartsEmpty()
    {
        GameObject gameObject = new GameObject();
        ProgressBar progressBar = gameObject.AddComponent<ProgressBar>();
        yield return null;
        
        Assert.Greater(0, progressBar.GetCurrentFill());
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator CounterIncrementation()
    {
        // Arrange
        var gameObject = new GameObject();
        var setings = gameObject.AddComponent<Clicker>();
        yield return null;

        var initialCount = setings.count;
        
        // Acte
        setings.OnClick();
        
        // Assert
        Assert.AreEqual(initialCount+1, setings.count);
    }

    [UnityTest]
    public IEnumerator Instantiation()
    {
        ObjectSpawnerWindow objectSpawnerWindow = (ObjectSpawnerWindow)ScriptableObject.CreateInstance(typeof(ObjectSpawnerWindow));
        yield return null;
        int oldSpawnedCount = objectSpawnerWindow.spawnedCount;
        objectSpawnerWindow.InstantiatePrefabs();
        yield return null;
        Assert.AreEqual(objectSpawnerWindow.spawnedCount, oldSpawnedCount + objectSpawnerWindow.spawnCount);
    }
}
