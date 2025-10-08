namespace PathfindingAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        WeightedGraph weightedGraph = new WeightedGraph(5, false);
        weightedGraph.AddEdge(0, 1, 3);
        weightedGraph.AddEdge(0, 2, 4);
        weightedGraph.AddEdge(1, 3, 10);
        weightedGraph.AddEdge(1, 4, 5);
        weightedGraph.AddEdge(2, 3, 5);
        weightedGraph.AddEdge(2, 4, 2);
        weightedGraph.AddEdge(3, 4, 3);
        weightedGraph.PrintList();
        
        DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(weightedGraph);
        var result = dijkstra.Dijkstra(0);
        for (int i = 0; i < result.distances.Length; i++)
        {
            Console.WriteLine($"{i}번 노드까지의 최단 거리: {result.distances[i]}");
        }
    }
}