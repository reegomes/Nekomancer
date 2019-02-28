using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<Animator> anims = new List<Animator>();
    [SerializeField] private List<Animator> animsOFactivators = new List<Animator>();
    [SerializeField] private List<bool> bools = new List<bool>();
    [SerializeField] private List<GameObject> activators = new List<GameObject>();
    [SerializeField] private GameObject player;
    private GameObject i;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        bools[2] = true;
        bools[3] = true;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < anims.Count; i++)
        {
            anims[i].SetBool("state", bools[i]);
        }

        foreach (var item in activators)
        {
            var dis = Vector2.Distance(player.transform.position, item.transform.position);
            if (dis <= 2)
            {
                //Debug.Log(dis + " item " + item);
                i = item;
            }
            else if (dis > 6)
            {
                i = null;
            }
            if (dis > 50)
            {
                for (int i = 0; i < bools.Count; i++)
                {
                    bools[i] = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Deactivate();
        }
    }

    void Deactivate()
    {
        if (i.gameObject.name == "ONE")
        {
            animsOFactivators[0].SetTrigger("roll");
            //objects changes
            bools[0] = !bools[0];
            bools[2] = !bools[2];
        }
        else if(i.gameObject.name == "TWO")
        {
            animsOFactivators[1].SetTrigger("roll");
            bools[2] = !bools[2];
            bools[0] = !bools[0];
            bools[3] = !bools[3];
        }
        else if (i.gameObject.name == "THREE")
        {
            animsOFactivators[2].SetTrigger("roll");
            bools[0] = !bools[0];
            bools[3] = !bools[3];
        }
    }
}
