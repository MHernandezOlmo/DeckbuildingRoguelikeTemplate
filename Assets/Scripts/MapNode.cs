using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public interface IMapNode
{
    List<IMapNode> ConnectedNodes { get; set;}
}

public class BattleNode : IMapNode
{
    private int _battleRoomID;

    public int GetBattleRoomID()
    {
        return _battleRoomID;
    }
    public BattleNode(int battleRoomID)
    {
        _battleRoomID = battleRoomID;
        Debug.Log(battleRoomID);
    }
    public List<IMapNode> ConnectedNodes { get; set; } = new List<IMapNode>();
}

public class RestNode : IMapNode
{
    public List<IMapNode> ConnectedNodes { get; set; } = new List<IMapNode>();
}


public class TreasureNode : IMapNode
{
    public List<IMapNode> ConnectedNodes { get; set; } = new List<IMapNode>();
}

public class ShopNode : IMapNode
{
    public List<IMapNode> ConnectedNodes { get; set; } = new List<IMapNode>();
}

public class SmallBossNode : IMapNode
{
    public List<IMapNode> ConnectedNodes { get; set; } = new List<IMapNode>();
}

public class StageBossNode : IMapNode
{
    public List<IMapNode> ConnectedNodes { get; set; } = new List<IMapNode>();
}