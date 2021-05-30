using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = menu();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        listarSeries();
                        break;

                    case "2":
                        inserirAlterarSerie(1);
                        break;

                    case "3":
                        inserirAlterarSerie(2);
                        break;

                    case "4":
                        excluirSerie();
                        break;

                    case "5":
                        visualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Opção inválida, tente novamente");
                        break;
                }
                opcao = menu();
            }

            Console.WriteLine("Obrigado por usar nossos serviços!");
        }

        public static void visualizarSerie()
        {
            Console.WriteLine("Visualizar uma série");

            Console.WriteLine("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(entradaId);

            if (serie.retornaTitulo() == "" || serie == null)
            {
                Console.WriteLine("Série não encontrada!");
                return;
            }

            Console.WriteLine(serie);
        }

        public static void excluirSerie()
        {
            Console.WriteLine("Excluir série");

            Console.WriteLine("Digite o ID da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            if(repositorio.exclui(entradaId)){
                Console.WriteLine("Série excluída com sucess!");
            } else{
                Console.WriteLine("Série não encontrada!");
            }
        }

        private static void inserirAlterarSerie(int tipo) //1: inserir e 2: alterar
        {
            int entradaId = 0;
            if (tipo == 1)
                Console.WriteLine("Inserir nova série");

            if (tipo == 2)
            {
                Console.WriteLine("Alterar série");

                Console.WriteLine("Digite o índice da série:");
                entradaId = int.Parse(Console.ReadLine());
            }


            //Exibe as opções de gênero dinamicamente
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            if(entradaGenero<1 || entradaGenero>13){
                Console.WriteLine("Selecione um gênero válido!");

                return;
            }

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            if(String.Compare(entradaTitulo, "") == 0){
                Console.WriteLine("Insira um título!");
                return;
            }

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            if(entradaAno < 1500 || entradaAno > int.Parse(DateTime.Now.Year.ToString())){
                Console.WriteLine("Digite um ano válido!");

                return;
            }

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            if (tipo == 1)
                try
                {
                     Serie serie = new Serie(id: repositorio.proximoId(), (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
                    repositorio.insere(serie);
                    Console.WriteLine("Série cadastrada com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível cadastrar!");
                    Console.WriteLine("Erro: " + e);
                }
            else
            {
                try
                {
                     Serie serie = new Serie(id: entradaId, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);
                    repositorio.atualiza(entradaId, serie);
                    Console.WriteLine("Série alterada com sucesso!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Não foi possível alterar!");
                    Console.WriteLine("Erro: " + e);
                }
            }
        }

        private static void listarSeries()
        {
            Console.WriteLine("Listando séries");

            var lista = repositorio.lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada!");
                return;
            }

            foreach (var serie in lista)
            {
                if (serie.retornaTitulo() != "")
                {
                    Console.WriteLine($"\n\n#ID {serie.id} - Título: {serie.retornaTitulo()}");
                }

            }
        }

        public static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("|--------------------------------------|");
            Console.WriteLine("|            Bem-Vindo!                |");
            Console.WriteLine("|  Informe a opção desejada:           |");
            Console.WriteLine("|--------------------------------------|");
            Console.WriteLine();

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcao;
        }
    }
}
