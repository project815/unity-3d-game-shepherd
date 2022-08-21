using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCompleteEventArgs
{
    public GameObject targetObject;
    public Vector3 position;
    public Quaternion quaternion;
}
public class CameraMove : MonoBehaviour
{
    public static event System.EventHandler<MoveCompleteEventArgs>
    EventHandler_CameraMoveTarget;

    public GameObject camera;
    public Transform targetObject;
    public Transform subTargat;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public static bool IsActive = false;
    public float Zoomin = -5;
    private Bounds boundsData;
    private bool isBounds = true;

    private int PassCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsActive)
        {
            Vector3 targetPosition;
            if (subTargat != null || PassCount == 0)
            {
                targetPosition = subTargat.transform.position;
                smoothTime = 0.1f;
            }
            else
            {
                if (!isBounds)
                    targetPosition = targetObject.TransformPoint(new Vector3(0, 10, Zoomin));
                else
                    targetPosition = new Vector3(boundsData.center.x, boundsData.center.y + boundsData.size.y, boundsData.center.z - boundsData.size.z + Zoomin);

            }

            camera.transform.position = Vector3.SmoothDamp(camera.transform.position, targetPosition, ref velocity, smoothTime);
            camera.transform.LookAt(targetObject);

            if(Vector3.Distance(targetPosition, camera.transform.position) < 0.1f)
            {
                if(subTargat != null)
                {
                    if(targetPosition == subTargat.transform.position)
                    {
                        PassCount++;
                        if (!isBounds)
                            targetPosition = targetObject.TransformPoint(new Vector3(0, 10, Zoomin));
                        else
                            targetPosition = new Vector3(boundsData.center.x, boundsData.center.y + boundsData.size.y, boundsData.center.z - boundsData.size.z + Zoomin);

                    }
                    else
                    {
                        MoveCompleteEventArgs args = new MoveCompleteEventArgs();
                        args.targetObject = targetObject.gameObject;
                        args.position = camera.transform.position;
                        args.quaternion = camera.transform.rotation;
                        EventHandler_CameraMoveTarget(this, args);

                        Clear();
                    }
                }
                else
                {
                    MoveCompleteEventArgs args = new MoveCompleteEventArgs();
                    args.targetObject = targetObject.gameObject;
                    args.position = camera.transform.position;
                    args.quaternion = camera.transform.rotation;
                    EventHandler_CameraMoveTarget(this, args);

                    Clear();
                }
            }
        }





    }
    public void SetTarget(GameObject target, bool bounds = true)
    {
        if (target == null)
            return;
        IsActive = true;
        targetObject = target.transform;

        if(bounds)
        {
            Bounds combinedBounds = new Bounds();
            var ren= target.GetComponentInChildren<Renderer>();
            //foreach(var render in ren)
            //{
            //    combinedBounds.Encapsulate(render.bounds);
            //}
            boundsData = combinedBounds;
            isBounds = true;


        }
        else
        {
            boundsData = new Bounds();
            isBounds = false;
        }    
    }
    public void Clear()
    {
        smoothTime = 0.3f;
        IsActive = false;
        targetObject = null;
        PassCount = 0;
    }
}
