using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShot = 0.2f;
    [SerializeField] float maxTimeBetweenShot = 3f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound;
    [Range(0, 1)][SerializeField] float deathSoundVolume = .75f;
    [SerializeField] AudioClip shootSound;
    [Range(0, 1)] [SerializeField] float shootSoundVolume = .5f;
    [SerializeField] int ScoreValue = 150;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);

    }
    private void countDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            fire();
            shotCounter = Random.Range(minTimeBetweenShot, maxTimeBetweenShot);

        }
    }
    private void fire()
    {
        GameObject Laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }


    // Update is called once per frame
    void Update()
    {
        countDownAndShoot();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damagedealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damagedealer)
        {
            return;
        }
        ProcessHit(damagedealer);
    }

    private void ProcessHit(DamageDealer damagedealer)
    {
        health -= damagedealer.GetDamage();
        damagedealer.Hit();
        if (health <= 0)
        {
            enemyDied();
        }
    }

    private void enemyDied()
    {
        FindObjectOfType<GameSession>().AddToScore(ScoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
