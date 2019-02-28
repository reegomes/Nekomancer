//vitotoso
#region bibliotecas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
#region MainClass
public class Dealer : MonoBehaviour
{
    #region vars
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject target;
    #endregion
    #region starTUP
    void Start()
    {
        sprite.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    #endregion
    #region UPEDAITE
    void Update()
    {
        Vector2 relative = transform.InverseTransformPoint(target.transform.position);
        float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        float dis = Vector2.Distance(transform.position, target.transform.position);

        if (angle > 90)
        {
            //Right
            sprite.flipX = true;

        }
        if (angle < -90)
        {
            //left
            sprite.flipX = false;
        }

    }
    #endregion
}
#endregion