using UnityEngine;

public class UnityClient : MonoBehaviour
{
    private HeartRateRequester _heartRateRequester;

    // private void Start()
    // {
    //     _helloRequester = new HelloRequester();
    //     _helloRequester.Start();
    // }
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("x")) {
        _heartRateRequester = new HeartRateRequester();
        _heartRateRequester.Start();
      }
    }

    public void callHeartRate() {
      _heartRateRequester = new HeartRateRequester();
      _heartRateRequester.Start();
    }

    private void OnDestroy()
    {
        _heartRateRequester.Stop();
    }
}
