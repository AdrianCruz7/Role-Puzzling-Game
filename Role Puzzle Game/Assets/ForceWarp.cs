using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceWarp : MonoBehaviour
{
    public int sceneBuildIndex = 1;
    public float timer = 10;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D other) 
    {

    }

    private void Update() {
        if (timer <= 0 )
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
        else
        {
            timer = timer - Time.deltaTime;
            Debug.Log(timer.ToString());
        }
    }
}
