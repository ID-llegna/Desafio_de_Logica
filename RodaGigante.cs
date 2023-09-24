using System;
using System.Collections.Generic;

class RodaGigante
{
    // O desafio é fazer uma roda gigante usando Fila(Queue) e laço de repetição.
    // Você tera 2 filas, sendo uma de prioridade e uma normal.
    // A cada 2 pessoa da fila de prioridade que entrar, deverar ser liberada 3 pessoas da fila normal.
    // A roda gignate tem um limite de peso de 750, você não deve utrapassar esse limite.
    // As pessoas podem ser representada apenas pelo seu peso, utilize pesos diferente para as pessoas.
    static void Main()
    {
        RodaGigante a = new RodaGigante();
        a.Fila();
    }

    Queue<int> pessoas = new Queue<int>();
    Queue<int> pessoasPrioridade = new Queue<int>();


    int pesoRodaGigante = 750;
    //----------------------------------------------------------------------------------------------------
    void Fila()
    {
        Console.WriteLine("\nRotina da Fila");
        Random random = new Random();
        while (pessoas.Count < 5)
        {
            pessoas.Enqueue(random.Next(45, 85));
            Console.WriteLine("Uma pessoa entrou na fila normal");
            if (pessoas.Count % 2 == 0)
            {
                pessoasPrioridade.Enqueue(random.Next(45, 85));
                Console.WriteLine("Uma pessoa entrou na fila de prioridade.");
            }

        }
        RodaGiganteF();
    }
    //----------------------------------------------------------------------------------------------------
    Queue<int> rodaGigante = new Queue<int>();

    void RodaGiganteF()
    {
        Console.WriteLine("\nRotina da Roda Gigante");
        bool fim = false;

        for (int qnt = 2; qnt > 0; --qnt)
        {
            if (pessoasPrioridade.Count > 0 && pesoRodaGigante > pessoasPrioridade.Peek())
            {
                Console.WriteLine($"Pessoa da fila de prioridade, com peso {pessoasPrioridade.Peek()}");
                pesoRodaGigante -= pessoasPrioridade.Peek();
                rodaGigante.Enqueue(pessoasPrioridade.Dequeue());
            }
            else
                break;
        }

        for (int i = 3; i > 0; --i)
        {
            if (pessoas.Count > 0 && pesoRodaGigante > pessoas.Peek())
            {
                Console.WriteLine($"Pessoa da fila normal, com peso {pessoas.Peek()}");
                pesoRodaGigante -= pessoas.Peek();
                rodaGigante.Enqueue(pessoas.Dequeue());
            }
            else
                fim = true;
        }

        if (fim)
        {
            int peso = 0;
            foreach (var a in rodaGigante)
            {
                peso += a;
            }

            Console.WriteLine($"\nPeso restante é {pesoRodaGigante}");
            Console.WriteLine($"Peso na Roda Gigante é {peso}");
        }
        else
        {
            Fila();
        }

    }
}
