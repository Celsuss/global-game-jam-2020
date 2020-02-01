using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    private Transform m_SpawnTransform;
    private Transform m_PlayerTransform;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        m_PlayerTransform.position = m_SpawnTransform.position;
    }
}
