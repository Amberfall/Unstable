using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlSwapMeter : MonoBehaviour
{
    public Slider Slider;
    public PlayerAttributes PlayerAttributes;

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
                Slider.value = (player.TimeUntilSwap / PlayerAttributes.ControlDuration);
            }
        }
    }
}
