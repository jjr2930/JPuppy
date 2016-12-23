using UnityEngine;
using System.Collections;
using JLib;
public class FurShaderScript : JMonoBehaviour
{
    [SerializeField]
    float gravityFactor = 0f;

    [SerializeField]
    float localVelocityFactor= 0f;

    [SerializeField]
    float windVelocityFactor = 0f;

    [SerializeField]
    Vector3 localVelocity = Vector3.zero;

    [SerializeField]
    Vector3 gravity = Vector3.zero;

    [SerializeField]
    Vector3 windVelocity = Vector3.zero;

    Material material = null;

    Vector3 beforePosition = Vector3.zero;

    Vector3 beforeVelocity = Vector3.zero;

    Vector3 curVelocity = Vector3.zero;
    // Use this for initialization
    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        curVelocity.x = transform.position.x - beforePosition.x;
        curVelocity.y = transform.position.y - beforePosition.y;
        curVelocity.z = transform.position.z - beforePosition.z;

        localVelocity = Vector3.Lerp(curVelocity,beforeVelocity , JTime.DeltaTime);
        beforeVelocity = curVelocity;
        //localVelocity = Vector3.Lerp(transform.position, beforePosition, JTime.DeltaTime);

        beforePosition.x = transform.position.x;
        beforePosition.y = transform.position.y;
        beforePosition.z = transform.position.z;

        gravity = Physics.gravity ;

        //material.SetVector( "_Gravity" , gravity * JTime.DeltaTime * gravityFactor );
        //material.SetVector( "_LocalVelocity" , localVelocity * JTime.DeltaTime * localVelocityFactor );
        //material.SetVector( "_WindVelocity" , windVelocity * JTime.DeltaTime * windVelocityFactor );

        material.SetVector( "_Gravity" , gravity * gravityFactor );
        material.SetVector( "_LocalVelocity" , localVelocity * localVelocityFactor );
        material.SetVector( "_WindVelocity" , windVelocity * windVelocityFactor );
    }
}
