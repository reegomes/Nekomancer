using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessDoor : MonoBehaviour
{
    [SerializeField] Collider2D col;
    [SerializeField] Transform positionToGo;
    [SerializeField] Vector2 size;
    [SerializeField] LayerMask l;
    [SerializeField] Interact interact;
    public Status status;
    // Start is called before the first frame update
    void Start()
    {
        status = FindObjectOfType<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        col = Physics2D.OverlapBox(this.transform.position, size, 0, l);
        if (Input.GetKeyDown(KeyCode.E) && col)
        {
            interact = col.GetComponent<Interact>();
            transform.position = interact.from_to.transform.position;
            status.Save();
        }
    }
}
