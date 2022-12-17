using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNans : MonoBehaviour
{
    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 2f;
    protected float _CameraDistanceNow = 2f;  // Is affected by collision

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 12f;
    public float ScrollDampening = 8f;
    public float minYRotation = -30f;
    public float maxYRotation = 90f;

    // Collision
    public float minDistance = 0.5f;
	public float smooth = 16.0f;
	Vector3 dollyDir;
	public Vector3 dollyDirAdjusted;


    // Initialization
    void Awake () {
		dollyDir = transform.localPosition.normalized;
	}

    // Start is called before the first frame update
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Rotation of the Camera based on Mouse Coordinates
        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
            _LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

            // Clamp the y Rotation to horizon and not flipping over at the top
            if (_LocalRotation.y < minYRotation)
                _LocalRotation.y = minYRotation;
            else if (_LocalRotation.y > maxYRotation)
                _LocalRotation.y = maxYRotation;
        }
        // Zooming Input from our Mouse Scroll Wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;

            ScrollAmount *= (this._CameraDistance * 0.3f);

            this._CameraDistance += ScrollAmount * -1f;

            this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 3f);
        }
        
        // Collision
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * this._CameraDistance );
        RaycastHit hit;

        if (Physics.Linecast (this._XForm_Parent.position, desiredCameraPos, out hit)) {
            this._CameraDistanceNow = Mathf.Clamp((hit.distance * 0.87f), minDistance, 3.0f);
        }
        else {
            // Reset distance if not collided
            this._CameraDistanceNow = Mathf.Lerp(this._CameraDistance, 2.0f, Time.deltaTime * smooth);
        }

        // Actual Camera Rig Transformations For Rotation and Zoom in/out
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);

        if ( this._XForm_Camera.localPosition.z != this._CameraDistanceNow * -1f )
        {
            this._XForm_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistanceNow * -1f, Time.deltaTime * ScrollDampening));
        }

    }
}
