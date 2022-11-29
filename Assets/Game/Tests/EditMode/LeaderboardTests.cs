using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LeaderboardTests
{
    [Test]
    public void ScoresSort()
    {
        // Create a leaderboard
        ScoreManager.SaveScore("Riri", 120);
        ScoreManager.SaveScore("Fifi", 530);
        ScoreManager.SaveScore("Loulou", 2000);
        
        // Sort the leaderboard
        var sortedLeaderboard = MenuScript.SortLeaderboard(ScoreManager.leaderboard);
        
        // Test if the first score is the best one
        Assert.AreEqual(2000, sortedLeaderboard.First().Value);
    }
}
