namespace PathfindingAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph(5, false);
        graph.AddEdge(0, 2);
        graph.AddEdge(2, 4);
        graph.AddEdge(4, 1);
        graph.AddEdge(1, 3);

        DFSAlgorithm dfs = new DFSAlgorithm(graph);
        dfs.StackBasedDFS(0);
    }
}