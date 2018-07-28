using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        AudioSource explosion = GetComponent<AudioSource>();
        explosion.Play();
        Invoke("Die", 7f);
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
