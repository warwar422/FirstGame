using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    public float DumpTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, target.position.y + 0.2f, target.position.z));
            Vector3 delta = new Vector3(target.position.x, target.position.y + 0.2f, target.position.z) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destintion = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destintion, ref velocity, DumpTime);
        }
    }
}
