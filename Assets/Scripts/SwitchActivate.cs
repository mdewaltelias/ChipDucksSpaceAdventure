using UnityEngine;

public class SwitchActivate : MonoBehaviour

{
    bool activated = false;
    public Sprite alternate;
    public AudioClip click;
    public GameObject target;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated) return;


        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sprite = alternate;
            target.SetActive(true);
            activated = true;
            GetComponent<AudioSource>().PlayOneShot(click);

        }
    }
}