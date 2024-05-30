using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public enum IAState
{
    None,
    Idle,
    Patrol,
    RandomLook,
    PlayerSeen,
    PlayerNear,
}
public class IAController : MonoBehaviour
{
    public IAState _state = IAState.None;
    [SerializeField] private Animator _animator;
    public bool PlayerNear = false;
    public bool PlayerSeen = false;
    public bool RandomLook = false;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _waypoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckTransition();
        Behaviour();
    }

    private void Behaviour()
    {
        switch(_state)
        {
            case IAState.None:
                //
                //
                break;
            case IAState.Idle:
                //
                //
                break;
            case IAState.Patrol:
                //
                //
                break;
            case IAState.RandomLook:
                //
                //
                break;
            case IAState.PlayerSeen:
                //
                _agent.SetDestination(_waypoint.transform.position);
                if (_agent.remainingDistance == 50)
                {

                }
                //
                break;
            case IAState.PlayerNear:
                //
                //
                break;
        }
    }

    private void CheckTransition()
    {
        switch (_state)
        {
            case IAState.None:
                break;
            case IAState.Idle:
                if (PlayerNear)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("isPlayerClose", true);
                }
                else if (PlayerSeen)
                {
                    _state = IAState.PlayerSeen;
                    _animator.SetBool("isPlayerSeen", true);
                }
                else if (RandomLook)
                {
                    _state = IAState.RandomLook;
                    _animator.SetBool("isRandomLook", true);
                }
                break;
            case IAState.Patrol:
                if (PlayerNear)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("isPlayerClose", true);
                }
                else if (PlayerSeen)
                {
                    _state = IAState.PlayerSeen;
                    _animator.SetBool("isPlayerSeen", true);
                }
                else if (RandomLook)
                {
                    _state = IAState.RandomLook;
                    _animator.SetBool("isRandomLook", true);
                }
                break;
            case IAState.RandomLook:
                if (PlayerNear)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("isPlayerClose", true);
                }
                else if (PlayerSeen)
                {
                    _state = IAState.PlayerSeen;
                    _animator.SetBool("isPlayerSeen", true);
                }
                else if (!RandomLook)
                {
                    _state = IAState.Idle;
                    _animator.SetBool("isRandomLook", false);
                }
                break;
            case IAState.PlayerSeen:
                if (PlayerNear)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("isPlayerClose", true);
                }
                else if (!PlayerSeen)
                {
                    _state = IAState.Idle;
                    _animator.SetBool("isPlayerSeen", false);
                }
                break;
            case IAState.PlayerNear:
                if (!PlayerNear)
                {
                    _state = IAState.PlayerSeen;
                    _animator.SetBool("isPlayerClose", false);

                }
                break;
        }
    }
}
