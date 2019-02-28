using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
//vitotoso
public class Drop : MonoBehaviour
{
    #region vars
    [SerializeField] private List<GameObject> itens = new List<GameObject>();
    [SerializeField] private List<GameObject> droppedItens = new List<GameObject>();
    [SerializeField]private PlayerHealth player;
    [SerializeField] private GameObject def,playerpos;
    short cashValue;
    #endregion
    #region start
    void Start()
    {
        //SCRIPT OF PLAYER TO ACCESS CASH
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerpos = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].gameObject.transform.position = def.transform.position;
        }
    }
    #endregion
    #region Update
    void Update()
    {
        cashValue = (short)Random.Range(5, 10);
        foreach (var item in droppedItens)
        {
            var dis = Vector2.Distance(item.transform.position, playerpos.transform.position);
            if (dis <= 1)
            {
                Debug.Log("ITEM DROPPED Catch");
                itens.Add(item);
                droppedItens.Remove(item);
                Status.Data.cash += cashValue;
                item.transform.position = def.transform.position;
            }
            if (dis > 30)
            {
                Debug.Log("ITEM DROPPED Catch");
                itens.Add(item);
                droppedItens.Remove(item);
                item.transform.position = def.transform.position;
            }
        }

    }
    #endregion
    #region methods
    //will drop a item
    public void DropUp(GameObject positiontodrop)
    {
        itens[0].transform.position = positiontodrop.transform.position;
        droppedItens.Add(itens[0]);
        itens.Remove(itens[0]);
    }
    //metod to return a object
    public void ReturnToMe(GameObject item)
    {
        item.transform.position = def.transform.position;
    }
    #endregion
}
