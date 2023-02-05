using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
public class PlayerController : MonoBehaviour
{
    public BulletController bullet;
    public BulletController melee;
    public CrosshairController crosshair;

    public float MeleeCooldown = 0.2f;
    public float RangedCooldown = 2f;

    public bool CanMelee = true;
    public bool CanRanged = true;
    
    [Min(1)]
    public int health;
    [Min(0)]
    public float movementFactor;

    bool isDead;

    void Start() {
        Instantiate(crosshair, this.transform);
    }

    // Update is called once per frame
    void Update()
    {

        if (CanMelee == false)
        {
            MeleeCooldown -= Time.deltaTime;
            if (MeleeCooldown <= 0)
            {
                CanMelee = true;
            }
        }
        if (CanRanged == false)
        {
            RangedCooldown -= Time.deltaTime;
            if (RangedCooldown <= 0)
            {
                CanRanged = true;
            }
        }

        
        RangedCooldown -= Time.deltaTime;

        if(!isDead) {
            handleHealth();
            handleMovement();
            handleActions();
        }
        
    }

    void OnCollisionEnter(Collision collision) {
        switch(collision.collider.tag) {
            case "Enemy":
                EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
                this.health -= enemy.damage;
                enemy.kill();
                break;
        }
    }

    void handleHealth() {
        if (health <= 0) {
            kill();
        }
    }

    void handleMovement() {
        Vector3 newPosition = new Vector3(Input.GetAxis("Horizontal") * movementFactor, 0f, Input.GetAxis("Vertical") * movementFactor);
        newPosition *= Time.deltaTime;
        this.transform.position += newPosition;
    }

    void handleActions() {
        if (Input.GetMouseButtonDown(0) && CanMelee == true) {
            Instantiate(melee, this.transform.position, Quaternion.identity);
            CanMelee = false;
            MeleeCooldown = 0.2f;
        }
        else if (Input.GetMouseButtonDown(1) && CanRanged == true) {
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            CanRanged = false;
            RangedCooldown = 2f;
        }
    }

    void kill() {
        isDead = true;
        Debug.Log("Final Score: " + GameController.gameController.getScore());
    }

    public override string ToString() {
        return string.Format("Health: {0}", health);
    }
}
