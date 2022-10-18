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
        /*
        SceneManager.LoadScene("level_2");
        BounceCounter sphere = GameObject.FindObjectOfType<BounceCounter>();
        Assert.AreEqual(3, sphere.getBounceCounter());
        */
        yield return null;
    }
    
    [Test]
    public void PlaySoundWhenBounce()
    {
        
    }

    [UnityTest]
    public IEnumerator PlayerMovement()
    {
        // Initialization
        SceneManager.LoadScene("level_3");
        PlayerController player = GameObject.FindObjectOfType<PlayerController>();
        
        // Move N
        Assert.AreEqual(new Vector3(0, 0,player.speed), player.Move(0f, 1f));
        
        // Move NE
        Assert.AreEqual(new Vector3(player.speed, 0,player.speed), player.Move(1f, 1f));
        
        // Move E
        Assert.AreEqual(new Vector3(player.speed, 0,0), player.Move(1f, 0f));
        
        // Move SE
        Assert.AreEqual(new Vector3(player.speed, 0,-player.speed), player.Move(1f, -1f));
        
        // Move S
        Assert.AreEqual(new Vector3(0, 0,-player.speed), player.Move(0f, -1f));
        
        // Move SW
        Assert.AreEqual(new Vector3(-player.speed, 0,-player.speed), player.Move(-1f, -1f));
        
        // Move W
        Assert.AreEqual(new Vector3(-player.speed, 0,0), player.Move(-1f, 0f));
        
        // Move NW
        Assert.AreEqual(new Vector3(-player.speed, 0,player.speed), player.Move(-1f, 1f));

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