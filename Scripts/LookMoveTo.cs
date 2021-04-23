using UnityEngine;
using System.Collections;
public class LookMoveTo : MonoBehaviour
{
    private Transform camera;

    void Start()
    {
        camera = Camera.main.transform;
    }

    public GameObject ground;
    void Update()
    {
        Ray ray;
        RaycastHit[] hits;
        GameObject hitObject;
        Debug.DrawRay(camera.position, camera.rotation *
        Vector3.forward * 100.0f);
        ray = new Ray(camera.position, camera.rotation *
        Vector3.forward);
        hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            hitObject = hit.collider.gameObject;
            if (hitObject == ground)
            {
                Debug.Log("Hit (x,y,z): " + hit.point.ToString("F2"));
                transform.position = hit.point;
            }
        }
    }

}