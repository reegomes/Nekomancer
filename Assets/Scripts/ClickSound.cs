using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour
{
    [SerializeField]
    AudioClip sound;
    Button button { get { return GetComponent<Button>(); } }
    AudioSource source { get { return GetComponent<AudioSource>(); } }
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        button.onClick.AddListener(() => PlaySound());
    }
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
}