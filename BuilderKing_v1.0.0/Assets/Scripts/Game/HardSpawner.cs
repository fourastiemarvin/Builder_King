using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSpawner : MonoBehaviour
{
    public GameObject[] rockArray;
    GameObject rock;
    GameObject clone;
    public Vector3[] positions = new[] {new Vector3 (-4.37f,17.67f,-4.63f)};
    public static Vector3 spawnPosition = new Vector3 (-4.37f,17.67f,-4.63f);
    public static int i;

    // Start is called before the first frame update
    void Start()
    {
      i = Random.Range(0,3);
      //StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
      i = Random.Range(0,3);
      if (ComputeTowerHeight.spawnHard) {
        ComputeTowerHeight.spawnHard = false;
        StartCoroutine(waitSpawner());
      }

      if (ComputeTowerHeight.removeHard) {
        ComputeTowerHeight.removeHard = false;
        Destroy(clone,0);
      }
    }

    IEnumerator waitSpawner(){
      rock = rockArray[i];
	    transform.rotation = Quaternion.Euler (0,0,0);
		  clone = (GameObject) Instantiate(rock, spawnPosition, transform.rotation);
      clone.name = "HardRockMovable(Clone)";
      return null;
    }
}
