using DesafioGerenciamentoTarefas;

int opcaoMenu = 999;

List<Tarefa> tarefas = new List<Tarefa>();

while (opcaoMenu != 0)
{
    Console.WriteLine("#### Menu #####");
    Console.Write("1 - Adicionar uma nova tarefa" +
        "\n2 - Listar todas as tarefas" +
        "\n3 - Listar tarefas concluídas" +
        "\n4 - Marcar tarefa como concluída" +
        "\n0 - Sair" +
        "\n");

    opcaoMenu = Convert.ToInt32(Console.ReadLine());

    switch (opcaoMenu)
    {
        case 1:
            Console.WriteLine("Digite a decrição da tarefa");
            string description = Console.ReadLine();

            Tarefa tarefa = new Tarefa();
            tarefa.Description = description;
            tarefa.IsCompleted = false;
            tarefa.Id = tarefas.Count() + 1;

            tarefas.Add(tarefa);
            break;
        case 2:
            Console.WriteLine("TODAS AS TAREFAS");
            foreach (Tarefa tar in tarefas.OrderBy(t => t.Id))
            {
                Console.WriteLine("Tarefa (" + tar.Id + "): " + tar.Description +
                    " Completa: " + tar.IsCompleted);
            }
            break;
        case 3:
            Console.WriteLine("TAREFAS CONCLUÍDAS");
            foreach (Tarefa tarefaConcluida in tarefas.
                Where(t => t.IsCompleted).OrderBy(t => t.Id))
            {
                Console.WriteLine("Tarefa (" + tarefaConcluida.Id + "): " 
                    + tarefaConcluida.Description);
            }
            break;
        case 4:
            Console.WriteLine("MARCAR UMA TAREFA COMO CONCLUÍDA");
            Console.WriteLine("Digite o id da tarefa concluída");
            int id = Convert.ToInt32(Console.ReadLine());

            //Vou pesquisar a tarefa pelo ID
            Tarefa tarefaCopia = tarefas.Where(t => t.Id == id).FirstOrDefault();
            //Removo essa tarefa da lista para inserir novamente
            tarefas.Remove(tarefaCopia);
            //Altero o IsCompleted da tarefa que eu pesquisei
            tarefaCopia.IsCompleted = true;
            tarefas.Add(tarefaCopia);
            break;
    }
}
