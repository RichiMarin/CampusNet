using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusNet.Models
{
    public class Graph
    {
        private Dictionary<int, Vertex> vertices;
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            vertices = new Dictionary<int, Vertex>();
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // =========================
        // CRUD VERTICES
        // =========================

        public bool AddVertex(Vertex vertex)
        {
            if (vertices.ContainsKey(vertex.Id))
                return false;

            vertices[vertex.Id] = vertex;
            adjacencyList[vertex.Id] = new List<int>();

            return true;
        }

        public bool RemoveVertex(int id)
        {
            if (!vertices.ContainsKey(id))
                return false;

            vertices.Remove(id);
            adjacencyList.Remove(id);

            foreach (var list in adjacencyList.Values)
            {
                list.Remove(id);
            }

            return true;
        }

        public bool UpdateVertex(int id, string nuevoNombre, string nuevoRol)
        {
            if (!vertices.ContainsKey(id))
                return false;

            vertices[id].Nombre = nuevoNombre;
            vertices[id].Rol = nuevoRol;

            return true;
        }

        // =========================
        // CRUD ARISTAS
        // =========================

        public bool AddEdge(int from, int to)
        {
            if (!vertices.ContainsKey(from) || !vertices.ContainsKey(to))
                return false;

            if (adjacencyList[from].Contains(to))
                return false;

            adjacencyList[from].Add(to);

            return true;
        }

        public bool RemoveEdge(int from, int to)
        {
            if (!adjacencyList.ContainsKey(from))
                return false;

            return adjacencyList[from].Remove(to);
        }

        // =========================
        // GETTERS
        // =========================

        public Dictionary<int, List<int>> GetAdjacencyList()
        {
            return adjacencyList;
        }

        public Dictionary<int, Vertex> GetVertices()
        {
            return vertices;
        }

        // =========================
        // BFS
        // =========================

        public List<int> BFS(int start)
        {
            List<int> result = new List<int>();

            if (!vertices.ContainsKey(start))
                return result;

            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(current);

                foreach (var neighbor in adjacencyList[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }

        // =========================
        // DFS
        // =========================

        public List<int> DFS()
        {
            HashSet<int> visited = new HashSet<int>();
            List<int> result = new List<int>();

            foreach (var vertex in vertices.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    DFSUtil(vertex, visited, result);
                }
            }

            return result;
        }

        private void DFSUtil(int current, HashSet<int> visited, List<int> result)
        {
            visited.Add(current);
            result.Add(current);

            foreach (var neighbor in adjacencyList[current])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSUtil(neighbor, visited, result);
                }
            }
        }

        // =========================
        // CICLOS
        // =========================

        public bool HasCycle()
        {
            HashSet<int> visited = new HashSet<int>();
            HashSet<int> recursionStack = new HashSet<int>();

            foreach (var vertex in vertices.Keys)
            {
                if (HasCycleDFS(vertex, visited, recursionStack))
                    return true;
            }

            return false;
        }

        private bool HasCycleDFS(int vertex,
            HashSet<int> visited,
            HashSet<int> recursionStack)
        {
            if (recursionStack.Contains(vertex))
                return true;

            if (visited.Contains(vertex))
                return false;

            visited.Add(vertex);
            recursionStack.Add(vertex);

            foreach (var neighbor in adjacencyList[vertex])
            {
                if (HasCycleDFS(neighbor, visited, recursionStack))
                    return true;
            }

            recursionStack.Remove(vertex);

            return false;
        }

        // =========================
        // CONSULTAS
        // =========================

        public List<Vertex> UsersWithoutFollowers()
        {
            Dictionary<int, int> inDegree = vertices.Keys
                .ToDictionary(v => v, v => 0);

            foreach (var list in adjacencyList.Values)
            {
                foreach (var neighbor in list)
                {
                    inDegree[neighbor]++;
                }
            }

            return inDegree
                .Where(x => x.Value == 0)
                .Select(x => vertices[x.Key])
                .ToList();
        }

        public List<Vertex> MostInfluentialUsers()
        {
            Dictionary<int, int> inDegree = vertices.Keys
                .ToDictionary(v => v, v => 0);

            foreach (var list in adjacencyList.Values)
            {
                foreach (var neighbor in list)
                {
                    inDegree[neighbor]++;
                }
            }

            int max = inDegree.Values.Max();

            return inDegree
                .Where(x => x.Value == max)
                .Select(x => vertices[x.Key])
                .ToList();
        }

        public List<Vertex> MostActiveUsers()
        {
            int max = adjacencyList.Values.Max(x => x.Count);

            return adjacencyList
                .Where(x => x.Value.Count == max)
                .Select(x => vertices[x.Key])
                .ToList();
        }

        public bool CanReach(int from, int to)
        {
            return BFS(from).Contains(to);
        }
    }
}