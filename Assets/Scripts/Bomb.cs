using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OrangeCube"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
