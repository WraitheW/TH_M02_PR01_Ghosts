using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTarget : MonoBehaviour
{

    public List<GameObject> targets;
    public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public int score;

    Transform camera;
    private float countDown;

    void Start()
    {
        camera = Camera.main.transform;
        score = 0;
        countDown = timeToSelect;
    }

    // Update is called once per frame
    void Update()
    {
        bool isHitting = false;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.gameObject.tag == "ghost")
            {
                target = hit.collider.gameObject;
                isHitting = true;
            }
        }

        if (isHitting)
        {
            if (countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                if (hitEffect.isStopped)
                {
                    hitEffect.Play();
                }
            }
            else
            {
                Instantiate(killEffect, target.transform.position, target.transform.rotation);
                score += 1;
                KillGhost();
                countDown = timeToSelect;
                //SetRandomPosition();
            }
        }
        else
        {
            countDown = timeToSelect;
            hitEffect.Stop();
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float z = Random.Range(-5.0f, 5.0f);
        target.transform.position = new Vector3(x, 0.0f, z);
    }

    void KillGhost()
    {
        target.SetActive(false);
    }
}
