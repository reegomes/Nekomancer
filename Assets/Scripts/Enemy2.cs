using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public enum moveType { UseTransform, UsePhysics };
    public moveType moveTypes;
    [SerializeField] Transform[] pathPoints;
    [SerializeField] int currentPath = 0;
    [SerializeField] float reachDistance = 0.1f;
    [SerializeField] float speed = 0.1f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        switch (moveTypes)
        {
            case moveType.UseTransform:
                UseTransform();
                break;
            case moveType.UsePhysics:
                UseRigidBody2D();
                break;
        }
    }
    void UseTransform()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;
        transform.Translate(dir * speed);
        if (dir.magnitude <= reachDistance)
        {
            currentPath++;
            if (currentPath >= pathPoints.Length)
            {
                currentPath = 0;
            }
        }
    }
    void UseRigidBody2D()
    {
        Vector3 dir = pathPoints[currentPath].position - transform.position;
        Vector3 dirNorm = dir.normalized;

        rb.velocity = new Vector3(dirNorm.x * (speed), rb.velocity.y);

        if (dir.magnitude <= reachDistance)
        {
            currentPath++;
            if (currentPath >= pathPoints.Length)
            {
                currentPath = 0;
            }
        }
    }
    void OnDrawGizmos()
    {
        if (pathPoints == null)
        {
            return;
            foreach (Transform pathPoint in pathPoints)
            {
                if (pathPoint)
                {
                    Gizmos.DrawSphere(pathPoint.position, reachDistance);
                }
            }
        }
    }
}
