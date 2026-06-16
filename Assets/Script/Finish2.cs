using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ÉSÅ[Éã");
        SceneManager.LoadScene("GameScene");
    }
}