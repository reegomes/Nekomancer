using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustTeleport : MonoBehaviour
{
    public GameObject player;
    public string scene;
    public Status status;
    public bool isonmarket;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        status = FindObjectOfType<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        var disp = Vector2.Distance(player.transform.position, this.transform.position);
        if (disp <= 2 && Input.GetKeyDown(KeyCode.E))
        {
            if (isonmarket)
            {
                //notsave
            }
            else
            {
                status.Save();
            }
            SceneManager.LoadScene(scene);
        }
    }
}
