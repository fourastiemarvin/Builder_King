using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeTowerHeight : MonoBehaviour
{
    public GameObject GameOverUI;
    public Transform tower;
    public Transform lastRock;
    public float currentHeight;
    public float lastUpdate;
    // Interval x
    public float minX;
    public float maxX;
    // Interval z
    public float minZ;
    public float maxZ;

    public int count;
    public float countTime;

    public bool spawnEasy;

    // Start is called before the first frame update
    void Start()
    {
      GameOverUI.SetActive(false);
      tower = gameObject.transform;
      // Height of the tower at the start: gravity center of base
      currentHeight = tower.position.y;
      Debug.Log("height: " + currentHeight);
      minX = tower.position.x - (tower.GetComponent<Collider>().bounds.size.x)/2;
      maxX = tower.position.x + (tower.GetComponent<Collider>().bounds.size.x)/2;
      Debug.Log("x: [" + minX + "," + maxX + "]");
      minZ = tower.position.z - (tower.GetComponent<Collider>().bounds.size.z)/2;
      maxZ = tower.position.z + (tower.GetComponent<Collider>().bounds.size.z)/2;
      Debug.Log("z: [" + minZ + "," + maxZ + "]");
      lastUpdate = 0;
    }

    // Update is called once per frame
    void Update()
    {
      if (DragObjectUpdate.rock.position.y == lastUpdate) {
        count += 1;
        countTime += Time.deltaTime;;
      }
      else {
        count = 0;
        countTime = 0f;
      }
      lastUpdate = DragObjectUpdate.rock.position.y;

      if (count > 10) {
        if (!Input.GetMouseButton(0)) {
          // if the rock is put on the base of the tower (x,z)
          if (DragObjectUpdate.rock.position.x >= minX && DragObjectUpdate.rock.position.x <= maxX) {
            if (DragObjectUpdate.rock.position.z >= minZ && DragObjectUpdate.rock.position.z <= maxZ) {
              // if the height is higher
              if (DragObjectUpdate.rock.position.y > currentHeight) {
                // Update the score
                Scoring.scoreValue += 10;
                // Timer off
                Timer.EndTimer();
                Debug.Log("END------>"+Timer.endTime);
                // TODO: adapt the game
                Debug.Log("TOTAL------>"+ (Timer.gameTime - countTime));

                // Update current height
                currentHeight = DragObjectUpdate.rock.position.y;
                Debug.Log("CurrentObject.y: " + DragObjectUpdate.rock.position.y);
                Debug.Log("currrentHeight: " + currentHeight);
              }
              if (DragObjectUpdate.rock.position.y < currentHeight) {
                Debug.Log("Game Over");
                Debug.Log("CurrentObject.y: " + DragObjectUpdate.rock.position.y);
                Debug.Log("currrentHeight: " + currentHeight);
                GameOverUI.SetActive(true);
              }
            }
          }
        }
      }
    }
}
