using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    [SerializeField] public List<float> playerY;
    [SerializeField] private float walkSpeed = 5f;
    private float xAxis;
    private int currentY;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    public static int foodCount;

    private void Start() {
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerAnimator = playerRb.gameObject.GetComponent<Animator>();
    }

    private void Update() {
        CheckWin();
        GetInputs();
        Move();
        ClampPosition();
        ChangeY();
    }

    private void GetInputs()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
    }

    private void Move()
    {
        playerRb.velocity = new Vector2(walkSpeed * xAxis, playerRb.velocity.y);
        playerAnimator.SetBool("Walking", playerRb.velocity.x != 0);
    }

    private void ClampPosition()
    {
        playerRb.transform.position = new Vector3(Mathf.Clamp(playerRb.transform.position.x, 2f, 9.5f), playerRb.transform.position.y, playerRb.transform.position.z);
    }

    private void ChangeY()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentY = Mathf.Clamp(currentY - 1, 0, 2);
            playerRb.transform.position = new Vector3(playerRb.transform.position.x, playerY[currentY], playerRb.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currentY = Mathf.Clamp(currentY + 1, 0, 2);
            playerRb.transform.position = new Vector3(playerRb.transform.position.x, playerY[currentY], playerRb.transform.position.z);
        }
    }

    private void CheckWin()
    {
        if (foodCount == 10)
        {
            enabled = false;
            FindObjectOfType<EndController>().StartEnding();
        }
    }
}
