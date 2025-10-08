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
        int[] distances = new int[graph.size]; // 최단 거리 배열
        int[] previous = new int[graph.size];  // 이전 노드 배열
        PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(); // 우선순위 큐 

        for (int i = 0; i < graph.size; i++)
        {
            distances[i] = int.MaxValue; // 초기 거리는 무한대
            previous[i] = -1;            // 이전 노드는 없음
        }

        distances[start] = 0;   // 시작 노드까지의 거리는 0
        priorityQueue.Enqueue(0, start);  // 시작 노드 추가
        
        while (priorityQueue.Count > 0)
        {
            priorityQueue.TryDequeue(out int currentDistance, out int currentNode);   // 선택한 노드 제거
            
            if (currentDistance > distances[currentNode])
            {
                continue; // 이미 더 짧은 경로를 찾았으면 무시
            }
            
            // 인접 노드 탐색
            foreach ((int neighbor, int weight) in graph.adjList[currentNode])
            {
                int distance = currentDistance + weight;    // 현재 노드를 거쳐가는 거리 계산
                if (distance < distances[neighbor])     // 더 짧은 경로 발견 시 업데이트
                {
                    distances[neighbor] = distance; // 최단 거리 갱신
                    previous[neighbor] = currentNode;   // 이전 노드 갱신
                    priorityQueue.Enqueue(distance, neighbor);    // 우선순위 큐에 추가
                }
            }
        }

        return (distances, previous);
    }
}