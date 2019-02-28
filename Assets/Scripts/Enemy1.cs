using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy1 : MonoBehaviour
{
    [SerializeField] Transform pl;
    float minDist = 3f, maxDist = 3f, movingSpeed = 0.7f;
    int direction = -1;
    void Start()
    {
        //initialPosition = transform.position;
        direction = -1;
        maxDist += transform.position.x;
        minDist -= transform.position.x;
    }
    void Update()
    {
        float dist = Vector2.Distance(this.transform.position, pl.transform.position);
        if (dist <= 5)
        {
            Debug.Log("Atacar");
            //Explodir :v
        }
        switch (direction)
        {
            case -1:
                if (transform.position.x > minDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    direction = 1;
                }
                break;
            case 1:
                if (transform.position.x < maxDist)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                }
                else
                {
                    direction = -1;
                }
                break;
        }
    }
}