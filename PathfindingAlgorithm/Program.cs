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
        dfs.DFS(0);
        
        
        Console.WriteLine("---------------------");
        
        BFSAlgorithm bfs = new BFSAlgorithm(graph);
        bfs.BFS(0);
    }
}