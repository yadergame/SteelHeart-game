using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public int damage;
    public float boom_range;

    private SphereCollider collider;
    public List<EnemyController> enemy_storage = new List<EnemyController>();

    private void Start()
    {
        collider = gameObject.GetComponent<SphereCollider>();
        collider.radius = boom_range;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet") 
        {
            bool inRange = Vector3.Distance(FindObjectOfType<PlayerController>().gameObject.transform.position, gameObject.transform.position) < boom_range;
            if (inRange) FindObjectOfType<PlayerController>().health -= damage;

            foreach (EnemyController enemy in enemy_storage) enemy.health -= damage;

            gameObject.SetActive(false);
        }
    }

    public void DamageSubscribe(EnemyController sender)
    {
        enemy_storage.Add(sender);
    }
    public void CancelDamageSubscription(EnemyController sender)
    {
        if (enemy_storage.Contains(sender))
            enemy_storage.Remove(sender);
    }
}
