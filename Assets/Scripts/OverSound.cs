using UnityEngine;
using UnityEngine.EventSystems;
public class OverSound : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    AudioClip sound;
    AudioSource source { get { return GetComponent<AudioSource>(); } }
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
    }
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
		PlaySound();
    }
}