using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class PlayModeTest
{
    [Test]
    public void BallFall()
    {
        
    }
    
    [UnityTest]
    public IEnumerator BallBounceThreeTimes()
    {
        SceneManager.LoadScene("level_2");
        yield return null;

        BounceCounter sphere = GameObject.FindObjectOfType<BounceCounter>();
        yield return new WaitForSeconds(2.5f);

        Assert.AreEqual(3, sphere.getBounceCounter());
        yield return null;
    }

    [UnityTest]
    public IEnumerator FromSceneEndToMenu()
    {
        // Arrange
        SceneManager.LoadScene("end_game");
        yield return null;
        Assert.AreEqual("end_game",SceneManager.GetActiveScene().name);

        // Acte
        var gameObject = new GameObject();
        var script = gameObject.AddComponent<EndMenu>();
        script.Menu();
        
        yield return null;
        // Assert
        Assert.AreEqual("menu", SceneManager.GetActiveScene().name);
    }
    
    [UnityTest]
    public IEnumerator ButtonPlayToLevel1()
    {
        // Arrange
        SceneManager.LoadScene("menu");
        yield return null;
        Assert.AreEqual("menu",SceneManager.GetActiveScene().name);

        // Acte
        var gameObject = new GameObject();
        var script = gameObject.AddComponent<MenuScript>();
        script.Play();
        
        yield return null;
        // Assert
        Assert.AreEqual("level_1", SceneManager.GetActiveScene().name);
    }
    
    [UnityTest]
    public IEnumerator Level1SwitchAfter3Second()
    {
        // Arrange
        SceneManager.LoadScene("level_1");
        yield return null;
        Assert.AreEqual("level_1",SceneManager.GetActiveScene().name);

        // Acte
        yield return new WaitForSeconds(4f);
        
        // Assert
        Assert.AreEqual("level_2", SceneManager.GetActiveScene().name);
    }
}