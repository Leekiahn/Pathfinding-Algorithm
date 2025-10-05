namespace PathfindingAlgorithm;

public class DFSAlgorithm
{
    private readonly Graph graph;
    
    public DFSAlgorithm(Graph graph)
    {
        this.graph = graph;
    }

    // 스택 기반 DFS 구현
    public void StackBasedDFS(int start)
    {
        // 노드 개수만큼 bool 배열 생성
        var visited = new bool[graph.AdjacencyList.Count];
        var stack = new Stack<int>();
        stack.Push(start);
        
        while(stack.Count > 0)
        {
            int node = stack.Pop();
            if (visited[node]) continue;    // 이미 방문한 노드면 무시
            
            visited[node] = true;   // 방문 처리
            Console.WriteLine($"Visited Node: {node}");

            // 인접 노드 스택에 추가
            if (graph.AdjacencyList.ContainsKey(node))
            {
                foreach (var neighbor in graph.AdjacencyList[node])
                {
                    stack.Push(neighbor);
                }
            }
        }
    }
    
    // 재귀 기반 DFS 구현
    public void RecursiveBasedDFS(int start)
    {
        var visited = new bool[graph.AdjacencyList.Count];
        DFSUtil(start, visited);
    }

    private void DFSUtil(int node, bool[] visited)
    {
        if (visited[node]) return;
        visited[node] = true;
        Console.WriteLine($"Visited Node: {node}");

        if (graph.AdjacencyList.ContainsKey(node))
        {
            foreach (var neighbor in graph.AdjacencyList[node])
            {
                DFSUtil(neighbor, visited);
            }
        }
    }
}