using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);

            // Store the reference to MainManager before reloading the scene
            MainManager mainManager = MainManager.Instance;

            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            // Reassign the reference to MainManager after the scene is reloaded
            mainManager = FindObjectOfType<MainManager>();
        }
    }
}
