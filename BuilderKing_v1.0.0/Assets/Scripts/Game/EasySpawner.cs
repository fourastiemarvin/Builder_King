using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasySpawner : MonoBehaviour
{
    public GameObject[] rockArray;
    GameObject rock;
    GameObject clone;
    public Vector3[] positions = new[] {new Vector3 (-9.64f,18.84f,23.01f)};
    public static Vector3 spawnPosition = new Vector3 (-9.64f,18.84f,23.01f);
    public static int i;

    // Start is called before the first frame update
    void Start()
    {
      i = Random.Range(0,3);
      StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
      i = Random.Range(0,3);
      if (ComputeTowerHeight.spawnEasy) {
        ComputeTowerHeight.spawnEasy = false;
        StartCoroutine(waitSpawner());
      }

      if (ComputeTowerHeight.removeEasy) {
        ComputeTowerHeight.removeEasy = false;
        Destroy(clone,0);
      }
    }

    IEnumerator waitSpawner(){
      rock = rockArray[i];
      Debug.Log("Rock: "+rock);
	    transform.rotation = Quaternion.Euler (0,0,0);
		  clone = (GameObject) Instantiate(rock, spawnPosition, transform.rotation);
      clone.name = "EasyRockMovable(Clone)";
      return null;
    }
}
