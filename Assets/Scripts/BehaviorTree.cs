using System;
using System.Collections.Generic;
public interface INode
{
    public enum ENodeState
    {
        Running,
        Success,
        Failure,
    }

    public ENodeState Operate();
}

public class BehaviorTree
{
    INode rootNode;
    public BehaviorTree(INode _rootNode)
    {
        this.rootNode = _rootNode;
    }

    public void Run()
    {
        rootNode.Operate();
    }
}

public sealed class SequenceNode : INode
{
    List<INode> childs;

    public SequenceNode(List<INode> _childs)
    {
        this.childs = _childs;
    }

    public INode.ENodeState Operate()
    {
        if (childs == null || childs.Count == 0)
            return INode.ENodeState.Failure;

        foreach (var child in childs)
        {
            switch (child.Operate())
            {
                case INode.ENodeState.Running:
                    return INode.ENodeState.Running;
                case INode.ENodeState.Success:
                    continue;
                case INode.ENodeState.Failure:
                    return INode.ENodeState.Failure;
            }
        }

        return INode.ENodeState.Success;
    }
}


public sealed class SelectorNode : INode
{
    List<INode> childs;

    public SelectorNode(List<INode> _childs)
    {
        this.childs = _childs;
    }

    public INode.ENodeState Operate()
    {
        if (childs == null)
            return INode.ENodeState.Failure;

        foreach (var child in childs)
        {
            switch (child.Operate())
            {
                case INode.ENodeState.Running:
                    return INode.ENodeState.Running;
                case INode.ENodeState.Success:
                    return INode.ENodeState.Success;
            }
        }

        return INode.ENodeState.Failure;
    }
}

public sealed class ActionNode : INode
{
    Func<INode.ENodeState> onTask = null;

    public ActionNode(Func<INode.ENodeState> onUpdate)
    {
        onTask = onUpdate;
    }

    public INode.ENodeState Operate() => onTask?.Invoke() ?? INode.ENodeState.Failure;
}