using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public enum StateID
{
    None,
    Move,
    Jump,
    Fall,
    Somersault,
    Land,
    Attack = 10,
}

public class BehaviourManager : MonoBehaviour
{
    public bool isGrounded => Physics.SphereCast(transform.position + Vector3.up, 0.1f, Vector3.down, out RaycastHit hit, _groundDetectionMaxDistance + 1.0f, _groundMask);
    [SerializeField]private LayerMask _groundMask;
    [SerializeField]private float _groundDetectionMaxDistance;
    public bool hasJumped;
    public bool hasSomersault;
    public bool hasAttacked;
    public StateMachineBehaviour currentMahineBehaviour;
    public StateID currentStateID;
    private Animator _currentAnimator;
    private Vector3 _inertia;
    private float _drag;
    private Vector3 _prevPos;
    public bool ChangeState(StateID newStateID)
    {
        _currentAnimator.SetBool("isDirty", true);
        _currentAnimator.SetInteger("stateID", (int)newStateID);
        currentStateID= newStateID;
        return true;
    }

    public void ChangeStateForcely(StateID newStateID)
    {
        if (currentStateID == newStateID)
        _currentAnimator.SetBool("isDirty", true);
        _currentAnimator.SetInteger("stateID", (int)newStateID);
        currentStateID = newStateID;
    }

    private void Awake()
    {
        _currentAnimator= GetComponent<Animator>();
        
        BehaviourBase[] behaviours = _currentAnimator.GetBehaviours<BehaviourBase>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        _drag = rigidbody.drag;
        for (int i = 0; i < behaviours.Length; i++)
        {
            behaviours[i].Initialize(this, rigidbody);
        }
        ComboStackingBehaviour[] comboStackingStateBehaviours = _currentAnimator.GetBehaviours<ComboStackingBehaviour>();

        for (int i = 0; i < comboStackingStateBehaviours.Length; i++)
        {
            comboStackingStateBehaviours[i].Initialize(this);
        }

        ChangeState(StateID.Move);
    }
    private void FixedUpdate()
    {
       
        if(isGrounded)
        {
            _inertia = (transform.position - _prevPos) / Time.fixedDeltaTime;
        }
        else 
        {
            transform.position += new Vector3(_inertia.x, 0.0f, _inertia.z) * Time.fixedDeltaTime;
            _inertia = Vector3.Lerp(_inertia, Vector3.zero, _drag * Time.fixedDeltaTime);
        }

        _prevPos= transform.position;
    }
}