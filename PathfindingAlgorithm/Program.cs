namespace PathfindingAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(7, false);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 4);
        graph.AddEdge(3, 5);
        graph.AddEdge(4, 6);
        graph.AddEdge(5, 6);

        DFSAlgorithm dfs = new DFSAlgorithm(graph);
        Console.WriteLine("깊이 우선 탐색");
        dfs.DFS(0);
        
        
        Console.WriteLine("---------------------");
        BFSAlgorithm bfs = new BFSAlgorithm(graph);
        Console.WriteLine("너비 우선 탐색");
        bfs.BFS(0);

        
        WeightedGraph weightedGraph = new WeightedGraph(6, false);
        weightedGraph.AddEdge(0, 1, 3);
        weightedGraph.AddEdge(0, 2, 4);
        weightedGraph.AddEdge(1, 2, 5);
        weightedGraph.AddEdge(1, 3, 5);
        weightedGraph.AddEdge(1, 4, 7);
        weightedGraph.AddEdge(2, 4, 2);
        weightedGraph.AddEdge(2, 5, 1);
        weightedGraph.AddEdge(3, 4, 2);
        weightedGraph.AddEdge(4, 5, 4);
        weightedGraph.PrintList();
        
        DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(weightedGraph);
        Console.WriteLine("다익스트라 알고리즘");
        var result = dijkstra.Dijkstra(0);
        for (int i = 0; i < result.distances.Length; i++)
        {
            Console.WriteLine($"{i}번 노드까지의 최단 거리: {result.distances[i]}");
        }
    }
}