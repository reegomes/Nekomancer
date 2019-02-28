using System.Collections;
using UnityEngine;
public class Chest : MonoBehaviour
{
    private bool isOpen;
    private Animator anim;
    void Start()
    {
        StartCoroutine("StateOf");
        isOpen = false;
        anim = GetComponent<Animator>();
    }
    private IEnumerator StateOf()
    {
        if (isOpen)
        {
            anim.SetBool("isOpen", true);
            Debug.Log("isOpen");
        }
        else
        {
            //anim.SetBool("isOpen", false);
        }
        yield return new WaitForSeconds(0.005f);
        StartCoroutine("StateOf");
    }
}