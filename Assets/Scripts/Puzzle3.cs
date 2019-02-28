using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle3 : MonoBehaviour
{
    [SerializeField] private GameObject def,player,doorcloosed,dooropen;
    [SerializeField] private List<GameObject> keys = new List<GameObject>();
    [SerializeField] private List<GameObject> keysColected = new List<GameObject>();
    public string scene;
    // Start is called before the first frame update
    private void Start()
    {
        dooropen.SetActive(false);
        doorcloosed.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        foreach (var item in keys)
        {
            var dis = Vector2.Distance(item.transform.position, player.transform.position);
            if (dis < 1)
            {
                keys.Remove(item);
                keysColected.Add(item);
                item.transform.position = def.transform.position;
            }
        }
        if (keys.Count == null || keysColected.Count == 3)
        {
            dooropen.SetActive(true);
            doorcloosed.SetActive(false);
        }
    }
}
