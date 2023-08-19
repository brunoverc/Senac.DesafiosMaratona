using DesafioCadastroAlunos;

int opcaoMenu = 999;
List<Estudante> estudantes =  new List<Estudante>();
while(opcaoMenu != 0)
{
    Console.WriteLine("#### Menu ####");
    Console.WriteLine("1 - Adiciona um novo aluno." +
        "\n2 - Listar todos os alunos." +
        "\n3 - Buscar aluno por nome." +
        "\n4 - Calular média das notas." +
        "\n0 - Sair" +
        "\n");

    opcaoMenu = Convert.ToInt32(Console.ReadLine());

    switch(opcaoMenu)
    {
        case 1:
            Console.WriteLine("Digite o nome do estudante");
            string nomeEstudante = Console.ReadLine();
            Estudante estudanteCadastro = new Estudante();
            estudanteCadastro.Nome = nomeEstudante;
            estudanteCadastro.Notas = new List<decimal>();
            estudanteCadastro.Id = estudantes.Count() + 1;

            decimal nota = 0;
            while(nota != -1)
            {
                Console.WriteLine("Digite a nota ou -1 para sair");
                nota = Convert.ToDecimal(Console.ReadLine());
                if(nota != -1)
                {
                    estudanteCadastro.Notas.Add(nota);
                }
            }

            estudantes.Add(estudanteCadastro);
            break;
        case 2:
            foreach(Estudante estudante in estudantes)
            {
                Console.WriteLine(estudante.Id + " - " + estudante.Nome);
            }
            break;
        case 3:
            Console.WriteLine("Digite o nome que deseja procurar:");
            string nome = Console.ReadLine();

            var estudanteConsulta = estudantes.Where(e => e.Nome == nome);
            //Verificar se existe um estudante retornado
            if(estudanteConsulta.Any())
            {
                Console.WriteLine(estudanteConsulta.First().Id + " - " +
                    estudanteConsulta.First().Nome);
            }
            break;
        case 4:
            Console.WriteLine("Digite o ID do aluno para calculo da média:");
            int id = Convert.ToInt32(Console.ReadLine());
            Estudante estudanteMedia = estudantes.Where(e => e.Id == id)
                .First();

            //Average retorna a média de todas as notas cadastradas.
            decimal media = estudanteMedia.Notas.Average();
            Console.WriteLine("A média do aluno foi: " + media);
            break;
    }
}