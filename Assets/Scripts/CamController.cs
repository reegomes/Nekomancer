using UnityEngine;
public class CamController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 mypos;
    [SerializeField] private Vector3 offset;
    [SerializeField] float delay;
    void FixedUpdate()
    {
        mypos = target.transform.position;
        var pos = new Vector3((mypos.x - transform.position.x) / delay, (mypos.y - transform.position.y) / delay, 0);
        transform.position += (pos + offset);
    }
}