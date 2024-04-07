using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Destroy(other.gameObject);
            Manager.GameOver();
        }
    }
}
