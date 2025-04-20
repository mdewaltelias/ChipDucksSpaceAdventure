using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{



    public string nextScene;
    void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Player"))
        {

            var players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length == 2)
            {

                Destroy(collision.gameObject);
            }

            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }

    }
}