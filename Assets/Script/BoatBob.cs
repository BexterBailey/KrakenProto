using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBob : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0.1f * Mathf.Sin(Time.time), 0);
    }

    public void OnCollisionEnter(Collision collision){
        //StartCoroutine(Shake());
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
