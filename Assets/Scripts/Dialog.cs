using System.Collections;
using UnityEngine;
using TMPro;
public class Dialog : MonoBehaviour
{
    [Header("Sistema de Diálogos")]
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] string[] sentences;
    int index;
    [SerializeField] float typingSpeed;
    [Header("Outros")]
    [SerializeField] GameObject continueButton;
    [SerializeField] AudioSource source;
    [Header("Identificador")]
    [SerializeField] string stringWithMomochi = "Momochi: ";
    [SerializeField] string stringWithKura = "Kura: ";
    [SerializeField] string stringWithDealer = "Dealer: ";
    [SerializeField] GameObject momochiPica, kuraPica, dealerPica;
    [SerializeField] GameObject Kura;
    bool stopDialog;

    void Start()
    {
        //source = GetComponent<AudioSource>();
        //Só é preciso definir quando será ativado o diálogo e gg
        StartCoroutine(Type());
    }
    void Update()
    {
        Dialogs();
        if (index == sentences.Length - 1)
        {
            Debug.Log("Agora");
            StartCoroutine(End());
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void Next()
    {
        source.Play();
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
    void Dialogs()
    {
        if (textDisplay.text != null)
        {
            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
            if (sentences[index].Contains(stringWithMomochi) && stopDialog != true)
            {
                momochiPica.SetActive(true);
            }
            else
            {
                momochiPica.SetActive(false);
            }
            if (sentences[index].Contains(stringWithKura) && stopDialog != true)
            {
                kuraPica.SetActive(true);
            }
            else
            {
                kuraPica.SetActive(false);
            }

            if (sentences[index].Contains(stringWithDealer) && stopDialog != true)
            {
                dealerPica.SetActive(true);
            }
            else
            {
                dealerPica.SetActive(false);
            }
        }
    }
    IEnumerator End()
    {
        yield return new WaitForSeconds(4f);
        dealerPica.SetActive(false);
        momochiPica.SetActive(false);
        kuraPica.SetActive(false);
        stopDialog = true;
        Kura.gameObject.GetComponent<Kura>().SoltaOSomDeeJay();
    }
}