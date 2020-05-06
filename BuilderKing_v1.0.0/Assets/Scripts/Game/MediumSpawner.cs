using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSpawner : MonoBehaviour
{
    public GameObject rock;
    GameObject clone;
    public Vector3[] positions = new[] {new Vector3 (17.14f,15.84f,13.26f)};
    public static Vector3 spawnPosition = new Vector3 (17.14f,15.84f,13.26f);

    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator waitSpawner(){
	     transform.rotation = Quaternion.Euler (0,0,0);
		   clone = (GameObject) Instantiate(rock, spawnPosition, transform.rotation);
       return null;
    }
}
