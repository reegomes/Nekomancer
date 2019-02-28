using System.Collections.Generic;
using UnityEngine;
public class ZackSnyder : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private GameObject player;
    [SerializeField] private List<Transform> points = new List<Transform>();
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        foreach (var item in points)
        {
            var dis = Vector2.Distance(player.transform.position, item.transform.position);
            if (dis < distance)
            {
                transform.position = item.transform.position;
                //Debug.Log(dis);
            }
        }
    }
}