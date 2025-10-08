namespace PathfindingAlgorithm;

public class DFSAlgorithm
{
    private readonly Graph graph;

    public DFSAlgorithm(Graph graph)
    {
        this.graph = graph;
    }

    // 스택 기반 DFS 구현
    public void DFS(int start)
    {
        var visited = new bool[graph.AdjacencyList.Count]; // 방문 여부 배열
        var stack = new Stack<int>(); // 탐색할 노드 스택
        stack.Push(start); // 0

        while (stack.Count > 0)
        {
            int node = stack.Pop(); // node = 0
            // 이미 방문한 노드면 다음 반복문으로
            if (visited[node])
            {
                Console.WriteLine($"Already Visited Node: {node}");
                continue;
            }

            ;

            visited[node] = true; // 방문 처리
            Console.WriteLine($"Visited Node: {node}");

            // 인접 노드 스택에 추가
            if (graph.AdjacencyList.ContainsKey(node))
            {
                foreach (var neighbor in graph.AdjacencyList[node])
                {
                    if (!visited[neighbor])
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }
    }
}