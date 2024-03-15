using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Map
{
    public List<List<IMapNode>> Nodes { get; private set;}

    public Map()
    {
        Nodes = new List<List<IMapNode>>();

        List<IMapNode> row0 = new List<IMapNode>(){new BattleNode()};
        List<IMapNode> row1 = new List<IMapNode>(){new BattleNode(), new BattleNode()};
        List<IMapNode> row2 = new List<IMapNode>(){new BattleNode(), new BattleNode(), new BattleNode()};
        List<IMapNode> row3 = new List<IMapNode>(){new BattleNode(), new BattleNode()};
        List<IMapNode> row4 = new List<IMapNode>(){new BattleNode(), new BattleNode(), new BattleNode()};
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