using UnityEngine;
public class PartCol : MonoBehaviour
{
    PlayerHealth p;
    [SerializeField] Collider2D target;
    void Start()
    {
        p = target.GetComponent<PlayerHealth>();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            p.TakeDamage(1);
        }
    }
}