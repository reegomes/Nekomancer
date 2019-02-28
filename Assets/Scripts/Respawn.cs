using UnityEngine;
public class Respawn : MonoBehaviour
{
    private Collider2D objectCol;
    [SerializeField] private Vector2 range;
    [SerializeField] private GameObject point;
    [SerializeField] private LayerMask l;
    void Update()
    {
        objectCol = Physics2D.OverlapBox(transform.position, range, l);
        objectCol.transform.position = point.transform.position;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, range);
    }
}