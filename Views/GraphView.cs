using System;
using System.Collections.Generic;
using CampusNet.Models;

namespace CampusNet.Views
{
    public class GraphView
    {
        public void ShowAdjacencyList(
            Dictionary<int, List<int>> adjacencyList,
            Dictionary<int, Vertex> vertices)
        {
            Console.WriteLine("\n===== LISTA DE ADYACENCIA =====");

            foreach (var item in adjacencyList)
            {
                Console.Write($"{vertices[item.Key].Nombre} -> ");

                foreach (var neighbor in item.Value)
                {
                    Console.Write($"{vertices[neighbor].Nombre} ");
                }

                Console.WriteLine();
            }
        }

        public void ShowTraversal(string title, List<int> traversal,
            Dictionary<int, Vertex> vertices)
        {
            Console.WriteLine($"\n===== {title} =====");

            foreach (var id in traversal)
            {
                Console.WriteLine(vertices[id]);
            }

            Console.WriteLine($"Total alcanzados: {traversal.Count}");
        }

        public void ShowUsers(string title, List<Vertex> users)
        {
            Console.WriteLine($"\n===== {title} =====");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}