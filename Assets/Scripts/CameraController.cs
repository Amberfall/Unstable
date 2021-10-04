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

    private void LateUpdate()
    {
        foreach (Player player in players) 
        {
            if (player.enabled)
            {
                follow(player.transform.position);
            }
        }
    }

    private void follow(Vector3 point) 
    {
        if (point.y < 0) 
        {
            Vector3 pos = transform.position;
            pos.y = 0;
            transform.position = pos;
        }
        else if (point.y > 192.67f)
        {
            Vector3 pos = transform.position;
            pos.y = 192.67f;
            transform.position = pos;
        }
        else 
        {
            Vector3 pos = transform.position;
            pos.y = point.y;
            transform.position = pos;
        }
    }
}
