using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    public BlackBoard blackBoard;
    public Root root;
    public bool isSleeping;

    public Status Tick()
    {
        return isSleeping ? Status.Running : root.Invoke();
    }

    private Node _current;
    private Stack<Composite> _compositeStack = new Stack<Composite>();
    public BehaviourTree StartBuild(GameObject owner)
    {
        blackBoard = new BlackBoard(owner);
        root = new Root(this);
        _current = root;
        return this;
    }
    

    public BehaviourTree ExitCurrentComposite()
    {
        if(_compositeStack.Count > 1)
        {
            _compositeStack.Pop();
            _current = _compositeStack.Peek();
        }
        else if(_compositeStack.Count == 1)
        {
            _compositeStack.Pop();
            _current = null;
        }
        else
        {
            throw new Exception($"[BehaviourTree.ExitCurrentComposite()] : 컴포지스트 스택이 비어있어 탈풀할 수 없습니다");
        }

        return this;
    }


    public BehaviourTree Condition(Func<bool> condition)
    {
        Node node = new Condition(this, condition);
        AttachAsCild(_current, node);
        _current = node;
        return this;
    }

    public BehaviourTree Seek(float radius, float angle, float deltaAngle, LayerMask tarGetMask, Vector3 offset)
    {
        Node node = new Seek(this, radius, angle, deltaAngle, tarGetMask, offset);
        AttachAsCild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;

        return this;
    }

    public BehaviourTree Sequence()
    {
        Composite node = new Sequence(this);
        AttachAsCild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    public BehaviourTree Selector()
    {
        Composite node = new Selector(this);
        AttachAsCild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    public BehaviourTree parallel(Parallel.Policy succesPolicy)
    {
        Composite node = new Parallel(this, succesPolicy);
        AttachAsCild(_current, node);
        _current = node;
        _compositeStack.Push(node);
        return this;
    }

    private void AttachAsCild(Node parent, Node child)
    {
        if(parent is IParentOfChild)
        {
            ((IParentOfChild)parent).child = child;
        }
        else if(parent is IParentOfChildren)
        {
           ((IParentOfChildren)parent).children.Add(child);
        }
        else
        {
            throw new Exception($"[BeHaviourTree] : {parent.GetType()} 에다가 자식 노드를 붙일 수 없습니다.");
        }
    }

    public BehaviourTree Execution(Func<Status> execute) 
    {
        Node node= new Execution(this, execute);
        AttachAsCild(_current, node);

        if(_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;
        return this;
    }

    public BehaviourTree Patrol(float radius)
    {
        Node node = new patrol(this, radius);
        AttachAsCild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;
        return this;
    }

    public BehaviourTree RandomSleep(float min, float max)
    {
        Node node = new RandomSleep(this, min, max);
        AttachAsCild(_current, node);

        if (_compositeStack.Count > 0)
            _current = _compositeStack.Peek();
        else
            _current = null;
        return this;
    }


}