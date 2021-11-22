using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerEmulator : MonoBehaviour {
    
    // scale method
    public enum ScaleMethod { PerAxis, Magnitude };

    // follow parameters
    public ScaleMethod m_scaleMethod;
    public Transform m_followRoot;
    public Transform m_followPart;
    public Transform m_applyRoot;
    public Transform m_applyPart;
    
    // deltas
    Vector3 m_scale = Vector3.one;
    Quaternion m_quatOffset;

    // component references
    Transform m_transform;

    // start
    void Start () {

        // get references
        m_transform = GetComponent<Transform>();

        // compute delta
        Vector3 followDelta = m_followPart.position - m_followRoot.position;
        Vector3 applyDelta = m_applyPart.position - m_applyRoot.position;

        // compute scale
        m_scale = Vector3.one;
        switch (m_scaleMethod)
        {
            case ScaleMethod.PerAxis:

                // scale per axis
                if (!Mathf.Approximately(followDelta.x, applyDelta.x) && !Mathf.Approximately(followDelta.x, 0)) m_scale.x = applyDelta.x / followDelta.x;
                if (!Mathf.Approximately(followDelta.y, applyDelta.y) && !Mathf.Approximately(followDelta.y, 0)) m_scale.y = applyDelta.y / followDelta.y;
                if (!Mathf.Approximately(followDelta.z, applyDelta.z) && !Mathf.Approximately(followDelta.z, 0)) m_scale.z = applyDelta.z / followDelta.z;
                break;

            case ScaleMethod.Magnitude:
                
                // scale by magnitude
                m_scale = Vector3.one * (applyDelta.magnitude / followDelta.magnitude);
                break;
        }

        // compute quaternion
        m_quatOffset = Quaternion.Inverse(m_followPart.rotation) * m_applyPart.rotation;
    }

    // emulate tracker
    void Update () {
        
        // scale relative to root
        Vector3 delta = m_followPart.position - m_followRoot.position;
        delta.x *= m_scale.x; delta.y *= m_scale.y; delta.z *= m_scale.z;

        // apply tracking
        m_transform.position = m_applyRoot.position + delta;
        m_transform.rotation = m_followPart.rotation * m_quatOffset;
    }
}
