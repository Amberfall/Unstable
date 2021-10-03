using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private List<Player> players = new List<Player>();

    private void Start()
    {
        var rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject obj in rootObjects) 
        {
            players.AddRange(obj.GetComponentsInChildren<Player>(true));
        }
    }

    private void Update()
    {
        foreach (Player player in players) 
        {
            if (player.enabled)
            {
                
            }
        }
    }
}
