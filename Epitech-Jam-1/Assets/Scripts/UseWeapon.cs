using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class UseWeapon : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    public GameObject BulletHolePrefab;
    public float fireRate = 0.5f;
    private float NextFire = 5f;
    public AudioClip SoundShot;
    public static bool isTaken = false;
    [SerializeField] private Animator myAnimationController;
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;
    bool hasPlayer = false;
    bool beingCarried = false;
    private bool touched = false;
    private System.Diagnostics.Stopwatch sw = new Stopwatch();

    public static bool katanaIsTaken = false;
    public static bool AK47IsTaken = false;
    public static bool SkorpionIsTaken = false;
    public static bool LaserGunIsTaken = false;

    void Start()
    {
        sw.Start();
    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);
        if (dist < 1.9f)
        {
            hasPlayer = true;
        }
        else {
            hasPlayer = false;
        }
        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
            transform.position = player.position + new Vector3(0.2f, 0.35f, 0f);
            transform.rotation = player.rotation;

            if (gameObject.tag == "AK47")
            {
                AK47IsTaken = true;
                SkorpionIsTaken = false;
                katanaIsTaken = false;
                LaserGunIsTaken = false;

                // transform.position = transform.position + new Vector3(0, 1, 1);
            }
            else if (gameObject.tag == "Skorpion")
            {
                // transform.Rotate(0, 170, 0);
                AK47IsTaken = false;
                SkorpionIsTaken = true;
                katanaIsTaken = false;
                LaserGunIsTaken = false;
            }
            else if (gameObject.tag == "Katana")
            {
                AK47IsTaken = false;
                SkorpionIsTaken = false;
                katanaIsTaken = true;
                LaserGunIsTaken = false;
                transform.Rotate(0, 10, -180);
                transform.position = transform.position + new Vector3(1, -2, 0);
            }
            if (gameObject.tag == "LaserGun")
            {
                AK47IsTaken = false;
                SkorpionIsTaken = false;
                katanaIsTaken = false;
                LaserGunIsTaken = true;
            }
            isTaken = true;
        }
        if (beingCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                
                AK47IsTaken = false;
                SkorpionIsTaken = false;
                katanaIsTaken = false;
            }
        }  

        if (gameObject.tag == "AK47")
        {
            if (Input.GetButton("Fire1") && sw.ElapsedMilliseconds > 100 && AK47IsTaken == true)
            {
                sw.Restart();
                GetComponent<AudioSource>().PlayOneShot(SoundShot);
                Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
                ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
                if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
                {
                    if (hit.transform.gameObject.tag == "Ennemi")
                    {
                        hit.rigidbody.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * 100, hit.normal);
                        HealthManager health = hit.collider.GetComponent<HealthManager>();
                        if (health)
                            health.TakeDamage(10);
                    }
                }
            }
        }
        if (gameObject.tag == "LaserGun")
        {
            if (Input.GetButton("Fire1") && Time.time > NextFire && LaserGunIsTaken == true)
            {
                NextFire = 5;
                Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
                ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
                if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
                {
                    if (hit.transform.gameObject.tag == "Ennemi")
                    {
                        hit.rigidbody.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * 100, hit.normal);
                        HealthManager health = hit.collider.GetComponent<HealthManager>();
                        if (health)
                            health.TakeDamage(1);
                    }
                }
            }
        }
        else if (gameObject.tag == "Skorpion")
        {
            if (Input.GetButton("Fire1") && sw.ElapsedMilliseconds > 50 && SkorpionIsTaken == true)
            {
                NextFire = Time.time + 10;
                GetComponent<AudioSource>().PlayOneShot(SoundShot);
                Vector2 ScreenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
                ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
                myAnimationController.SetBool("isPlayed", true);
                if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane))
                {
                    if (hit.transform.gameObject.tag == "Ennemi")
                    {
                        hit.rigidbody.AddForceAtPosition(transform.TransformDirection(Vector3.forward) * 100, hit.normal);
                        HealthManager health = hit.collider.GetComponent<HealthManager>();
                        if (health)
                            health.TakeDamage(3);
                    }
                }
            }
        }
        else if (gameObject.tag == "Katana")
        {
            if (Input.GetButton("Fire1") && Time.time > NextFire && katanaIsTaken == true)
            {
                NextFire = 0;
                myAnimationController.SetBool("isPlayed", true);
            }
        }
    }

    void PlaySoundAnimationKatana()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundShot);
    }

    void ResetAnimationKatana()
    {
        myAnimationController.SetBool("isPlayed", false);
    }

    void PlaySoundAnimationLaserGun()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundShot);
    }

    void ResetAnimationLaserGun()
    {
        myAnimationController.SetBool("shotLaserGun", false);
    }
}
