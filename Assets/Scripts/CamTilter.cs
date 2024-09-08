using UnityEngine;

public class CamTilter : MonoBehaviour
{
  public float tiltSpeed = 2.0f;
  public float tiltMin = -45.0f;
  public float tiltMax = 5.0f;

  void Start()
  {

  }

  void Update () {
    float tilt = tiltSpeed * -Input.GetAxis("Mouse Y");
    float currTilt = transform.eulerAngles.x;
    if (currTilt > 180) {
      currTilt -= 360;
    }
    if (tilt < 0.0 && currTilt > tiltMin ||
        tilt > 0.0 && currTilt < tiltMax) {
      // Debug.Log(transform.eulerAngles.ToString() + " + " + tilt.ToString());
      transform.Rotate(tilt, 0, 0);
      // Debug.Log(transform.eulerAngles);
    }
  }
}
