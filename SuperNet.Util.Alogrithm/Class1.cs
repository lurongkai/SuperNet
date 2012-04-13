using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperNet.Util.Alogrithm
{
    public class Edge
    {
        public string StartNodeID;
        public string EndNodeID;
        public double Weight; //权值，代价
    }

    public class Node
    {
        private string iD;
        private ArrayList edgeList;//Edge的集合－－出边表

        public Node(string id) {
            this.iD = id;
            this.edgeList = new ArrayList();
        }
        
        public string ID { get { return this.iD;}}
        public ArrayList EdgeList { get { return this.edgeList; }}
    }

    //用于缓存计算过程中的到达某个节点的权值最小的路径
    public class PassedPath
    {
        public PassedPath(string ID) {
            CurNodeID = ID;
            Weight = double.MaxValue;
            PassedIDList = new ArrayList();
            BeProcessed = false;
        }

        public bool BeProcessed { get; set; }//是否已被处理
        public string CurNodeID { get; private set; }
        public double Weight { get; set; }//累积的权值
        public ArrayList PassedIDList { get; private set; }//路径
    }

    //PlanCourse 缓存从源节点到其它任一节点的最小权值路径=》路径表
    public class PlanCourse
    {
        private Hashtable htPassedPath;
        
        public PlanCourse(ArrayList nodeList, string originID) {
            this.htPassedPath = new Hashtable();
            Node originNode = null;
            foreach (Node node in nodeList) {
                if (node.ID == originID) {
                    originNode = node;
                } else {
                    PassedPath pPath = new PassedPath(node.ID);
                    this.htPassedPath.Add(node.ID, pPath);
                }
            }
            if (originNode == null) {
                throw new Exception("The origin node is not exist !");
            }
            this.InitializeWeight(originNode);
        }

        private void InitializeWeight(Node originNode) {
            if ((originNode.EdgeList == null) || (originNode.EdgeList.Count == 0)) {
                return;
            }
            foreach (Edge edge in originNode.EdgeList) {
                PassedPath pPath = this[edge.EndNodeID];
                if (pPath == null) {
                    continue;
                }
                pPath.PassedIDList.Add(originNode.ID);
                pPath.Weight = edge.Weight;
            }
        }
        
        public PassedPath this[string nodeID] {
            get {
                return (PassedPath)this.htPassedPath[nodeID];
            }
        }
    }

    public class RoutePlanner
    {
        public RoutePlanner() {
        }

        //获取权值最小的路径
        public RoutePlanResult Paln(ArrayList nodeList, string originID, string destID) {
            PlanCourse planCourse = new PlanCourse(nodeList, originID);
            Node curNode = this.GetMinWeightRudeNode(planCourse, nodeList, originID);
            while (curNode != null) {
                PassedPath curPath = planCourse[curNode.ID];
                foreach (Edge edge in curNode.EdgeList) {
                    PassedPath targetPath = planCourse[edge.EndNodeID];
                    double tempWeight = curPath.Weight + edge.Weight;
                    if (tempWeight < targetPath.Weight) {
                        targetPath.Weight = tempWeight;
                        targetPath.PassedIDList.Clear();
                        for (int i = 0; i < curPath.PassedIDList.Count; i++) {
                            targetPath.PassedIDList.Add(curPath.PassedIDList.ToString());
                        }
                        targetPath.PassedIDList.Add(curNode.ID);
                    }
                }
                //标志为已处理
                planCourse[curNode.ID].BeProcessed = true;
                //获取下一个未处理节点
                curNode = this.GetMinWeightRudeNode(planCourse, nodeList, originID);
            }
            //表示规划结束
            return this.GetResult(planCourse, destID);
        }

        //从PlanCourse表中取出目标节点的PassedPath，这个PassedPath即是规划结果
        private RoutePlanResult GetResult(PlanCourse planCourse, string destID) {
            PassedPath pPath = planCourse[destID];
            if (pPath.Weight == int.MaxValue) {
                RoutePlanResult result1 = new RoutePlanResult(null, int.MaxValue);
                return result1;
            }
            string[] passedNodeIDs = new string[pPath.PassedIDList.Count];
            for (int i = 0; i < passedNodeIDs.Length; i++) {
                passedNodeIDs[i] = pPath.PassedIDList[i].ToString();
            }
            RoutePlanResult result = new RoutePlanResult(passedNodeIDs, pPath.Weight);
            return result;
        }
        //从PlanCourse取出一个当前累积权值最小，并且没有被处理过的节点
        private Node GetMinWeightRudeNode(PlanCourse planCourse, ArrayList nodeList, string originID) {
            double weight = double.MaxValue;
            Node destNode = null;
            foreach (Node node in nodeList) {
                if (node.ID == originID) {
                    continue;
                }
                PassedPath pPath = planCourse[node.ID];
                if (pPath.BeProcessed) {
                    continue;
                }
                if (pPath.Weight < weight) {
                    weight = pPath.Weight;
                    destNode = node;
                }
            }
            return destNode;
        }
    }

    public class RoutePlanResult
    {
        public RoutePlanResult(string[] passedNodes, double weight) {
            
        }
    }
}
