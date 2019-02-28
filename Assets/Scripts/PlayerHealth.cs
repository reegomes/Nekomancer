using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    bool recallFlag;
    public static int mana, attack, power, cash;
    public static int life;
    [SerializeField] Image a;
    [SerializeField] Animator b;
    public static float barValue;
    void Start()
    {
        recallFlag = true;
        sr = GetComponentInChildren<SpriteRenderer>();
        life = 10;
        //life = PlayerPrefs.GetInt("lifes", Status.Data.lifes);
        a.fillAmount -= barValue;
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("damagg");
        if (recallFlag == true)
        {
            recallFlag = false;
            sr.color = Color.red;
            life -= damage;
            a.fillAmount -= 0.1f;
            barValue -= 0.1f;
            PlayerPrefs.SetInt("lifes", Status.Data.lifes);
            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
            Invoke("ResetSprite", 0.3f);
            StartCoroutine(Recall());
            if (a.fillAmount < 0.4f)
            {
                b.SetBool("isDying", true);
            }
            else
            {
                b.SetBool("isDying", false);
            }
        }
    }

    void ResetSprite()
    {
        sr.color = Color.white;
    }
    IEnumerator Recall()
    {
        yield return new WaitForSecondsRealtime(1f);
        recallFlag = true;
    }
    private void Update()
    {
        //double barValue = life / (double)10;
        //Debug.Log(Status.Data.lifes);
        //Debug.Log("life" + life + "barvalue " + barValue);
    }
}