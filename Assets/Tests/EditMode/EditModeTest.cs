using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

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
        Assert.AreEqual(new Vector3(0, 0,player.speed), player.Move(0f, 1f));
        yield return null;

        // Move NE
        Assert.AreEqual(new Vector3(player.speed, 0,player.speed), player.Move(1f, 1f));
        yield return null;

        // Move E
        Assert.AreEqual(new Vector3(player.speed, 0,0), player.Move(1f, 0f));
        yield return null;

        // Move SE
        Assert.AreEqual(new Vector3(player.speed, 0,-player.speed), player.Move(1f, -1f));
        yield return null;

        // Move S
        Assert.AreEqual(new Vector3(0, 0,-player.speed), player.Move(0f, -1f));
        yield return null;

        // Move SW
        Assert.AreEqual(new Vector3(-player.speed, 0,-player.speed), player.Move(-1f, -1f));
        yield return null;

        // Move W
        Assert.AreEqual(new Vector3(-player.speed, 0,0), player.Move(-1f, 0f));
        yield return null;

        // Move NW
        Assert.AreEqual(new Vector3(-player.speed, 0,player.speed), player.Move(-1f, 1f));
        yield return null;
    }

    [Test]
    public void ChangeMasterVolume()
    {
        
    }
    
    [Test]
    public void PlaySoundWhenBounce()
    {
        
    }
}
