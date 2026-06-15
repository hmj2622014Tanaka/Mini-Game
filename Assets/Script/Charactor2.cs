using UnityEngine;
using UnityEngine.InputSystem; // 入力を検知するために必要
using UnityEngine.SceneManagement; // LoadSceneを使うために必要

public class Charactor2 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 500.0f;
    float walkForce = 5.0f;
    [SerializeField] Sprite[] walkSprites;
    [SerializeField] Sprite jumpSprites;
    [SerializeField] float playerSpeed;
    float time = 0;
    int idx = 0;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rigid2D.linearVelocity = new Vector2(walkForce, rigid2D.linearVelocityY);
            spriteRenderer.flipX = false;
        }
        else if (Keyboard.current.leftArrowKey.isPressed)
        {
            rigid2D.linearVelocity = new Vector2(-walkForce, rigid2D.linearVelocityY);
            spriteRenderer.flipX = true;
        }
        else
        {
            rigid2D.linearVelocity = new Vector2(0, rigid2D.linearVelocityY);
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame && rigid2D.linearVelocityY == 0)
        {
            rigid2D.AddForce(transform.up * jumpForce);
        }

        if (rigid2D.linearVelocityY != 0)
        {
            spriteRenderer.sprite = jumpSprites;
        }
        else
        {
            if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                time += Time.deltaTime;
                if (time > 0.1f)
                {
                    time = 0;
                    spriteRenderer.sprite = walkSprites[idx];
                    idx = 1 - idx;
                }
            }
            else
            {
                spriteRenderer.sprite = walkSprites[0];
                time = 0;
            }
        }

        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("GameScene2");
        }
    }

}
