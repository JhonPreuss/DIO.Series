﻿// See https://aka.ms/new-console-template for more information
using DIO.Series;
    internal class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() !="X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso serviço.");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries.");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Series novaSerie = new Series(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescrição
            );
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.Write("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o a Descrição da Série");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da Série ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);

        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o Id da Série ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar séries");
            Console.WriteLine("4- Excluir séries");
            Console.WriteLine("5- Visualizar séries");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }