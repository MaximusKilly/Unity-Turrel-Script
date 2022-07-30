using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    private AudioSource TurrelAudio;
    [SerializeField] AudioClip ShootSound; 
    [SerializeField] Transform BulletSpawn; // Spawn Position for Bullet
    [SerializeField] GameObject Bullet; // Bullet Prefab
    [SerializeField] float Force = 1; // Speed of the Bullet
    [SerializeField] float periodicityTime; // pereodicity of shooting
    GameObject Bult;
    // Start is called before the first frame update
    void Start()
    {
        TurrelAudio = GetComponent<AudioSource>();
        InvokeRepeating("Shooting", 0, periodicityTime);
    }

    void Shooting()
    {
        TurrelAudio.PlayOneShot(ShootSound);
        Bult = Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        Destroy(Bult, 3f); // Second parametr = LifeTime of Bullet
    }
    private void FixedUpdate()
    {
        Bult.transform.Translate(Vector3.forward * Force / 10); // I divide by 10 for convenience
    }
}
