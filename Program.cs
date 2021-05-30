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
                        inserirSerie();
                        break;

                    case "3":
                        atualizarSerie();
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

        public static void visualizarSerie(){
            Console.WriteLine("Visualizar uma série");

            Console.WriteLine("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(entradaId);

            Console.WriteLine(serie);
        }

        public static void excluirSerie(){
            Console.WriteLine("Excluir série");

            Console.WriteLine("Digite o ID da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.exclui(entradaId);
        }
        private static void atualizarSerie()
        {
            Console.WriteLine("Alterar série");

            Console.WriteLine("Digite o índice da série:");
            int entradaId = int.Parse(Console.ReadLine());
            //Exibe as opções de gênero dinamicamente
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie(entradaId, (Genero) entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.atualiza(entradaId, serie);
        }

        private static void inserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            //Exibe as opções de gênero dinamicamente
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.proximoId(), (Genero) entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.insere(novaSerie);
        }

        private static void listarSeries()
        {
            Console.WriteLine("Listando séries");

            var lista = repositorio.lista();

            if (lista.Count == 0){
                Console.WriteLine("Nenhuma série encontrada!");
                return;
            }

            foreach(var serie in lista){
                Console.WriteLine($"\n\n#ID {serie.id} - Título: {serie.retornaTitulo()} {(serie.retornaExlcuido() ? "*Excluído*" : "")}");
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
