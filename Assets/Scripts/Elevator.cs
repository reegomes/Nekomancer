using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] float TimeState;
    private bool isUp;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine("State");
    }

    void Update()
    {
        if (isUp)
        {
            transform.Translate(Vector2.down * 2 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * 2 * Time.deltaTime);
        }
    }

    IEnumerator State()
    {
        yield return new WaitForSeconds(TimeState);
        isUp = !isUp;
        StartCoroutine("State");
    }
}
