namespace PathfindingAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(7, false);
        graph.AddEdge(0, 2);
        graph.AddEdge(0, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 1);

        DFSAlgorithm dfs = new DFSAlgorithm(graph);
        dfs.DFS(0);
        
        Console.WriteLine("---------------------");
        
        BFSAlgorithm bfs = new BFSAlgorithm(graph);
        bfs.BFS(0);
    }
}