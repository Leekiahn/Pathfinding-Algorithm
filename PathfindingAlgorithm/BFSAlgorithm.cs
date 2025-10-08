namespace PathfindingAlgorithm;

public class BFSAlgorithm
{
    private readonly Graph graph;

    public BFSAlgorithm(Graph graph)
    {
        this.graph = graph;
    }

    // 큐 기반 BFS 구현
    public void BFS(int start)
    {
        var visited = new bool[graph.AdjacencyList.Count];
        var queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.WriteLine($"Visited Node: {node}");

            foreach (var neighbor in graph.AdjacencyList[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}