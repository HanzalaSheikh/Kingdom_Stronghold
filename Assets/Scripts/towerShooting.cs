using System.Collections.Generic;
using UnityEngine;

public class towerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float shootingInterval = 1f; // Time between shots
    public float detectionRange = 2f; // Range within which the tower will shoot

    //public float ClipLength = 1f;  //audio adding
    //public GameObject AudioClip;    //audio adding

    private float timer;
    private List<GameObject> enemiesInRange = new List<GameObject>();

    ////audio adding
    //private void Start()
    //{
    //    AudioClip.SetActive(false);
    //}

    void Update()
    {
        // Remove null enemies from the list (e.g., those that have been destroyed)
        enemiesInRange.RemoveAll(enemy => enemy == null);

        if (enemiesInRange.Count > 0)
        {
            timer += Time.deltaTime;
            if (timer > shootingInterval)
            {
                timer = 0;
                ShootAtClosestEnemy();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Add the enemy to the list when it enters the range
            if (!enemiesInRange.Contains(other.gameObject))
            {
                enemiesInRange.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Remove the enemy from the list when it leaves the range
            enemiesInRange.Remove(other.gameObject);
        }
    }

    void ShootAtClosestEnemy()
    {
        if (enemiesInRange.Count > 0)
        {
            // Find the closest enemy
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject enemy in enemiesInRange)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            // Shoot at the closest enemy
            if (closestEnemy != null)
            {
                Vector3 direction = (closestEnemy.transform.position - bulletPos.position).normalized;
                Instantiate(bullet, bulletPos.position, Quaternion.LookRotation(direction));
                
                
                ////audio clip adding - start
                //{
                //    AudioClip.SetActive(true);
                //    yield return new WaitForSeconds(ClipLength);
                //    AudioClip.SetActive(false);
                //}
                ////audio clip adding - end
            }
        }
    }
}
