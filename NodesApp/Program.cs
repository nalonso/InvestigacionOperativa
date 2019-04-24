using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creación de nodos y enlazamiento!");
            List<ClsNode> nodeList = new List<ClsNode>();
            bool insertNode = true;
            Console.WriteLine("Inserte un nombre de nodo");
            var name = Console.ReadLine();
            nodeList.Add(new ClsNode(string.IsNullOrEmpty(name) ? "Nombre no informado" : name));
            var firstNode = nodeList.Last();
            Console.WriteLine("Quiere ingresar otro nodo? S/N");
            var continueCondition = Console.ReadKey();
            if (continueCondition.Key == ConsoleKey.N)
                insertNode = false;
            while (insertNode)
            {
                Console.Clear();
                Console.WriteLine("Inserte el nombre del nodo siguiente");
                name = Console.ReadLine();
                var weight = 0;
                try
                {
                    Console.WriteLine("Inserte peso de este, inserte números");
                    weight = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ingreso caracteres no válidos. El peso queda seteado en 0");
                }
                var nodeToAdd = new ClsNode(string.IsNullOrEmpty(name) ? "Nombre no informado" : name);
                var lastNode = nodeList.Last();
                lastNode.SetNext(nodeToAdd, weight);
                nodeList.Add(nodeToAdd);

                Console.WriteLine("Quiere ingresar otro nodo? S/N");
                continueCondition = Console.ReadKey();
                if (continueCondition.Key == ConsoleKey.N)
                    insertNode = false;
            }
            Console.Clear();
            Console.WriteLine("Lista de nodos enlazados");
            foreach (var currentNode in nodeList)
            {
                Console.WriteLine(currentNode.Name);
                Console.WriteLine($"\t-> PrevNode: {currentNode.GetPrev()?.Name ?? "no tiene"}");
                Console.WriteLine($"\t-> NextNode: {currentNode.GetNext()?.Name ?? "no tiene"}");
                Console.WriteLine($"\t-> Weight to NextNode: {currentNode.Weight}");
            }
            Console.WriteLine("Desea Eliminar alguno de los nodos? S/N");
            continueCondition = Console.ReadKey();
            if (continueCondition.Key == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine("Lista de nodos");
                var idx = 1;
                foreach (var currentNode in nodeList)
                {
                    Console.WriteLine($"\t Posición: {idx++}, nodo=>{currentNode.Name}");
                }

                var position = 0;
                try
                {
                    Console.WriteLine("Inserte la posición del nodo a borrar:");
                    position = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ingreso caracteres no válidos. La posición queda seteado en 0");
                }
                if (position == 0)
                {
                    Console.WriteLine("Posición inválida");
                }
                else
                {
                    var nodeToDelete = nodeList[position - 1];
                    var currentNode = firstNode.SearchNode(nodeToDelete.Name);
                    var distance = currentNode.Weight + (currentNode.GetPrev()?.Weight ?? 0);
                    Console.WriteLine($"Mantenes la misma Distancia de {distance}? S/N");
                    continueCondition = Console.ReadKey();
                    if (continueCondition.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("Inserte la nueva distancia");
                        try
                        {
                            Console.WriteLine("Inserte peso de este, inserte números");
                            distance = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ingreso caracteres no válidos. El peso queda seteado en {distance}");
                        }

                    }
                    Console.WriteLine("Nodo Eliminado");
                    currentNode.GetPrev()?.SetNext(currentNode.GetNext(), distance);
                    nodeList.Remove(nodeToDelete);

                    Console.WriteLine("Nodo Eliminado");
                    Console.WriteLine(nodeToDelete.Name);
                }
                
                Console.WriteLine("Lista de nodos enlazados");
                foreach (var currentNode in nodeList)
                {
                    Console.WriteLine(currentNode.Name);
                    Console.WriteLine($"\t-> PrevNode: {currentNode.GetPrev()?.Name ?? "no tiene"}");
                    Console.WriteLine($"\t-> NextNode: {currentNode.GetNext()?.Name ?? "no tiene"}");
                    Console.WriteLine($"\t-> Weight to NextNode: {currentNode.Weight}");
                }
            }
            Console.ReadLine();

        }
    }
}
