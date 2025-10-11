using System.Reflection;

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
        
        Console.WriteLine("BFS 너비 우선 탐색");
        BFSAlgorithm bfs = new BFSAlgorithm(graph);
        bfs.BFS(0);
        
        WeightedGraph weightedGraph = new WeightedGraph(6, true);
        weightedGraph.AddEdge(0, 1, 2);
        weightedGraph.AddEdge(0, 2, 5);
        weightedGraph.AddEdge(1, 3, 7);
        weightedGraph.AddEdge(1, 4, 3);
        weightedGraph.AddEdge(2, 3, 2);
        weightedGraph.AddEdge(2, 4, 4);
        weightedGraph.AddEdge(3, 5, 1);
        weightedGraph.AddEdge(4, 5, 4);
        weightedGraph.PrintList();
        DijkstraAlgorithm dijkstra = new DijkstraAlgorithm(weightedGraph);
        int i = 0;
        foreach (var shortest in dijkstra.Dijkstra(0).distances)
        {
            Console.WriteLine($"{i} 까지의 최단 거리: {shortest}");
            i++;
        }
        
        Func<int, int, double> heuristic = (node, goal) => 0;
        
        AstarAlgorithm astar = new AstarAlgorithm(weightedGraph, heuristic);
        var result = astar.FindPath(0, 5);
        Console.WriteLine("A* 알고리즘 최단 경로: " + string.Join(" -> ", result.path));
        Console.WriteLine("최단 거리: " + string.Join(" -> ", result.cost));
        
    }
}