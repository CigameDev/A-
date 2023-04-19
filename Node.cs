using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Star
{
    internal class Node
    {

        public int x;
        public int y;
        public int gCost;
        public int hCost;
        public int fCost;

        public Node nodeParrent;
        public Node( int x,int y)
        {
            this.x = x;
            this.y = y;
        }    

        public void CalculatorCost(Node nodeEnd)
        {
            if (nodeParrent == null)
            {
                gCost = 0;
            }
            else
            {
                if(x==nodeParrent.x || y==nodeParrent.y)
                {
                    gCost = nodeParrent.gCost + 10;
                }   
                else
                {
                    gCost = nodeParrent.gCost + 14;
                }    
            }
            int deltaX = Math.Abs(x - nodeEnd.x);
            int deltaY = Math.Abs(y - nodeEnd.y);
            int min = deltaX <=deltaY ? deltaX : deltaY;
            hCost = min * 14 + Math.Abs(deltaX - deltaY) * 10;
            fCost = gCost + hCost;
        }
        public bool IsOnList(List<Node>list)
        {
            for(int i=0;i<list.Count;i++)
            {
                if (x == list[i].x && y == list[i].y) return true;
            }    
            return false;
        }
    }
}
