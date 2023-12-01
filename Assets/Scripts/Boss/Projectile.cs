using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private List<float> targetY;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector3 targetposition;
    private Vector3 startPosition;
    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    private float speed = 8f;
    private int itemIdx;
    private bool isTriggered = false;

    private void Start() {
        itemIdx = Random.Range(0, sprites.Count - 1);
        spriteRenderer.sprite = sprites[itemIdx];
        targetposition = new Vector3(Random.Range(-1.0f, 6.0f), targetY[Random.Range(0,2)], 0f);
        startPosition = transform.position;
    }

    private void Update() {
        dist = targetposition.x - startPosition.x;
        nextX = Mathf.MoveTowards(transform.position.x, targetposition.x, speed * Time.deltaTime);
        baseY = Mathf.Lerp(startPosition.y, targetposition.y, (nextX - startPosition.x) / dist);
        height = 2 * (nextX - startPosition.x) * (nextX - targetposition.x) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        if (transform.position == targetposition)
        {
            if (isTriggered && itemIdx <= 4)
            {
                GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().Play("Dog_Eat");
                BossFightController.foodCount += 1;
            }
            Destroy(gameObject);
        }
    }

    private Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            startPosition = transform.position;
            targetposition = new Vector3(-5f, -150f, 0f);
        }
    }
}