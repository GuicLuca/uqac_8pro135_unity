using System.Collections;
using NUnit.Framework;
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
        yield return new WaitForSeconds(1f);
        
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
}
