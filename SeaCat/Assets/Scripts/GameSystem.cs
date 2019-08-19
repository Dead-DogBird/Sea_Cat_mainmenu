using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem me;
    public LinkedList<Transform> enemy_list = new LinkedList<Transform>();

	private void Awake()
	{
        if (me == null)
            me = this;
        else
            Destroy(gameObject);
	}

	private void FixedUpdate()
	{
	}

}
