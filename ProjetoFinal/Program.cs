using System;

namespace ProjetoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string userOption = getUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("Nome do Aluno: ");
                        var aluno = new Aluno();
                        aluno.Name = Console.ReadLine();

                        Console.WriteLine("Nota do Aluno: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Results = nota;
                        } 
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal.");
                        }
                        Aluno[indiceAluno] = alunos;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!a.Name.Equals(""))
                            {
                                Console.ReadLine($"ALUNO {a.Name}- NOTA {a.Results}");
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Name))
                            {
                                notaTotal = notaTotal + alunos[i].Results;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        { 
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                    userOption = getUserOption();
                }
            }
        }

        private static string getUserOption()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine("");
            Console.WriteLine("");

            string userOption = Console.ReadLine();

            Console.WriteLine("");
            return userOption;
        }
    }
}
