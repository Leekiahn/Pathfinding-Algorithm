namespace PathfindingAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(10, false);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 6);
        graph.AddEdge(3, 7);
        graph.AddEdge(3, 8);
        graph.AddEdge(4, 9);
        graph.PrintList();
        
        Console.WriteLine("DFS 깊이 우선 탐색");
        DFSAlgorithm dfs = new DFSAlgorithm(graph);
        dfs.DFS(0);
    }
}