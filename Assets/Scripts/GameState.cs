using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState {

    private static bool pause = false;
    private static bool foundAllCollectibles = false;
    private static int numCollectibles = CountCollectibles();
    private static int foundCollectibles = 0;
    private static bool lostGame = false;

    public static void PauseGame()
    {
        pause = true;
    }

    public static void UnpauseGame()
    {
        pause = false;
    }

    public static void FoundCollectible()
    {
        foundCollectibles = foundCollectibles + 1;
        if (foundCollectibles == numCollectibles)
        {
            foundAllCollectibles = true;
        }
    }

    public static bool GameWon()
    {
        return foundAllCollectibles;
    }

    public static int CollectiblesLeft()
    {
        return numCollectibles - foundCollectibles;
    }

    public static int NumCollectibles()
    {
        return numCollectibles;
    }

    public static int CollectiblesFound()
    {
        return foundCollectibles;
    }

    public static bool GamePaused()
    {
        return pause;
    }

    public static bool GameLost()
    {
        return lostGame;
    }

    public static void LoseGame()
    {
        lostGame = true;
    }

    private static int CountCollectibles()
    {
        return GameObject.Find("Collectibles").gameObject.GetComponent<Transform>().childCount;
    }
	
    public static void ResetGameState()
    {
        pause = false;
        foundAllCollectibles = false;
        numCollectibles = CountCollectibles();
        foundCollectibles = 0;
        lostGame = false;
    }
}
