using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerProgress", 3);
        int startNode = PlayerPrefs.GetInt("PlayerProgress");
        //transform.position=FindObjectOfType<MapVisualizer>().GetMap().GetNode(startNode)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
