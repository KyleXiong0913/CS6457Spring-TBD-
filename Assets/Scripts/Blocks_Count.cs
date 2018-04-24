using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocks_Count : MonoBehaviour
{
    public static int Count;
    Text text;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text = GetComponent<Text>();
        //Now the below step is useless, but will continue to implement in the future.
        //text.text = "Blocks Destroyed: " + GameState.CountDestroyedBlocks();
        text.text = "Blocks Destroyed:" + GameState.blocksDestroyed;
    }
}