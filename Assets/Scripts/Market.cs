using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//vitotoso
#region Mainclass
public class Market : MonoBehaviour
{
    #region VARS
    [SerializeField] GameObject table;
    Transform playerpos;
    [SerializeField] Animator anim;
    //[SerializeField] Camera cam;
    PlayerHealth player;
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI text;
    #endregion
    #region start
    void Start()
    {
        playerpos = FindObjectOfType<PlayerHealth>().GetComponent<Transform>();
        table.SetActive(false);
        player = FindObjectOfType<PlayerHealth>().GetComponent<PlayerHealth>();
        anim.GetComponent<Animator>();
    }
    #endregion
    #region uptoDATE
    void Update()
    {
        text.text = Status.Data.cash.ToString();
        if (Vector2.Distance(transform.position,playerpos.transform.position) <= 2)
        {
            table.SetActive(true);
        }
        else { table.SetActive(false); }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && Status.Data.cash >= 100)
            {
                Color def = hit.collider.gameObject.GetComponent<SpriteRenderer>().color;
                StartCoroutine(Press(hit.collider.gameObject, def));
                Debug.Log("object clicked: " + hit.collider.name);
                switch (hit.collider.name)
                {
                    case "life":
                        //GET TE LIFE VALUE AND INCREASE
                        Status.Data.cash -= 100;
                        Status.Data.lifes += 1;
                        anim.SetTrigger("Drop");
                        break;
                    case "mana":
                        if (Status.Data.cash >= 500)
                        {
                            Status.Data.cash -= 500;
                            Status.Data.mana += 1;
                            anim.SetTrigger("Drop");
                        }
                        break;
                    case "attack":
                        if (Status.Data.cash >= 1000)
                        {
                            //player.attack += 1;
                            Status.Data.cash -= 1000;
                            anim.SetTrigger("Drop");
                        }
                        break;
                    case "power":
                        if (Status.Data.cash >= 10000)
                        {
                            //player.power += 1;
                            Status.Data.cash -= 10000;
                            anim.SetTrigger("Drop");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
    #endregion
    #region ienumerator
    IEnumerator Press(GameObject b, Color d)
    {
        Debug.Log("object colored" );
        b.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.5f);
        b.gameObject.GetComponent<SpriteRenderer>().color = d;
    }
    #endregion
}
#endregion