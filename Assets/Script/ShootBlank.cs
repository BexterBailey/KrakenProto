using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBlank : MonoBehaviour
{
    //Variables
    public GameObject projectilePrefab;
    public Transform muzzlePoint;
    public GameObject projectileParent;
    public float projectileLifespan = 3f;
    public float projectileSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        //check if player hit our shoot button
        if(Input.GetMouseButtonDown(0))
        {
            //instantiate our prefab projectile
            GameObject spawnedProjectile = Instantiate(projectilePrefab, muzzlePoint.position, muzzlePoint.rotation);
            //set the parent of the projectile to a null object so it is not impaced by our character movement
            spawnedProjectile.transform.SetParent(projectileParent.transform);
            //add force to the projectile
            spawnedProjectile.GetComponent<Rigidbody>().AddForce(muzzlePoint.up * projectileSpeed);
            //destroy the projectile after time has passed
            Destroy(spawnedProjectile, projectileLifespan);
            StartCoroutine(Shake());
        }
    }

    public IEnumerator Shake(){
        float time = 0.0f;
        while (time < 0.7f)
        {
            
            float x = Random.Range(-15f, 15f) * 0.3f;
            float z = Random.Range(-15f, 15f) * 0.3f;
            transform.position = transform.position + new Vector3(x, 0, z);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
