using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star
{
    internal class PathFinding
    {
        private int[,] map;
        private int mapWidth;
        private int mapHeight;
        private List<Node> openList;
        private List<Node> closeList;

       public PathFinding(int[,]map)
        {
            this.map = map;
            mapWidth = map.GetLength(0);
            mapHeight = map.GetLength(1);
        }
        private bool IsWalkable(int x,int y)
        {
            return map[x, y] == 0;
        }

        private Node GetLowestCostNode(List<Node>list)
        {
            Node lowestCostNode = list[0];
            for(int i=1;i<list.Count;i++)
            {
                if (list[i].fCost < lowestCostNode.fCost)
                {
                    lowestCostNode = list[i];
                }    
            }    
            return lowestCostNode;
        }

        private List<Node> GetNeighbor(Node node)
        {
            List<Node> neighborList = new List<Node> ();
            for(int i= -1;i<=1;i++)
            {
                for(int j = -1;j<=1;j++)
                {
                    if (i == 0 && j == 0) continue;
                    int neighborX = node.x + i;
                    int neighborY = node.y + j;
                    if (neighborX < 0 || neighborX >= mapWidth || neighborY < 0 || neighborY >= mapHeight) continue;
                    if (!IsWalkable(neighborX, neighborY)) continue;
                    Node neighborNode = new Node(neighborX, neighborY);
                    neighborList.Add(neighborNode);
                }    
            }    
            return neighborList;
        }

        private List<Node>FindPath(Node startNode,Node endNode)
        {
            openList = new List<Node> { startNode };
            startNode.CalculatorCost(endNode);
            closeList = new List<Node>();
            while(openList.Count > 0)
            {
                Node curentNode = GetLowestCostNode(openList);
                if(curentNode.x ==endNode.x && curentNode.y ==endNode.y)
                {
                    List<Node> path = new List<Node>();
                    while(curentNode != null)
                    {
                        path.Add(curentNode);
                        curentNode = curentNode.nodeParrent;
                    }
                    path.Reverse();
                    return path;
                }
                openList.Remove(curentNode);
                closeList.Add(curentNode);
                List<Node> neighborList = GetNeighbor(curentNode);
                foreach(Node node in neighborList)
                {
                    if (node.IsOnList(closeList) ||node.IsOnList(openList)) continue;//neu node nay co trong close list roi thi bo qua
                    node.nodeParrent = curentNode;
                    node.CalculatorCost(endNode);
                    openList.Add(node);

                }    
            }
            return new List<Node>();//list rong,khong tim duoc
        }
        public List<Node> CalculatePath(int startX,int startY,int endX,int endY)
        {
            Node startNode = new Node(startX, startY);
            Node endNode = new Node(endX, endY);
            return FindPath(startNode,endNode);
        }    
    }
    
}
