using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

	private void FixedUpdate()
	{
        if (target != null)
        {
            transform.position += (Vector3)((Vector2)(target.position - transform.position)) / 10f;

            if (transform.position.x < -1)
            {
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
            }

            if (transform.position.y < -50)
            {
                transform.position = new Vector3(transform.position.x, -50, transform.position.z);
            }
        }
	}

}
