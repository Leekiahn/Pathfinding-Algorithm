using System;
using System.Collections.Generic;

namespace PathfindingAlgorithm;

public class DijkstraAlgorithm
{
    private readonly WeightedGraph graph;

    public DijkstraAlgorithm(WeightedGraph graph)
    {
        this.graph = graph;
    }

    // 다익스트라 알고리즘 구현
    public (int[] distances, int[] previous) Dijkstra(int start)
    {
        int[] distances = new int[graph.size]; // 시작 노드로부터 모든 정점까지의 최단 거리
        int[] previous = new int[graph.size];  // 최단 경로 추적용 이전 노드
        SortedSet<(int distance, int node)> priorityQueue = new SortedSet<(int distance, int node)>(); // 우선순위 큐

        for (int i = 0; i < graph.size; i++)
        {
            distances[i] = int.MaxValue; // 초기 거리는 무한대
            previous[i] = -1;            // 이전 노드는 없음
        }

        distances[start] = 0;   // 시작 노드까지의 거리는 0
        priorityQueue.Add((0, start));  // 시작 노드 추가
        
        while (priorityQueue.Count > 0)
        {
            int currentDistance = priorityQueue.Min.distance;
            int currentNode = priorityQueue.Min.node;
            priorityQueue.Remove(priorityQueue.Min);

            if (currentDistance > distances[currentNode])
            {
                continue; // 이미 더 짧은 경로를 찾았으면 무시
            }

            foreach ((int neighbor, int weight) in graph.adjList[currentNode])
            {
                int distance = currentDistance + weight;
                if (distance < distances[neighbor])
                {
                    distances[neighbor] = distance;
                    previous[neighbor] = currentNode;
                    priorityQueue.Add((distance, neighbor));
                }
            }
        }

        return (distances, previous);
    }
}