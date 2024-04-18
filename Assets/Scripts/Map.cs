using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = System.Random;

public class Map
{
    public List<List<IMapNode>> Nodes { get; private set;}
    public IMapNode GetNode(int nodeNumber) {
        int cumulativeCount = 0;
    
        foreach (var row in Nodes) {
            if (nodeNumber < cumulativeCount + row.Count) {
                int rowIndex = nodeNumber - cumulativeCount;
                return row[rowIndex];
            }
            cumulativeCount += row.Count;
        }
        return null;
    }
    
    private static Map _instance;
    public static Map Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Map();
            }
            return _instance;
        }
    }
    
    public int GetCumulativeIndex(IMapNode node)
    {
        int cumulativeIndex = 0;
        
        foreach (var nodeList in Nodes)
        {
            foreach (var mapNode in nodeList)
            {
                if (mapNode == node)
                {
                    return cumulativeIndex;
                }
                cumulativeIndex++;
            }
        }
        return -1; 
    }
    
    public Map()
    {
        Nodes = new List<List<IMapNode>>();
        int battleRoomsCount = GameDataController.Instance.BattleRoomRepository.GetAllBattleRooms().Count();
        RandomManager.ResetMapRandomSeed();
        List<IMapNode> row0 = new List<IMapNode>(){new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount))};
        List<IMapNode> row1 = new List<IMapNode>(){new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount)), new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount))};
        List<IMapNode> row2 = new List<IMapNode>(){new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount)), new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount)), new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount))};
        List<IMapNode> row3 = new List<IMapNode>(){new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount)), new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount))};
        List<IMapNode> row4 = new List<IMapNode>(){new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount)), new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount)), new BattleNode(RandomManager.GetRandomMapInt(0, battleRoomsCount))};
        List<IMapNode> row5 = new List<IMapNode>(){new RestNode(), new RestNode()};
        List<IMapNode> row6 = new List<IMapNode>(){new StageBossNode()}; 
        
        Nodes.Add(row0);
        Nodes.Add(row1);
        Nodes.Add(row2);
        Nodes.Add(row3);
        Nodes.Add(row4);
        Nodes.Add(row5);
        Nodes.Add(row6);

        for (int i =0 ; i < Nodes.Count; i++)
        {
            
            for (int j = 0; j < Nodes[i].Count; j++)
            {
                int nextRow = i + 1;
                if (nextRow <Nodes.Count)
                {
                    for (int k = 0; k < Nodes[nextRow].Count; k++)
                    {
                        Nodes[i][j].ConnectedNodes.Add(Nodes[nextRow][k]);
                    }    
                }    
            }
        }
    }
}