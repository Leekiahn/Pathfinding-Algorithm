namespace PathfindingAlgorithm;

public class DFSAlgorithm
{
    private readonly Graph graph;
    private readonly HashSet<int> visited; // 방문한 노드 집합
    
    public DFSAlgorithm(Graph graph)
    {
        this.graph = graph;
        this.visited = new HashSet<int>(); // visited 초기화
    }

    public void DFS(int start)
    {
        if(visited.Contains(start)) return;
        
        visited.Add(start);
        Console.WriteLine($"Visited Node: {start}");

        if (graph.AdjacencyList.ContainsKey(start))
        {
            foreach (var neighbor in graph.AdjacencyList[start])
            {
                DFS(neighbor);
            }
        }
    }
}