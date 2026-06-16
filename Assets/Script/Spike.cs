using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PlayerDeathRoutine(collision.gameObject));
        }
    }

    private IEnumerator PlayerDeathRoutine(GameObject player)
    {
        Debug.Log("Ç∆Ç∞Ç…ìñÇΩÇ¡ÇΩÅI");

        GetComponent<ParticleSystem>().Play();

        GetComponent<AudioSource>().Play();

        player.SetActive(false);

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("GameScene2");
    }
}