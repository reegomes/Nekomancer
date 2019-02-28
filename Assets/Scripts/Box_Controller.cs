using System.Collections;
using UnityEngine;
//vitotoso
public class Box_Controller : MonoBehaviour
{
    #region vars
    [SerializeField] private Animator anim;
    [SerializeField] Drop dropmanager;
    #endregion
    #region start
    private void Start() {
        anim.GetComponent<Animator>();
        dropmanager = FindObjectOfType<Drop>().GetComponent<Drop>();
    }
    #endregion
    #region methods
    void IsAtacked() { anim.SetTrigger("Beat"); }
    void DestroyBox()
    {
        dropmanager.DropUp(this.gameObject);
        Destroy(this.gameObject);
    }
    #endregion
}