using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;

    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsperTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackpoint;

    public bool allowInvoke = true;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;

    //Animations
    public Animator animator;
    public PlayerMovement playerMovement;
    public bool isADS = false;

    public float shootingRange = 300f;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        playerMovement = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
        fpsCam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        MyInput();

        //Set ammo display
        if (ammunitionDisplay != null)
        {
            ammunitionDisplay.SetText(bulletsLeft / bulletsperTap + " / " + magazineSize / bulletsperTap);
        }

        if (playerMovement.x == 1f || playerMovement.x == -1f || playerMovement.z == 1f || playerMovement.z == -1f)
        {
            animator.SetBool("isWalking", true);
            
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (playerMovement.isSprinting == true)
        {
            animator.SetBool("sprinting", true);
        } else if (playerMovement.isSprinting == false)
        {
            animator.SetBool("sprinting", false);
        }
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && playerMovement.isSprinting == false)
        {
            animator.SetBool("Reloading", true);
            Reload();
            
        }
        //reload automatically when bulletsLeft is 0
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            animator.SetBool("Reloading", true);
            Reload();
            
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            RayShoot();
            Shoot();
        }

        if(Input.GetKey(KeyCode.Mouse1) && !reloading)
        {
            animator.SetBool("ADS", true);
            isADS = true;
        }
        else
        {
            animator.SetBool("ADS", false);
            isADS = false;
        }
    }

    private void Shoot()
    {
        if (!isADS)
        {
            animator.SetBool("Shooting", true);
            animator.Play("Shoot", -1, 0f);

        } else if (isADS)
        {
            animator.SetBool("ADSShooting", true);
            animator.Play("ADSShoot", -1, 0f);
        }
        
        readyToShoot = false;
        

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        //direction
        Vector3 directionWithoutSpread = targetPoint - attackpoint.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0f);

        //Instantiate bullet
        GameObject currentBullet = Instantiate(bullet, attackpoint.position, Quaternion.identity);
        //Rotate Bullet in the correct direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add force to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);

        //Instantiate muzzle flash
        
            GameObject muzzleFlashes = Instantiate(muzzleFlash, attackpoint.position,Quaternion.identity);
            muzzleFlashes.transform.parent = attackpoint.transform;
            muzzleFlashes.transform.forward = directionWithoutSpread.normalized;
            Destroy(muzzleFlashes, 0.2f);
        

        Destroy(currentBullet, 0.5f);
        


        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
            
        }
    }

    void RayShoot()
    {
        Ray ray = fpsCam.ScreenPointToRay(new Vector3(fpsCam.pixelWidth / 2, fpsCam.pixelHeight / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootingRange))
        {
            if (hit.collider.CompareTag("Enemy")) // Check if the ray hits an enemy.
            {
                Unit unit = hit.collider.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.TakeDamage(5);
                    Debug.Log("Ouch");
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * shootingRange, Color.red, 0.1f);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
        animator.SetBool("Shooting", false);
        animator.SetBool("ADSShooting", false);
    }

    private void Reload()
    {
        readyToShoot = false;
        animator.SetBool("Reloading", true);
        reloading = true;
        Invoke("ReloadFinished", reloadTime);

    }

    private void ReloadFinished()
    {
        readyToShoot = true;
        animator.SetBool("Reloading", false);
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
