using System;
using System.Collections.Generic;

namespace PathfindingAlgorithm;

public class AstarAlgorithm
{
    private readonly WeightedGraph graph;
    private readonly Func<int, int, double> heuristic;

    public AstarAlgorithm(WeightedGraph graph, Func<int, int, double> heuristic)
    {
        this.graph = graph;
        this.heuristic = heuristic;
    }

    public List<int> FindPath(int start, int goal)
    {
        PriorityQueue<int, double> openSet = new PriorityQueue<int, double>(); // 탐색할 노드 우선순위 큐
        Dictionary<int, int> cameFrom = new Dictionary<int, int>(); // 최적 경로 추적용
        double[] gScore = new double[graph.size]; // 시작 노드부터 현재 노드까지의 비용
        double[] hScore = new double[graph.size]; // 시작 노드부터 목표 노드까지의 예상 비용

        for (int i = 0; i < graph.size; i++)
        {
            gScore[i] = double.PositiveInfinity;    // 초기 비용은 무한대
            hScore[i] = double.PositiveInfinity;    // 초기 예상 비용은 무한대
        }
        
        gScore[start] = 0;
        hScore[start] = heuristic(start, goal); // 휴리스틱 비용 계산
        
        openSet.Enqueue(start, hScore[start]); // 시작 노드 추가

        while (openSet.Count > 0)
        {
            int currentNode = openSet.Dequeue();
            
            if (currentNode == goal)
            {
                return ReconstructPath(cameFrom, currentNode); // 경로 재구성
            }

            foreach (var item in graph.GetNeighbors(currentNode))
            {
                double tentativeGScore = gScore[currentNode] + item.weight; // 현재 노드를 거쳐가는 비용 계산
                
                if (tentativeGScore < gScore[item.to]) // 더 짧은 경로 발견 시 업데이트
                {
                    cameFrom[item.to] = currentNode; // 이전 노드 갱신
                    gScore[item.to] = tentativeGScore; // 비용 갱신
                    hScore[item.to] = gScore[item.to] + heuristic(item.to, goal); // 총 예상 비용 갱신
                    
                    if (!openSet.UnorderedItems.Any(x => x.Element == item.to)) // 우선순위 큐에 없으면
                    {
                        openSet.Enqueue(item.to, hScore[item.to]); // 우선순위 큐에 추가
                    }
                }
            }
        }
        return new List<int>(); // 경로 없음
    }

    private List<int> ReconstructPath(Dictionary<int, int> cameFrom, int currentNode)
    {
        var totalPath = new List<int> { currentNode };  // 경로 재구성
        while (cameFrom.ContainsKey(currentNode))   // 이전 노드가 있으면
        {
            currentNode = cameFrom[currentNode];    // 이전 노드로 이동
            totalPath.Insert(0, currentNode);   // 경로에 추가
        }
        return totalPath;
    }
}