using UnityEngine;
public class Atlas : MonoBehaviour
{
    [SerializeField] GameObject a, b, c;
    [SerializeField] float value;
    void Update()
    {
        a.transform.Translate(value * Time.deltaTime, 0, 0);
        b.transform.Translate(value * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            value = -0.3f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            value = 0.3f;
        }
        else
        {
            value = 0;
        }
    }
}