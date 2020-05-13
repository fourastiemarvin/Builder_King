using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardSpawner : MonoBehaviour
{
    public GameObject rock;
    GameObject clone;
    public Vector3[] positions = new[] {new Vector3 (-4.37f,15.67f,-4.63f)};
    public static Vector3 spawnPosition = new Vector3 (-4.37f,15.67f,-4.63f);

    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
      if (ComputeTowerHeight.spawnHard) {
        ComputeTowerHeight.spawnHard = false;
        StartCoroutine(waitSpawner());
      }

      if (ComputeTowerHeight.removeHard) {
        ComputeTowerHeight.removeHard = false;
        if (clone.name == "HardRockMovable(Clone)") {
          Destroy(clone,0);
        }
      }
    }

    IEnumerator waitSpawner(){
	     transform.rotation = Quaternion.Euler (0,0,0);
		   clone = (GameObject) Instantiate(rock, spawnPosition, transform.rotation);
       return null;
    }
}
