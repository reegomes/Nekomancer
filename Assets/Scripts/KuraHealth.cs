using UnityEngine;
public class KuraHealth : MonoBehaviour
{
    [SerializeField] int life;
    SpriteRenderer sr;
    public void TakeDamage(int damage)
    {
        sr.color = Color.red;
        life -= damage;
        if (life <= 0)
        {
            // Fazer algo
        }
        Invoke("ResetSprite", 0.3f);
    }
    void ResetSprite()
    {
        sr.color = Color.white;
    }
}
