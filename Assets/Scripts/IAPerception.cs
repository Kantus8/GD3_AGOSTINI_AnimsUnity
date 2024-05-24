using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IAPerception : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pawn;
    private Vector3 _checkDirection;
    [SerializeField] private float _distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckDistance()
    {
        _checkDirection = _player.transform.position - _pawn.transform.position;
        _checkDirection = _checkDirection.normalized;
        _checkDirection = _checkDirection * _distance;
        RaycastHit hit;

        if(Physics.Raycast(_pawn.transform.position,_checkDirection,out hit, _distance))
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>())
            {
                _pawn.GetComponentInChildren<IAController>().PlayerNear = true;
            }
            else
            {
                _pawn.GetComponentInChildren<IAController>().PlayerNear = false;
            }
        }
        else
        {
            _pawn.GetComponentInChildren<IAController>().PlayerNear = false;
        }
    }
}
