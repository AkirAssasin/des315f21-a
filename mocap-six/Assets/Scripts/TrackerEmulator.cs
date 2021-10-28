using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerEmulator : MonoBehaviour {
    
    // parameters
    public Transform m_follow;
    public Vector3 m_offset;

    // component references
    Transform m_transform;

    // start
    void Start () {

        // get references
        m_transform = GetComponent<Transform>();
    }

    // emulate tracker
    void Update () {
        
        m_transform.position = m_follow.position + m_offset;
        m_transform.rotation = m_follow.rotation;
    }
}
