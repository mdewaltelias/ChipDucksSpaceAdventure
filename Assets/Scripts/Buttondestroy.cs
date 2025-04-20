using UnityEngine;

public class Buttondestroy : MonoBehaviour
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
            Destroy(target);
            activated = true;
            GetComponent<AudioSource>().PlayOneShot(click);

        }
    }

}