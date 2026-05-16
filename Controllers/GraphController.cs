using CampusNet.Models;
using CampusNet.Views;

namespace CampusNet.Controllers
{
    public class GraphController
    {
        private Graph graph;
        private GraphView view;

        public GraphController()
        {
            graph = new Graph();
            view = new GraphView();
        }

        public void Run()
        {
            LoadData();

            view.ShowAdjacencyList(
                graph.GetAdjacencyList(),
                graph.GetVertices());

            ExecuteBFS();
            ExecuteDFS();
            ExecuteQueries();
            ExecuteCRUD();
        }

        private void LoadData()
        {
            graph.AddVertex(new Vertex(1, "Ana", "Estudiante"));
            graph.AddVertex(new Vertex(2, "Luis", "Profesor"));
            graph.AddVertex(new Vertex(3, "Maria", "Egresado"));
            graph.AddVertex(new Vertex(4, "Carlos", "Estudiante"));
            graph.AddVertex(new Vertex(5, "Laura", "Profesor"));
            graph.AddVertex(new Vertex(6, "Pedro", "Egresado"));
            graph.AddVertex(new Vertex(7, "Camila", "Estudiante"));
            graph.AddVertex(new Vertex(8, "Jorge", "Profesor"));
            graph.AddVertex(new Vertex(9, "Sofia", "Egresado"));
            graph.AddVertex(new Vertex(10, "Miguel", "Estudiante"));
            graph.AddVertex(new Vertex(11, "Valentina", "Profesor"));
            graph.AddVertex(new Vertex(12, "Andres", "Egresado"));

            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 5);

            graph.AddEdge(2, 3);
            graph.AddEdge(2, 6);
            graph.AddEdge(2, 7);
            graph.AddEdge(2, 8);

            graph.AddEdge(3, 1);

            graph.AddEdge(4, 5);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 8);
            graph.AddEdge(8, 9);
            graph.AddEdge(9, 10);
            graph.AddEdge(10, 11);
            graph.AddEdge(11, 12);
            graph.AddEdge(12, 4);
        }

        private void ExecuteBFS()
        {
            view.ShowTraversal(
                "BFS DESDE ANA",
                graph.BFS(1),
                graph.GetVertices());

            view.ShowTraversal(
                "BFS DESDE CARLOS",
                graph.BFS(4),
                graph.GetVertices());

            view.ShowTraversal(
                "BFS DESDE MIGUEL",
                graph.BFS(10),
                graph.GetVertices());
        }

        private void ExecuteDFS()
        {
            view.ShowTraversal(
                "DFS COMPLETO",
                graph.DFS(),
                graph.GetVertices());

            view.ShowMessage(
                graph.HasCycle()
                    ? "\nEl grafo tiene ciclos."
                    : "\nEl grafo NO tiene ciclos.");
        }

        private void ExecuteQueries()
        {
            view.ShowUsers(
                "USUARIOS SIN SEGUIDORES",
                graph.UsersWithoutFollowers());

            view.ShowUsers(
                "USUARIOS INFLUYENTES",
                graph.MostInfluentialUsers());

            view.ShowUsers(
                "USUARIOS MÁS ACTIVOS",
                graph.MostActiveUsers());

            bool canReach = graph.CanReach(1, 11);

            view.ShowMessage(
                canReach
                    ? "\nAna puede llegar a Valentina."
                    : "\nAna NO puede llegar a Valentina.");
        }

        private void ExecuteCRUD()
        {
            graph.AddVertex(new Vertex(13, "Ricardo", "Estudiante"));

            view.ShowMessage("\nUsuario agregado.");

            graph.AddEdge(13, 1);

            view.ShowMessage("Relación agregada.");

            graph.UpdateVertex(13, "Ricardo Marin", "Egresado");

            view.ShowMessage("Usuario actualizado.");

            graph.RemoveEdge(13, 1);

            view.ShowMessage("Relación eliminada.");

            graph.RemoveVertex(13);

            view.ShowMessage("Usuario eliminado.");

            view.ShowAdjacencyList(
                graph.GetAdjacencyList(),
                graph.GetVertices());
        }
    }
}