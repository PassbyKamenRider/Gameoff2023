using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    private float timer;

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= 3.0f)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
