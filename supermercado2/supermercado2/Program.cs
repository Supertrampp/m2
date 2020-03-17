using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // BIBLIOTECA PARA CRIAÇÃO DE ARQUIVOS

namespace supermercado2
{
    class Program
    {
        // VALIDA ENTRADA
        static void Valida(ref int o, int max)
        {
            while ((o > max) || (o < 1))
            {
                Console.Write("\t\tValor inválido. Digite novamente => ");
                bool valida = int.TryParse(Console.ReadLine(), out o);
                while (!valida)
                {
                    Console.Write("\t\tValor não numerico. Digite novamente => ");
                    valida = int.TryParse(Console.ReadLine(), out o);
                }
            }
        }
        // FIM DO VALIDA

        // VALIDA MAXIMO E MINIMO CARACTER PARA DESCRIÇÃO DE PRODUTOS
        static void MaximoCaracter(ref string n, int max, int min)
        {
            while ((n.Length > max) || (n.Length < min))
            {
                Console.Write("\n Favor digitar conforme mencionado => ");
                n = Console.ReadLine().ToUpper(); // GRAVA TODOAS AS LETRAS EM MAIUSCULAS
            }
        }
        // FIM DO PROCEDIMENTO

        // VALIDA NUMERO DE TELEFONE
        static void MaximoCaracterTel(ref string n, int max, int min)
        {
            while ((n.Length > max) || (n.Length < min))
            {
                Console.Write("\n Favor digitar conforme mencionado => ");
                n = Console.ReadLine();
            }
        }
        // FIM DO PROCEDIMENTO

        // VALIDA LETRA UNICA SAIDA É 'S' OU 'N'
        static void ValidaLetra(ref string o)
        {
            while ((o != "n") && (o != "s"))
            {
                Console.Write("\n Opção inválida escolha entre s/n => ");
                o = Console.ReadLine().ToLower(); // LETRAS EM MINUSCULAS
            }
        }
        // fim do procedimento

        // VALIDAÇÃO PARA VARIAVEL INTEIRO
        static void ValidaLetra(out int escolha)
        {
            bool valida = int.TryParse(Console.ReadLine(), out escolha);
            while (!valida)
            {
                Console.Write("\n Valor não numérico. Digite novamente => ");
                valida = int.TryParse(Console.ReadLine(), out escolha);
            }
        }

        // VALIDAÇÃO PARA VARIAVEL DOUBLE
        static void ValidaLetraDouble(out double n)
        {
            bool valida = double.TryParse(Console.ReadLine(), out n);
            while (!valida)
            {
                Console.Write("\n Valor não numérico. Digite novamente => ");
                valida = double.TryParse(Console.ReadLine(), out n);
            }
        }

        // VALIDAÇÃO PARA ENTRADA DE OPCAO APENAS NUMEROS
        static void ValidaEntrada(ref int escolha, int max)
        {
            while ((escolha > max) || (escolha < 1))
            {
                Console.Write("\n Escolha entre as opçoes acima => ");
                bool valida = int.TryParse(Console.ReadLine(), out escolha);
                while (!valida)
                {
                    Console.Write("\n Valor não numerico. Escolha entre as opções acima => ");
                    valida = int.TryParse(Console.ReadLine(), out escolha);
                }
            }
        }

        // PROCEDIMENTO PARA LISTAR TODOS PRODUTOS AREA DE ADM E CLINTES
        // ABRE OS ARQUIVOS PARA LEITURA
        static void Listar(string limpeza, string alimentacao, string higiene)
        {
            Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
            FileStream lista = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);
            {
                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');
                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);
                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad.Close();
            lista.Close();

            FileStream lista2 = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
            StreamReader cad2 = new StreamReader(lista2);
            {
                while (cad2.Peek() != -1)
                {
                    string linha = cad2.ReadLine();
                    string[] pos = linha.Split(';');
                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);
                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad2.Close();
            lista2.Close();

            FileStream lista3 = new FileStream(higiene, FileMode.Open, FileAccess.Read);
            StreamReader cad3 = new StreamReader(lista3);
            {
                while (cad3.Peek() != -1)
                {
                    string linha = cad3.ReadLine();
                    string[] pos = linha.Split(';');
                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);
                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad3.Close();
            lista3.Close();

            Console.Write("\n\n ------------------------------------------------------------------------------ \n");
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }
        // FIM DO PROCEDIMENTO LEITURA

        // ABRE OS ARQUIVOS E MOSTRA O PRODUTO ESCOLHIDO PELO USUARIO
        static void Consultar(string limpeza, string higiene, string alimentacao)
        {
            string op;
            int pesq;
            int codigo = 0;
            string nome = "nome";
            double preco = 0;
            int qtd = 0;
            do
            {
                FileStream rel = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
                StreamReader cad = new StreamReader(rel);

                FileStream rel2 = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
                StreamReader cad2 = new StreamReader(rel2);

                FileStream rel3 = new FileStream(higiene, FileMode.Open, FileAccess.Read);
                StreamReader cad3 = new StreamReader(rel3);

                Console.Write("\n Digite o código do produto para consultar => ");
                ValidaLetra(out pesq);

                int x = 0;

                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');
                    codigo = int.Parse(pos[0]);
                    nome = pos[1];
                    preco = double.Parse(pos[2]);
                    qtd = int.Parse(pos[3]);

                    if (pesq == codigo)
                    {
                        Console.WriteLine("\n Código: {0}\t Descrição: {1} \t Preço R$ {2:F2} \tEstoque: {3}", codigo, nome, preco, qtd);
                        Console.Write("\n\n ------------------------------------------------------------------------------ \n");
                        x = 1;
                    }
                }
                while (cad2.Peek() != -1)
                {
                    string linha = cad2.ReadLine();
                    string[] pos = linha.Split(';');
                    codigo = int.Parse(pos[0]);
                    nome = pos[1];
                    preco = double.Parse(pos[2]);
                    qtd = int.Parse(pos[3]);

                    if (pesq == codigo)
                    {
                        Console.WriteLine("\n Código: {0}\t Descrição: {1} \t Preço R$ {2:F2} \tEstoque: {3}", codigo, nome, preco, qtd);
                        Console.Write("\n\n ------------------------------------------------------------------------------ \n");
                        x = 1;
                    }
                }
                while (cad3.Peek() != -1)
                {
                    string linha = cad3.ReadLine();
                    string[] pos = linha.Split(';');
                    codigo = int.Parse(pos[0]);
                    nome = pos[1];
                    preco = double.Parse(pos[2]);
                    qtd = int.Parse(pos[3]);

                    if (pesq == codigo)
                    {
                        Console.WriteLine("\n Código: {0}\t Descrição: {1} \t Preço R$ {2:F2} \tEstoque: {3}", codigo, nome, preco, qtd);
                        Console.Write("\n\n ------------------------------------------------------------------------------ \n");
                        x = 1;
                    }
                }
                // mensagem de erro
                if (x == 0)
                {
                    Console.Write("\n Produto não cadastrado\n");
                }
                cad3.Close();
                rel3.Close();

                cad2.Close();
                rel2.Close();

                cad.Close();
                rel.Close();

                Console.Write("\n Deseja continuar? s/n => ");
                op = Console.ReadLine().ToLower();

                ValidaLetra(ref op);

            } while (op != "n");
            Console.Write("\n Tecle ENTER para voltar...");
        }
        // fim do procedimento listar por produto

        // CALCULA E MOSTRA O TOTAL EM VALOR R$ DE CADA PRODUTO
        static void ListarEstoque(string alimentacao, string higiene, string limpeza)
        {
            Console.WriteLine(" Código  Descrição \t\t Total\n");
            FileStream lista = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);

            while (cad.Peek() != -1)
            {
                string linha = cad.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                double total = qtd * preco; // CALCULO PARA SABER O TOTAL DO PRODUTO
                Console.Write("\n {0}\t {1}\t\t {2:F2}", codigo, nome, total);
            }
            cad.Close();
            lista.Close();

            FileStream lista2 = new FileStream(higiene, FileMode.Open, FileAccess.Read);
            StreamReader cad2 = new StreamReader(lista2);

            while (cad2.Peek() != -1)
            {
                string linha = cad2.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                double total = qtd * preco; // CALCULO PARA SABER O TOTAL DO PRODUTO
                Console.Write("\n {0}\t {1}\t\t {2:F2}", codigo, nome, total);
            }

            cad2.Close();
            lista2.Close();

            FileStream lista3 = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
            StreamReader cad3 = new StreamReader(lista3);

            while (cad3.Peek() != -1)
            {
                string linha = cad3.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                double total = qtd * preco; // CALCULO PARA SABER O TOTAL DO PRODUTO
                Console.Write("\n {0}\t {1}\t\t {2:F2}", codigo, nome, total);
            }

            cad3.Close();
            lista3.Close();
            Console.Write("\n\n ------------------------------------------------------------------------------ \n");
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }
        // fim do procedimento

        // PROCEDIMENTO PARA MOSTRAR TOTAL EM VALOR E QUANTIDADE TOTAL DO MERCADO
        static void EstoqueTotal(string alimentacao, string higiene, string limpeza)
        {
            FileStream lista = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);

            double totalQ = 0;
            double totalP = 0;

            while (cad.Peek() != -1)
            {
                string linha = cad.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                totalP = preco * qtd + totalP; // CALCULO PARA SABER O TOTAL EM VALOR
                totalQ = totalQ + qtd;// CALCULO PARA SABER O TOTAL EM QUANTIDADE
            }
            cad.Close();
            lista.Close();

            FileStream lista2 = new FileStream(higiene, FileMode.Open, FileAccess.Read);
            StreamReader cad2 = new StreamReader(lista2);

            while (cad2.Peek() != -1)
            {
                string linha = cad2.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                totalP = preco * qtd + totalP;
                totalQ = totalQ + qtd;
            }
            cad2.Close();
            lista2.Close();

            FileStream lista3 = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
            StreamReader cad3 = new StreamReader(lista3);

            while (cad3.Peek() != -1)
            {
                string linha = cad3.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                totalP = preco * qtd + totalP;
                totalQ = totalQ + qtd;
            }

            cad3.Close();
            lista3.Close();

            Console.Write("\n Total em estoque {0} \n\n Total em valor R$: {1:F2} \n", totalQ, totalP);
            Console.Write("\n\n ------------------------------------------------------------------------------ \n");
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }
        // FIM DO PROCIMENTO TOTAL DO MERCADO

        // PROCEDIMENTO PARA CADASTRO DE CLIENTE
        static void CadastroCliente(string clientes)
        {
            string senha;

            ValidaSenha(clientes, out senha);

            FileStream cadastro = new FileStream(clientes, FileMode.Append, FileAccess.Write);
            StreamWriter cad = new StreamWriter(cadastro);

            Console.Write("\n Digite seu nome em no máximo 20 caracter e mínimo 8 => ");
            string nome = Console.ReadLine();

            MaximoCaracterTel(ref nome, 20, 8);

            Console.Write("\n Digite seu telefone (9 digitos) => ");
            string tel = Console.ReadLine();
            MaximoCaracterTel(ref tel, 9, 9);

            cad.WriteLine(senha + ";" + nome + ";" + tel); // grava no arquivo cadastro.txt nome, preço e quantidade 

            Console.Write("\n Parabéns!!! Você já esta cadastrado em nosso sistema.");
            Console.Write("\n Tecle ENTER para continuar e escolha a opção 2 para logar.");
            Console.ReadKey();

            cad.Close();
            cadastro.Close();
        }

        // PROCEDIMENTO PARA VALIDAR SENHA
        static void ValidaSenha(string clientes, out string senha)
        {
            string op = "s";
            do
            {
                string s;
                int x = 0;
                Console.Clear();
                Console.Write("\n\t\t>>> CADASTRO DE CLIENTES <<<\n\n");

                FileStream rel7 = new FileStream(clientes, FileMode.Open, FileAccess.Read);
                StreamReader cad7 = new StreamReader(rel7);

                Console.Write("\n Cadastre aqui sua senha.\n\n - Máximo 8 e mínimo 2 caracter;\n - Aceita números e letras.\n - Maiúsculas ou minúscalas.\n - Espaço conta como caracter.\n\n Digite aqui => ");

                // BLOCO DE CODIGO PARA ESCONDER A SENHA DO USUARIO
                senha = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        senha += key.KeyChar;
                        Console.Write("*"); // IMPRIMI "*" E NÃO LETRA
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
                        {
                            senha = senha.Substring(0, (senha.Length - 1));
                            Console.Write("\b \b");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                        }
                    }

                } while (true);
                // FIM DO BLOCO DE CODIGO PARA ESCONDER SENHA

                ConfSenha(ref senha, 8, 2); // VALIDA MAXIMO DE CARACTER DE SENHA

                while (cad7.Peek() != -1)
                {
                    string linha = cad7.ReadLine();
                    string[] pos = linha.Split(';');
                    s = pos[0];
                    // SE A SENHA JA ESTIVER CADASTRADA APARECE MENSAGEM PARA O USUARIO
                    if (senha == s)
                    {
                        Console.Write("\n\n Esta senha já esta cadastrada em nosso sistema\n");
                        Console.Write("\n Tecle ENTER para voltar...");
                        Console.ReadKey();
                        x = 1;
                    }
                }
                // MENSAGEM DE SENHA CADASTRADA
                if (x == 0)
                {
                    Console.Write("\n\n Senha cadastrada com sucesso!!!.\n");
                    Console.Write("\n Tecle ENTER para continuar...");
                    op = Console.ReadLine();
                }
                cad7.Close();
                rel7.Close();

            } while (op == "s");
        }
        // FIM DO PROCEDIMENTO PRA CADASTRAR SENHA

        // CASO A SENHA TENHA MAIS 8 OU MENOS DE 2 CARACTER
        static void ConfSenha(ref string senha, int max, int min)
        {
            while (senha.Length > max || senha.Length < 2)
            {
                Console.Write("\n\n Digite entre 8 e 2 caracter => ");
                senha = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        senha += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && senha.Length > 0)
                        {
                            senha = senha.Substring(0, (senha.Length - 1));
                            Console.Write("\b \b");
                        }
                        else
                        {
                            if (key.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                        }
                    }

                } while (true);
            }
        }
        // FIM DO PROCEDIMENTO

        // PROCEDIMENTO PARA LISTAR TODOS OS CLIENTES
        static void ListarClientes(string clientes)
        {
            FileStream lista = new FileStream(clientes, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);
            {
                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');
                    string senha = pos[0];
                    string nome = pos[1];
                    string tel = pos[2];
                    Console.Write(" Nome: {0}\n", nome);
                    Console.Write(" Telefone: {0}\n", tel);
                    Console.Write("\n-----------------------------------\n");
                }
            }
            cad.Close();
            lista.Close();
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }
       
        // PROCEDIMENTO PARA ALTERAR PRODUTOS ALIMENTACAO
        static void AlterarAlimentacao(string alimentacao, string higiene, string limpeza)
        {
            Console.Clear();
            int op, pesq;
            int x = 0;
            Console.Write("\n\t\t>>> ALTERAÇÃO PRODUTOS DE ALIMENTAÇÃO <<<\n\n");
            FileStream rel = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
            StreamReader ag = new StreamReader(rel);

            string bak = @"C:\supermercado2\agenda.bak"; // CRIA UM NOVO ARQUIVO PARA GRAVAR ALTERAÇÕES

            FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
            StreamWriter ag1 = new StreamWriter(relacao);

            Console.Write(" Digite o código do produto que deseja alterar => ");
            ValidaLetra(out pesq);

            while (ag.Peek() != -1)
            {
                string linha = ag.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);
                if (codigo == pesq)
                {
                    x = 1;
                    Console.Write("\n Dados atuais do produto \n");
                    Console.Write("\n Código: " + codigo + "\tdescrição: " + nome + "\tPreço: " + preco + "\tEstoque: " + qtd + "\n");
                    Console.Write("\n Escolha o que deseja alterar neste produto \n");
                    Console.Write("\n 1 - Código;\n 2 - Descrição;\n 3 - Preço\n 4 - Estoque.\n");
                    Console.Write("\n Sua opção aqui => ");
                    ValidaLetra(out op);
                    ValidaEntrada(ref op, 4);

                    // ALTERA CODIGO
                    if (op == 1)
                    {

                        ValidaCodigo(alimentacao, higiene, limpeza, out codigo);
                        Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        // ALTERA DESCRIÇÃO
                        if (op == 2)
                        {
                            Console.Write("\n Digite o novo nome => ");
                            nome = Console.ReadLine().ToUpper();
                            MaximoCaracter(ref nome, 14, 8);
                            Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (op == 3)
                            {
                                // ALTERA PREÇO
                                Console.Write("\n Digite o novo preço => ");
                                ValidaLetraDouble(out preco);
                                Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                                Console.ReadKey();
                            }
                            else
                            {
                                // ALTERA ESTOQUE
                                Console.Write("\n Digite a nova quantidade = > ");
                                ValidaLetra(out qtd);
                                Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                                Console.ReadKey();
                            }
                        }
                    }

                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
                else
                {
                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            ag1.Close();
            relacao.Close();

            ag.Close();
            rel.Close();

            File.Delete(@"C:\supermercado2\alimentacao.txt");
            File.Move(@"C:\supermercado2\agenda.bak", @"C:\supermercado2\alimentacao.txt");

            if (x == 0)
            {
                Console.Write("\n Este produto nao esta cadastrado. \n");
                Console.Write("\n Tecle Enter para voltar. \n");
                Console.ReadKey();
            }
        }
        // FIM DO PROCEDIMENTO ALIMENTACAO

        // PROCEDIMENTO PARA ALTERAR HIGIENE
        static void AlterarHigiene(string alimentacao, string higiene, string limpeza)
        {
            Console.Clear();
            int op, pesq;
            int x = 0;
            Console.Write("\n\t\t>>> ALTERAÇÃO PRODUTOS DE HIGIENE <<<\n\n");
            FileStream rel = new FileStream(higiene, FileMode.Open, FileAccess.Read);
            StreamReader ag = new StreamReader(rel);

            string bak = @"C:\supermercado2\agenda.bak";

            FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
            StreamWriter ag1 = new StreamWriter(relacao);

            Console.Write(" Digite o código do produto que deseja alterar => ");
            ValidaLetra(out pesq);

            while (ag.Peek() != -1)
            {
                string linha = ag.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);

                if (codigo == pesq)
                {
                    x = 1;
                    Console.Write("\n Dados atuais do produto \n");
                    Console.Write("\n Código: " + codigo + "\tdescrição: " + nome + "\tPreço: " + preco + "\tEstoque: " + qtd + "\n");
                    Console.Write("\n Escolha o que deseja alterar neste produto \n");
                    Console.Write("\n 1 - Código;\n 2 - Descrição;\n 3 - Preço\n 4 - Estoque.\n");
                    Console.Write("\n Sua opção aqui => ");
                    ValidaLetra(out op);
                    ValidaEntrada(ref op, 4);

                    if (op == 1)
                    {

                        ValidaCodigo(alimentacao, higiene, limpeza, out codigo);
                        Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (op == 2)
                        {
                            Console.Write("\n Digite o novo nome => ");
                            nome = Console.ReadLine().ToUpper();
                            MaximoCaracter(ref nome, 14, 8);
                            Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (op == 3)
                            {
                                Console.Write("\n Digite o novo preço => ");
                                ValidaLetraDouble(out preco);
                                Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("\n Digite a nova quantidade = > ");
                                ValidaLetra(out qtd);
                                Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                                Console.ReadKey();
                            }
                        }
                    }

                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
                else
                {
                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            ag1.Close();
            relacao.Close();

            ag.Close();
            rel.Close();

            File.Delete(@"C:\supermercado2\higiene.txt");
            File.Move(@"C:\supermercado2\agenda.bak", @"C:\supermercado2\higiene.txt");

            if (x == 0)
            {
                Console.Write("\n Este produto nao esta cadastrado. \n");
                Console.Write("\n Tecle Enter para voltar. \n");
                Console.ReadKey();
            }
        }
        // FIM DO PROCEDIMENTO ALTERAR HIGIENE

        // PROCEDIMENTO PARA ALTERAR LIMPEZA
        static void AlterarLimpeza(string alimentacao, string higiene, string limpeza)
        {
            Console.Clear();
            int op, pesq;
            int x = 0;
            Console.Write("\n\t\t>>> ALTERAÇÃO PRODUTOS DE LIMPEZA <<<\n\n");
            FileStream rel = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
            StreamReader ag = new StreamReader(rel);

            string bak = @"C:\supermercado2\agenda.bak";

            FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
            StreamWriter ag1 = new StreamWriter(relacao);

            Console.Write(" Digite o código do produto que deseja alterar => ");
            ValidaLetra(out pesq);

            while (ag.Peek() != -1)
            {
                string linha = ag.ReadLine();
                string[] pos = linha.Split(';');
                int codigo = int.Parse(pos[0]);
                string nome = pos[1];
                double preco = double.Parse(pos[2]);
                int qtd = int.Parse(pos[3]);

                if (codigo == pesq)
                {
                    x = 1;
                    Console.Write("\n Dados atuais do produto \n");
                    Console.Write("\n Código: " + codigo + "\tdescrição: " + nome + "\tPreço: " + preco + "\tEstoque: " + qtd + "\n");
                    Console.Write("\n Escolha o que deseja alterar neste produto \n");
                    Console.Write("\n 1 - Código;\n 2 - Descrição;\n 3 - Preço\n 4 - Estoque.\n");
                    Console.Write("\n Sua opção aqui => ");
                    ValidaLetra(out op);
                    ValidaEntrada(ref op, 4);

                    if (op == 1)
                    {

                        ValidaCodigo(alimentacao, higiene, limpeza, out codigo);
                        Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (op == 2)
                        {
                            Console.Write("\n Digite o novo nome => ");
                            nome = Console.ReadLine().ToUpper();
                            MaximoCaracter(ref nome, 14, 8);
                            Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            if (op == 3)
                            {
                                Console.Write("\n Digite o novo preço => ");
                                ValidaLetraDouble(out preco);
                                Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("\n Digite a nova quantidade = > ");
                                ValidaLetra(out qtd);
                                Console.Write("\n Alteração realizada com sucesso!\n Tecle Enter para voltar...");
                                Console.ReadKey();
                            }
                        }
                    }

                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
                else
                {
                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            ag1.Close();
            relacao.Close();

            ag.Close();
            rel.Close();

            File.Delete(@"C:\supermercado2\limpeza.txt");
            File.Move(@"C:\supermercado2\agenda.bak", @"C:\supermercado2\limpeza.txt");

            if (x == 0)
            {
                Console.Write("\n Este produto nao esta cadastrado. \n");
                Console.Write("\n Tecle Enter para voltar. \n");
                Console.ReadKey();
            }
        }
        // FIM DO PROCEDIMENTO ALTERAR LIMPEZA

        // PROCEDIMENTO DE COMPRAR PRODUTOS ALIMENTACAO
        static void ComprarAlimentacao(string alimentacao, string contacliente, string loga, ref double carrinho, string dia, string mes, string ano)
        {
            int cod, quant, qtd = 0;
            int x = 0;
            string n = "n";
            int codigo = 0;
            double preco = 0;
            string nome = "nome";
            do
            {
                Console.Clear();
                Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                Console.Write("\n\t\t>>> PRODUTOS ALIMENTAÇÃO <<<\n\n\n");
                Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
                FileStream lista = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
                StreamReader cad = new StreamReader(lista);
                {
                    while (cad.Peek() != -1)
                    {
                        string linha = cad.ReadLine();
                        string[] pos = linha.Split(';');
                        codigo = int.Parse(pos[0]);
                        nome = pos[1];
                        preco = double.Parse(pos[2]);
                        qtd = int.Parse(pos[3]);
                        Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                    }
                }
                cad.Close();
                lista.Close();

                FileStream rel = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
                StreamReader ag = new StreamReader(rel);

                string bak = @"C:\supermercado2\agenda.bak";
                FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
                StreamWriter ag1 = new StreamWriter(relacao);

                FileStream cadastro = new FileStream(contacliente, FileMode.Append, FileAccess.Write);
                StreamWriter cad2 = new StreamWriter(cadastro);

                // SOLICITA PARA O USUARIO ESCOLHER SEU PRODUTO
                Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
                Console.Write(" Digite o código do produto que deseja comprar => ");
                ValidaLetra(out cod);

                while (ag.Peek() != -1)
                {
                    string linha = ag.ReadLine();
                    string[] pos = linha.Split(';');

                    codigo = int.Parse(pos[0]);
                    nome = pos[1];
                    preco = double.Parse(pos[2]);
                    qtd = int.Parse(pos[3]);

                    if (codigo == cod)
                    {
                        x = 1;
                        Console.Write("\n Dados do seu produto \n");

                        Console.Write("\n Código: {0}\tDescrição: {1}\tR$: {2:F2}\tEstoque: {3}", codigo, nome, preco, qtd);

                        Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
                        Console.Write(" Deseja comprar este item ? s/n => ");
                        n = Console.ReadLine().ToLower();
                        ValidaLetra(ref n);

                        if (n == "s")
                        {
                            Console.Write("\n Digite a quantidade = > ");
                            ValidaLetra(out quant);

                            if (qtd < quant)
                            {
                                Console.Write("\n Estoque indisponível.\n");
                                Console.Write("\n Deseja continuar? s/n => ");
                                n = Console.ReadLine().ToLower();
                                ValidaLetra(ref n);
                            }
                            else
                            {
                                qtd = qtd - quant;
                                carrinho = quant * preco + carrinho;
                                cad2.WriteLine(codigo + ";" + nome + ";" + preco + ";" + quant);

                                Console.Write("\n Venda realizada!\n\n Deseja continuar? s/n => ");
                                n = Console.ReadLine().ToLower();
                                ValidaLetra(ref n);
                            }
                        }
                        ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                    }
                    else
                    {
                        ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                    }
                }

                cad2.Close();
                cadastro.Close();

                ag1.Close();
                relacao.Close();

                ag.Close();
                rel.Close();

                File.Delete(@"C:\supermercado2\alimentacao.txt");
                File.Move(@"C:\supermercado2\agenda.bak", @"C:\supermercado2\alimentacao.txt");

                if (x == 0)
                {
                    Console.Write("\n Este produto nao esta cadastrado.\n");
                    Console.Write("\n Deseja continuar? s/n => ");
                    n = Console.ReadLine().ToLower();
                    ValidaLetra(ref n);
                }
            } while (n != "n");
        }
        // FIM DO PROCEDIMENTO DE COMPRAR ALIMENTACAO

        // PROCEDIMENTO PARA COMPRAR HIGIENE
        static void ComprarHigiene(string higiene, string contacliente, string loga, ref double carrinho, string dia, string mes, string ano)
        {
            int cod, quant, qtd = 0;
            int x = 0;
            string n = "s";
            int codigo = 0;
            double preco = 0;
            string nome = "nome";

            do
            {
                Console.Clear();
                Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                Console.Write("\n\t\t>>> PRODUTOS HIGIENE <<<\n\n\n");
                Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
                FileStream lista = new FileStream(higiene, FileMode.Open, FileAccess.Read);
                StreamReader cad = new StreamReader(lista);
                {
                    while (cad.Peek() != -1)
                    {
                        string linha = cad.ReadLine();
                        string[] pos = linha.Split(';');

                        codigo = int.Parse(pos[0]);
                        nome = pos[1];
                        preco = double.Parse(pos[2]);
                        qtd = int.Parse(pos[3]);

                        Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                    }
                }
                cad.Close();
                lista.Close();

                FileStream rel = new FileStream(higiene, FileMode.Open, FileAccess.Read);
                StreamReader ag = new StreamReader(rel);

                string bak = @"C:\supermercado2\agenda.bak";
                FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
                StreamWriter ag1 = new StreamWriter(relacao);

                FileStream cadastro = new FileStream(contacliente, FileMode.Append, FileAccess.Write);
                StreamWriter cad2 = new StreamWriter(cadastro);

                Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
                Console.Write(" Digite o código do produto que deseja comprar => ");
                ValidaLetra(out cod);

                while (ag.Peek() != -1)
                {
                    string linha = ag.ReadLine();
                    string[] pos = linha.Split(';');

                    codigo = int.Parse(pos[0]);
                    nome = pos[1];
                    preco = double.Parse(pos[2]);
                    qtd = int.Parse(pos[3]);

                    if (codigo == cod)
                    {
                        x = 1;
                        Console.Write("\n Dados do seu produto \n");

                        Console.Write("\n Código: {0}\tDescrição: {1}\tR$: {2:F2}\tEstoque: {3}", codigo, nome, preco, qtd);

                        Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
                        Console.Write(" Deseja comprar este item ? s/n => ");
                        n = Console.ReadLine().ToLower();
                        ValidaLetra(ref n);

                        if (n == "s")
                        {
                            Console.Write("\n Digite a quantidade = > ");
                            ValidaLetra(out quant);

                            if (qtd < quant)
                            {
                                Console.Write("\n Estoque indisponível.\n");
                                Console.Write("\n Deseja continuar? s/n => ");
                                n = Console.ReadLine().ToLower();
                                ValidaLetra(ref n);
                            }
                            else
                            {
                                qtd = qtd - quant;
                                carrinho = quant * preco + carrinho;
                                cad2.WriteLine(codigo + ";" + nome + ";" + preco + ";" + quant);

                                Console.Write("\n Venda realizada!\n\n Deseja continuar? s/n => ");
                                n = Console.ReadLine().ToLower();
                                ValidaLetra(ref n);
                            }
                        }
                        ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                    }
                    else
                    {
                        ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                    }
                }

                cad2.Close();
                cadastro.Close();

                ag1.Close();
                relacao.Close();

                ag.Close();
                rel.Close();

                File.Delete(@"C:\supermercado2\higiene.txt");
                File.Move(@"C:\supermercado2\agenda.bak", @"C:\supermercado2\higiene.txt");

                if (x == 0)
                {
                    Console.Write("\n Este produto nao esta cadastrado.\n");
                    Console.Write("\n Deseja continuar? s/n => ");
                    n = Console.ReadLine().ToLower();
                    ValidaLetra(ref n);
                }
            } while (n != "n");
        }
        // FIM DO PROCEDIMENTO COMPRAR HIGIENE

        // PROCEDIMENTO DE COMPRAR LIMPEZA
        static void ComprarLimpeza(string limpeza, string contacliente, string loga, ref double carrinho, string dia, string mes, string ano)
        {
            int cod, quant, qtd = 0;
            int x = 0;
            string n = "s";
            int codigo = 0;
            double preco = 0;
            string nome = "nome";

            do
            {
                Console.Clear();
                Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                Console.Write("\n\t\t>>> PRODUTOS LIMPEZA <<<\n\n\n");
                Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
                FileStream lista = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
                StreamReader cad = new StreamReader(lista);
                {
                    while (cad.Peek() != -1)
                    {
                        string linha = cad.ReadLine();
                        string[] pos = linha.Split(';');

                        codigo = int.Parse(pos[0]);
                        nome = pos[1];
                        preco = double.Parse(pos[2]);
                        qtd = int.Parse(pos[3]);

                        Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                    }
                }
                cad.Close();
                lista.Close();

                FileStream rel = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
                StreamReader ag = new StreamReader(rel);

                string bak = @"C:\supermercado2\agenda.bak";
                FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
                StreamWriter ag1 = new StreamWriter(relacao);

                FileStream cadastro = new FileStream(contacliente, FileMode.Append, FileAccess.Write);
                StreamWriter cad2 = new StreamWriter(cadastro);

                Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
                Console.Write(" Digite o código do produto que deseja comprar => ");
                ValidaLetra(out cod);

                while (ag.Peek() != -1)
                {
                    string linha = ag.ReadLine();
                    string[] pos = linha.Split(';');

                    codigo = int.Parse(pos[0]);
                    nome = pos[1];
                    preco = double.Parse(pos[2]);
                    qtd = int.Parse(pos[3]);

                    if (codigo == cod)
                    {
                        x = 1;
                        Console.Write("\n Dados do seu produto \n");

                        Console.Write("\n Código: {0}\tDescrição: {1}\tR$: {2:F2}\tEstoque: {3}", codigo, nome, preco, qtd);

                        Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
                        Console.Write(" Deseja comprar este item ? s/n => ");
                        n = Console.ReadLine().ToLower();
                        ValidaLetra(ref n);

                        if (n == "s")
                        {
                            Console.Write("\n Digite a quantidade = > ");
                            ValidaLetra(out quant);

                            if (qtd < quant)
                            {
                                Console.Write("\n Estoque indisponível.\n");
                                Console.Write("\n Deseja continuar? s/n => ");
                                n = Console.ReadLine().ToLower();
                                ValidaLetra(ref n);
                            }
                            else
                            {
                                qtd = qtd - quant;
                                carrinho = quant * preco + carrinho;
                                cad2.WriteLine(codigo + ";" + nome + ";" + preco + ";" + quant);

                                Console.Write("\n Venda realizada!\n\n Deseja continuar? s/n => ");
                                n = Console.ReadLine().ToLower();
                                ValidaLetra(ref n);
                            }
                        }
                        ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                    }
                    else
                    {
                        ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                    }
                }

                cad2.Close();
                cadastro.Close();

                ag1.Close();
                relacao.Close();

                ag.Close();
                rel.Close();

                File.Delete(@"C:\supermercado2\limpeza.txt");
                File.Move(@"C:\supermercado2\agenda.bak", @"C:\supermercado2\limpeza.txt");

                if (x == 0)
                {
                    Console.Write("\n Este produto nao esta cadastrado.\n");
                    Console.Write("\n Deseja continuar? s/n => ");
                    n = Console.ReadLine().ToLower();
                    ValidaLetra(ref n);
                }
            } while (n != "n");
        }
        // FIM DO PROCEDIMENTO DE COMPRA LIMPEZA

        // MOSTRA TODA A COMPRA DO USUARIO E DA O DIREITO DE EXCLUIR DA LISTA
        static void MinhaCompra(string alimentacao, string higiene, string limpeza, string contacliente, string loga, ref double carrinho, string dia, string mes, string ano)
        {
            string op;
            Console.Clear();
            Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
            Console.Write("\n\t\t>>> TODOS OS SEUS PRODUTOS <<<\n\n\n");
            Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Quantidade");
            FileStream lista = new FileStream(contacliente, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);

            {
                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);

                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad.Close();
            lista.Close();

            Console.Write("\n\n -----------------------------------------------------------------------------\n\n");
            Console.Write(" Deseja excluir algum item da sua lista? s/n => ");
            op = Console.ReadLine().ToLower();
            ValidaLetra(ref op);

            // OPCAO SE O CLIENTE DESEJA EXCLUIR ALGUM ITEM DE SUA LISTA DE COMPRA
            if (op == "s")
            {
                Excluir(alimentacao, higiene, limpeza, contacliente, ref carrinho);
            }
        }
        // FIM DO PROCEDIMENTO LISTAR COMPRA

        /* PROCEDIMENTO PARA EXCLUIR ITEM DA LISTA DE COMPRA DO USUSARIO 
         AO EXCLUIR O ESTOQUE VOLTA PARA O MERCADO*/
        static void Excluir(string alimentacao, string higiene, string limpeza, string contacliente, ref double carrinho)
        {
            int pesq;
            int x = 0;
            int quant = 0;
            int codigo;
            string nome;
            double preco;
            int qtd;

            FileStream rel = new FileStream(contacliente, FileMode.Open, FileAccess.Read);
            StreamReader ag = new StreamReader(rel);

            string bak = @"C:\supermercado2\excluir.bak";

            FileStream relacao = new FileStream(bak, FileMode.Create, FileAccess.Write);
            StreamWriter ag1 = new StreamWriter(relacao);

            // USUARIO DIGITE O CODIGO QUE DESEJA EXCLUIR
            Console.Write("\n Digite o código do produto que deseja excluir => ");
            ValidaLetra(out pesq);

            // É FEITO A PESQUISA NA LISTA DE COMPRA
            while (ag.Peek() != -1)
            {
                string linha = ag.ReadLine();
                string[] pos = linha.Split(';');

                codigo = int.Parse(pos[0]);
                nome = pos[1];
                preco = double.Parse(pos[2]);
                qtd = int.Parse(pos[3]);

                if (codigo == pesq)
                {
                    double valor = preco * qtd;
                    carrinho = carrinho - valor;
                    quant = qtd;
                    x = 1;
                }

                if (codigo != pesq)
                {
                    ag1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            if (x == 0)
            {
                Console.Write("\n Produto não encontrado.\n");
            }
            else
            {
                Console.Write("\n Produto excluido.\n");
            }

            ag1.Close();
            relacao.Close();

            ag.Close();
            rel.Close();

            File.Delete(@"C:\supermercado2\conta.txt");
            File.Move(@"C:\supermercado2\excluir.bak", @"C:\supermercado2\conta.txt");

            FileStream rel4 = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(rel4);

            string bak1 = @"C:\supermercado2\agenda.bak1";

            FileStream relacao1 = new FileStream(bak1, FileMode.Create, FileAccess.Write);
            StreamWriter a1 = new StreamWriter(relacao1);

            FileStream rel2 = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
            StreamReader cad2 = new StreamReader(rel2);

            string bak2 = @"C:\supermercado2\agenda.bak2";

            FileStream relacao2 = new FileStream(bak2, FileMode.Create, FileAccess.Write);
            StreamWriter a2 = new StreamWriter(relacao2);

            FileStream rel3 = new FileStream(higiene, FileMode.Open, FileAccess.Read);
            StreamReader cad3 = new StreamReader(rel3);

            string bak3 = @"C:\supermercado2\agenda.bak3";

            FileStream relacao3 = new FileStream(bak3, FileMode.Create, FileAccess.Write);
            StreamWriter a3 = new StreamWriter(relacao3);

            while (cad.Peek() != -1)
            {
                string linha = cad.ReadLine();
                string[] pos = linha.Split(';');

                codigo = int.Parse(pos[0]);
                nome = pos[1];
                preco = double.Parse(pos[2]);
                qtd = int.Parse(pos[3]);

                if (codigo == pesq)
                {
                    quant = quant + qtd;
                    a1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + quant);
                }

                else
                {
                    a1.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            while (cad2.Peek() != -1)
            {
                string linha = cad2.ReadLine();
                string[] pos = linha.Split(';');

                codigo = int.Parse(pos[0]);
                nome = pos[1];
                preco = double.Parse(pos[2]);
                qtd = int.Parse(pos[3]);

                if (pesq == codigo)
                {
                    quant = quant + qtd;
                    a2.WriteLine(codigo + ";" + nome + ";" + preco + ";" + quant);
                }

                else
                {
                    a2.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            while (cad3.Peek() != -1)
            {
                string linha = cad3.ReadLine();
                string[] pos = linha.Split(';');

                codigo = int.Parse(pos[0]);
                nome = pos[1];
                preco = double.Parse(pos[2]);
                qtd = int.Parse(pos[3]);

                if (pesq == codigo)
                {
                    quant = quant + qtd;
                    a3.WriteLine(codigo + ";" + nome + ";" + preco + ";" + quant);
                }

                else
                {
                    a3.WriteLine(codigo + ";" + nome + ";" + preco + ";" + qtd);
                }
            }

            a3.Close();
            relacao3.Close();

            a2.Close();
            relacao2.Close();

            a1.Close();
            relacao1.Close();

            cad3.Close();
            rel3.Close();

            cad2.Close();
            rel2.Close();

            cad.Close();
            rel4.Close();

            File.Delete(@"C:\supermercado2\limpeza.txt");
            File.Move(@"C:\supermercado2\agenda.bak1", @"C:\supermercado2\limpeza.txt");

            File.Delete(@"C:\supermercado2\alimentacao.txt");
            File.Move(@"C:\supermercado2\agenda.bak2", @"C:\supermercado2\alimentacao.txt");

            File.Delete(@"C:\supermercado2\higiene.txt");
            File.Move(@"C:\supermercado2\agenda.bak3", @"C:\supermercado2\higiene.txt");
        }
        // FIM DO PROCEDIMENTO DE EXCLUIR

        // LISTA PRODUTOS DE ALIMENTACAO
        static void ListarAlimentacao(string alimentacao)
        {
            Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
            FileStream lista = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);
            {
                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);

                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad.Close();
            lista.Close();

            Console.Write("\n\n ------------------------------------------------------------------------------ \n");
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }

        // LISTA PRODUTOS DE HIGIENE
        static void ListarHigiene(string higiene)
        {
            Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
            FileStream lista = new FileStream(higiene, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);
            {
                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);

                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad.Close();
            lista.Close();

            Console.Write("\n\n ------------------------------------------------------------------------------ \n");
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }

        // LISTA PRODUTOS DE LIMPEZA
        static void ListarLimpeza(string limpeza)
        {
            Console.WriteLine("\n Código  Descrição \t\t Preço \t\t Estoque");
            FileStream lista = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
            StreamReader cad = new StreamReader(lista);
            {
                while (cad.Peek() != -1)
                {
                    string linha = cad.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);

                    Console.Write("\n {0}\t {1}\t\t {2:F2} \t\t {3}", codigo, nome, preco, qtd);
                }
            }
            cad.Close();
            lista.Close();

            Console.Write("\n\n ------------------------------------------------------------------------------ \n");
            Console.Write("\n Tecle ENTER para voltar...");
            Console.ReadKey();
        }

        /* VALIDA CODIGO DO PRODUTO 
         O CODIGO DO PRODUTO TEM QUE TER NO MAXIMO 4 E NO MINIMO 2 NUMEROS*/
        static void ValidaCodigo(string alimentacao, string higiene, string limpeza, out int cod)
        {
            string op = "s";

            do
            {
                FileStream rel7 = new FileStream(alimentacao, FileMode.Open, FileAccess.Read);
                StreamReader cad7 = new StreamReader(rel7);

                FileStream rel8 = new FileStream(higiene, FileMode.Open, FileAccess.Read);
                StreamReader cad8 = new StreamReader(rel8);

                FileStream rel9 = new FileStream(limpeza, FileMode.Open, FileAccess.Read);
                StreamReader cad9 = new StreamReader(rel9);
                Console.Write("\n Digite o código => ");
                ValidaLetra(out cod);

                // CONVERTE EM STRING PARA REALIZAR CONTAGEM DE NUMEROS
                string cd = Convert.ToString(cod);

                while ((cd.Length > 4) || (cd.Length < 2))
                {
                    Console.Write("\n Digite no máximo 4 números e mínimo 2 => ");
                    cd = Console.ReadLine();

                }

                cod = Convert.ToInt16(cd);

                int x = 0;

                // MENSAGEM DE ERRO PARA CODIGOS QUE JA ESTÃO CADASTRADOS
                while (cad7.Peek() != -1)
                {
                    string linha = cad7.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);


                    if (cod == codigo)
                    {
                        x = 1;
                        Console.Write("\n Este código já esta cadastrado em nosso sistema\n");
                        Console.Write("\n tecle enter para voltar");
                        Console.ReadKey();

                    }
                }

                while (cad8.Peek() != -1)
                {
                    string linha = cad8.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);

                    if (cod == codigo)
                    {
                        x = 1;
                        Console.WriteLine("\n Este código já esta cadastrado em nosso sistema\n");
                        Console.Write("\n tecle enter para voltar");
                        Console.ReadKey();
                    }
                }

                while (cad9.Peek() != -1)
                {
                    string linha = cad9.ReadLine();
                    string[] pos = linha.Split(';');

                    int codigo = int.Parse(pos[0]);
                    string nome = pos[1];
                    double preco = double.Parse(pos[2]);
                    int qtd = int.Parse(pos[3]);

                    if (cod == codigo)
                    {
                        x = 1;
                        Console.WriteLine("\n Este código já esta cadastrado em nosso sistema\n");
                        Console.Write("\n tecle enter para voltar");
                        Console.ReadKey();
                    }
                }

                if (x == 0)
                {
                    Console.Write("\n Este código esta disponível!!!\n");
                    Console.Write("\n Tecle ENTER para continuar... \n");
                    op = Console.ReadLine();
                }

                cad7.Close();
                rel7.Close();

                cad8.Close();
                rel8.Close();

                cad9.Close();
                rel9.Close();

            } while (op == "s");
        }
        // FIM DO PROCEDIMENTO DE VALIDA CODIGO

        // *********************************************************************** PROGRAMA PRINCIPAL *********************************
        static void Main(string[] args)
        {
            // CAPTURA A DATA DO SISTEMA
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();

            /* blocos de comandos para criação de arquivos */

            // caminho do arquivo clientes.txt para cadastro de clientes
            string clientes = @"C:\supermercado2\clientes.txt";

            // cria um arquivo para clientes
            if (!File.Exists(clientes))
            {
                FileStream relatorio = new FileStream(clientes, FileMode.CreateNew, FileAccess.ReadWrite);
                relatorio.Close();
            }

            string contacliente = @"C:\supermercado2\conta.txt";

            // cria um arquivo para clientes
            if (!File.Exists(contacliente))
            {
                FileStream relatorio = new FileStream(contacliente, FileMode.CreateNew, FileAccess.ReadWrite);
                relatorio.Close();
            }

            // caminho do arquivo limpeza.txt para cadastrar podutos de limpeza
            string limpeza = @"C:\supermercado2\limpeza.txt";

            // cria um arquivo txt para produtos de limpeza
            if (!File.Exists(limpeza))
            {
                FileStream relatorio = new FileStream(limpeza, FileMode.CreateNew, FileAccess.ReadWrite);
                relatorio.Close();
            }

            // caminho do arquivo alimentacao.txt para produtos de alimentacao
            string alimentacao = @"C:\supermercado2\alimentacao.txt";

            // cria um arquivo txt para para alimentacao
            if (!File.Exists(alimentacao))
            {
                FileStream relatorio = new FileStream(alimentacao, FileMode.CreateNew, FileAccess.ReadWrite);
                relatorio.Close();
            }

            // caminho do arquivo higiene.txt para produtos de higiene
            string higiene = @"C:\supermercado2\higiene.txt";

            // cria um arquivo txt para produtos de higiene
            if (!File.Exists(higiene))
            {
                FileStream relatorio = new FileStream(higiene, FileMode.CreateNew, FileAccess.ReadWrite);
                relatorio.Close();
            }

            /* fim do bloco de comandos para criar arquivos */


            // criação de variavel local no programa principal           
            int op, x = 0, y = 0;
            string senha, tel, nome, loga = "nome", linha, entrar;
            int escolha, pos1, pos2;
            double carrinho = 0;


            /* primeira cena do programa o usuario terá que logar para entrar
             se não terá que criar uma senha e se cadastrar */
            // A OPCAO 3 É APENAS ADMINISTRADORES SENHAS "ROGERIO"
            do
            {
                Console.Clear();
                Console.Write("\n\t\t>>> SEJA BEM VINDO EM NOSSA LOJA ONLINE <<<\n\n");
                Console.Write(" Opção 1 - Faça seu cadastro em nosso sitema.\n");
                Console.Write(" Opção 2 - Já esta cadastrado? então faça seu login.\n");
                Console.Write(" Opçõa 3 - Área restrita para nossos administradores.\n");
                Console.Write("\n 1 - Cadastrar\n 2 - Logar\n 3 - Administrador\n");
                Console.Write("\n Sua opção aqui => ");

                ValidaLetra(out escolha);
                ValidaEntrada(ref escolha, 3);

                // caso seja sua primeira visita, o usuario terá que se cadastrar
                if (escolha == 1)
                {
                    CadastroCliente(clientes); // CHAMA O PROCEDIMENTO PARA CADASTRO
                }

                else
                {
                    if (escolha == 2)
                    {
                        // aqui o usuario ira fazer seu login, caso já esteja cadastrado
                        Console.Clear();
                        Console.Write("\n\t\t\t>>> FAÇA SEU LOGIN <<<\n\n");

                        FileStream rel = new FileStream(clientes, FileMode.Open, FileAccess.Read);
                        StreamReader cad = new StreamReader(rel);

                        Console.Write("\n Faça seu login para entrar em nosso sitema.\n");
                        Console.Write("\n Digite aqui sua senha => ");

                        entrar = "";
                        do
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                            {
                                entrar += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if (key.Key == ConsoleKey.Backspace && entrar.Length > 0)
                                {
                                    entrar = entrar.Substring(0, (entrar.Length - 1));
                                    Console.Write("\b \b");
                                }
                                else
                                {
                                    if (key.Key == ConsoleKey.Enter)
                                    {
                                        break;
                                    }
                                }
                            }

                        } while (true);

                        while (cad.Peek() != -1)
                        {
                            linha = cad.ReadLine();
                            pos1 = linha.IndexOf(";") + 1;
                            pos2 = linha.IndexOf(";", pos1) + 1;

                            senha = linha.Substring(0, pos1 - 1);
                            nome = linha.Substring(pos1, pos2 - pos1 - 1);
                            tel = linha.Substring(pos2);

                            if (entrar == senha)
                            {
                                x = 1;
                                loga = nome;
                            }
                        }
                        // mensagem de erro
                        if (x == 0)
                        {
                            Console.Write("\n\n Senha incorreta ou inexistente\n");
                            Console.Write("\n Tecle ENTER para voltar...");
                            Console.ReadKey();
                        }

                        cad.Close();
                        rel.Close();
                    }
                    else
                    {
                        // LOGIN PARA OS ADMS
                        string adm1 = "adm1";
                        string adm2 = "adm2";
                        string rogerio = "rogerio";
                        string adm;

                        Console.Clear();
                        Console.Write("\n\t\t>>> ADM FAÇA SEU LOGIN <<<\n\n");

                        Console.Write("\n Administrador digite sua senha = > ");
                        adm = Console.ReadLine().ToLower();

                        if ((adm == adm1) || (adm == adm2) || (adm == rogerio))
                        {
                            Console.Write("\n Senha autorizada! Tecle ENTER para entrar no sistema...");
                            y = 1;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Write("\n Senha incorreta. tecle ENTER para voltar...");
                            Console.ReadKey();
                        }
                    }
                }
            } while ((x != 1) && (y != 1));
            // FIM DO PRIMEIRO MENU DO SISTEMA


            // PROCESSO DE CODIGO DA AREA DA ADMINISTRACAO ********************************************************************************************
            if (y == 1)
            {
                do
                {
                    // MENU PRINCIPAL DA ADMINISTRACAO
                    Console.Clear();
                    Console.Write("\n\t\t>>> AREA DA ADMINISTRAÇÃO <<<\n\n");
                    Console.Write(" Escolha uma das opções:\n");
                    Console.Write("\n 1 - Cadastrar produtos;\n 2 - Listar produtos;\n 3 - Consultar por código do produto;\n 4 - Listar todos clientes;\n 5 - Total de cada produto;\n 6 - Total do mercado;\n 7 - Alterar;\n 8 - Sair.\n");
                    Console.Write("\n Digite aqui sua opção => ");
                    ValidaLetra(out op);
                    Valida(ref op, 8);

                    switch (op)
                    {
                        case 1: // CASO 1 PARA CADASTRAMENTO
                            string produto, n;
                            int opcao, q, codigo;
                            double p;

                            do
                            {
                                Console.Clear();
                                Console.Write("\n\t\t>>> ESCOLHA UMA CATEGORIA PARA CADASTRO <<<\n\n");
                                Console.Write(" 1 - Limpeza\n 2 - Alimentação\n 3 - Higiene\n 4 - Voltar\n");
                                Console.Write("\n Sua opção aqui => ");
                                ValidaLetra(out opcao);
                                ValidaEntrada(ref op, 4);

                                if (opcao == 1) // OPCAO 1 CADASTRAR LIMPEZA
                                {
                                    do
                                    {
                                        Console.Clear();
                                        Console.Write("\n\t\t>>> CADASTRO DE PRODUTOS DE LIMPEZA <<<\n\n");

                                        Console.Write("\n Digite o código do produto máximo 4 digitos e mínimo 2 ");

                                        ValidaCodigo(alimentacao, higiene, limpeza, out codigo);

                                        FileStream cadastro = new FileStream(limpeza, FileMode.Append, FileAccess.Write);
                                        StreamWriter cad = new StreamWriter(cadastro);

                                        Console.Write("\n Digite o nome do produto (máximo 14 cacteres, mínimo 8) => ");

                                        produto = Console.ReadLine().ToUpper();
                                        MaximoCaracter(ref produto, 14, 8);

                                        Console.Write("\n Digite o preço do produto => R$ ");
                                        ValidaLetraDouble(out p);

                                        Console.Write("\n Digite a quantidade do produto => ");
                                        ValidaLetra(out q);

                                        string con = Convert.ToString(q);

                                        cad.WriteLine(codigo + ";" + produto + ";" + p + ";" + q); // grava no arquivo                                        

                                        cad.Close();
                                        cadastro.Close();

                                        Console.Write("\n Deseja cadastrar mais itens? s/n => ");
                                        n = Console.ReadLine().ToLower();

                                        ValidaLetra(ref n);

                                    } while (n != "n");
                                } // fecha if opcao 1

                                else
                                {
                                    if (opcao == 2) // OPCAO 2 CADASTRAR ALIMENTACAO
                                    {
                                        do
                                        {
                                            Console.Clear();
                                            Console.Write("\n\t\t>>> CADASTRO DE PRODUTOS DE ALIMENTAÇÃO <<<\n\n");
                                            Console.Write("\n Digite o código do produto máximo 4 digitos e mínimo 2 ");
                                            ValidaCodigo(alimentacao, higiene, limpeza, out codigo);

                                            FileStream cadastro = new FileStream(alimentacao, FileMode.Append, FileAccess.Write);
                                            StreamWriter cad = new StreamWriter(cadastro);

                                            Console.Write("\n Digite o nome do produto (máximo 14 cacteres, mínimo 8) => ");
                                            produto = Console.ReadLine().ToUpper();
                                            MaximoCaracter(ref produto, 14, 8);

                                            Console.Write("\n Digite o preço do produto => R$ ");
                                            ValidaLetraDouble(out p);

                                            Console.Write("\n Digite a quantidade do produto => ");
                                            ValidaLetra(out q);

                                            cad.WriteLine(codigo + ";" + produto + ";" + p + ";" + q); // grava no arquivo cadastro.txt nome, preço e quantidade                                              

                                            cad.Close();
                                            cadastro.Close();

                                            Console.Write("\n Deseja cadastrar mais itens? s/n => ");
                                            n = Console.ReadLine().ToLower();
                                            ValidaLetra(ref n);

                                        } while (n != "n");

                                    } // fecha if opcao 2               
                                    else
                                    {
                                        if (opcao == 3) // OPCAO 3 CADASTRAR HIGIENE
                                        {
                                            do
                                            {
                                                Console.Clear();
                                                Console.Write("\n\t\t>>> CADASTRO DE PRODUTOS DE HIGIENE <<<\n\n");
                                                Console.Write("\n Digite o código do produto máximo 4 digitos e mínimo 2 ");
                                                ValidaCodigo(alimentacao, higiene, limpeza, out codigo);

                                                FileStream cadastro = new FileStream(higiene, FileMode.Append, FileAccess.Write);
                                                StreamWriter cad = new StreamWriter(cadastro);

                                                Console.Write("\n Digite o nome do produto (máximo 14 cacteres, mínimo 8) => ");
                                                produto = Console.ReadLine().ToUpper();
                                                MaximoCaracter(ref produto, 14, 8);

                                                Console.Write("\n Digite o preço do produto => R$ ");
                                                ValidaLetraDouble(out p);

                                                Console.Write("\n Digite a quantidade do produto => ");
                                                ValidaLetra(out q);

                                                cad.WriteLine(codigo + ";" + produto + ";" + p + ";" + q); // grava no arquivo cadastro.txt nome, preço e quantidade  

                                                cad.Close();
                                                cadastro.Close();

                                                Console.Write("\n Deseja cadastrar mais itens? s/n => ");
                                                n = Console.ReadLine().ToLower();
                                                ValidaLetra(ref n);

                                            } while (n != "n");

                                        } //fecha if opcao 3
                                    } // fecha else
                                } // fecha else               

                            } while (opcao != 4); // fecha o do...while case 1
                            Console.Write("\n\tTecle ENTER para voltar...");
                            break;
                        // FIM DO CASO 1

                        case 2: // CASO 2 LISTAR PRODUTOS
                            do
                            {
                                Console.Clear();
                                Console.Write("\n\t\t>>> ESCOLHA UMA CATEGORIA PARA LISTAR <<<\n\n");
                                Console.Write(" 1 - Listar todos os produtos\n 2 - Listar produtos de alimentação\n 3 - Listar produtos de Higiene\n 4 - Listar produtos de Limpeza\n 5 - Voltar\n");
                                Console.Write("\n Sua opção aqui => ");
                                ValidaLetra(out opcao);
                                Valida(ref opcao, 5);

                                if (opcao == 1) // OPCAO 1 LISTAR TODOS OS PRODUTOS
                                {
                                    Console.Clear();
                                    Console.Write("\n\t\t>>> LISTAR TODOS OS PRODUTOS <<<\n\n\n");
                                    Listar(limpeza, alimentacao, higiene);
                                }
                                else
                                {
                                    if (opcao == 2) // OPCAO 2 LISTAR TODOS ALIMENTACAO
                                    {
                                        Console.Clear();
                                        Console.Write("\n\t\t>>> LISTAR PRODUTOS DE ALIMENTAÇÃO <<<\n\n");
                                        ListarAlimentacao(alimentacao);
                                    }
                                    else
                                    {
                                        if (opcao == 3) // OPCAO 3 LISTAR HIGIENE
                                        {
                                            Console.Clear();
                                            Console.Write("\n\t\t>>> LISTAR PRODUTOS DE HIGIENE <<<\n\n");
                                            ListarHigiene(higiene);
                                        }
                                        else
                                        {
                                            if (opcao == 4) // OPCAO 4 LISTAR TODOS LIMPEZA
                                            {
                                                Console.Clear();
                                                Console.Write("\n\t\t>>> LISTAR PRODUTOS DE LIMPEZA <<<\n\n");
                                                ListarLimpeza(limpeza);
                                            }
                                        }
                                    }
                                }
                            } while (opcao != 5); // OPCAO 5 VOLTAR PARA MENU PRINCIPAL
                            Console.Write("\n\tTecle ENTER para voltar...");
                            break;

                        case 3: // CASO 3 CONSULTAR POR PRODUTO
                            Console.Clear();
                            Console.Write("\n\t\t>>> CONSULTA POR PRODUTO <<<\n\n");
                            Consultar(limpeza, higiene, alimentacao);
                            break;

                        case 4: // LISTAR TODOS OS CLIENTES  
                            Console.Clear();
                            Console.Write("\n\t\t>>> LISTAR TODOS OS CLIENTES <<<\n\n");
                            ListarClientes(clientes);
                            break;

                        case 5: // CASO 5 LISTAR VALOR TOTAL DE CADA PRODUTO
                            Console.Clear();
                            Console.Write("\n\t\t>>> LISTAR VALOR TOTAL DE CADA PRODUTO <<<\n\n");
                            ListarEstoque(alimentacao, higiene, limpeza);
                            break;

                        case 6: // CASO 6 LISTAR ESTOQUE TOTAL
                            Console.Clear();
                            Console.Write("\n\t\t>>> LISTAR ESTOQUE TOTAL DO MERCADO <<<\n\n");
                            EstoqueTotal(alimentacao, higiene, limpeza);
                            break;

                        case 7: // CASO 7 ALTERAR CADASTROS DE PRODUTOS                        
                            do
                            {
                                Console.Clear();
                                Console.Write("\n\t\t>>> ALTERAÇÃO DE PRODUTOS <<<\n\n");
                                Console.Write("\n Escolha uma categoria de produto para alteração. \n");
                                Console.Write("\n 1 - Alimentação;\n 2 - Higiene;\n 3 - Limpeza;\n 4 - Voltar.\n ");
                                Console.Write("\n Sua opção aqui => ");
                                ValidaLetra(out opcao);
                                Valida(ref opcao, 4);

                                if (opcao == 1)
                                {
                                    AlterarAlimentacao(alimentacao, higiene, limpeza);
                                }
                                else
                                {
                                    if (opcao == 2)
                                    {
                                        AlterarHigiene(alimentacao, higiene, limpeza);
                                    }
                                    else
                                    {
                                        if (opcao == 3)
                                        {
                                            AlterarLimpeza(alimentacao, higiene, limpeza);
                                        }
                                    }
                                }
                            } while (opcao != 4);
                            Console.Write("\n\tTecle ENTER para voltar...");
                            break;
                    }
                    // fim switch

                } while (op != 8);
                File.Delete(@"C:\supermercado2\conta.txt");
            }

            // PROCESSO DE CÓDIGO DA AREA DO CLIENTE *************************************************************************************************
            else
            {
                if (x == 1)
                {
                    do
                    {
                        // MENU PRINCIPAL DO CLIENTE
                        int opcao;
                        Console.Clear();
                        Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                        Console.Write("\n\t\t\t>>> MENU PRINCIPAL <<<\n\n");
                        Console.Write("\n Escolha abaixo uma de nossas opções:\n");
                        Console.Write("\n > 1  Relatório de todos os produtos;\n\n > 2  Consultar por produto;\n\n > 3  Cosulte nossas formas de PGT;\n\n > 4  Comprar produtos;\n\n > 5  Finalizar venda;\n\n > 6  Sair.\n");
                        Console.Write("\n\n Digite aqui sua opção => ");
                        ValidaLetra(out op);
                        Valida(ref op, 6);

                        switch (op)
                        {
                            case 1: // CASO 1 PARA LISTAR PRODUTOS
                                do
                                {
                                    // SUBMENU DO CLIENTE
                                    Console.Clear();
                                    Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                    Console.Write("\n\t\t\t>>> ESCOLHA UMA CATEGORIA PARA LISTAR <<<\n\n");
                                    Console.Write("\n >> 1  Listar todos os produtos\n\n >> 2  Listar produtos de alimentação\n\n >> 3  Listar produtos de Higiene\n\n >> 4  Listar produtos de Limpeza\n\n >> 5  Voltar\n");
                                    Console.Write("\n\n Digite aqui sua opção => ");
                                    ValidaLetra(out opcao);
                                    Valida(ref opcao, 5);

                                    if (opcao == 1) // OPCAO 1 DO CLIENTE LISTAR TODOS OS PRODUTOS
                                    {
                                        Console.Clear();
                                        Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                        Console.Write("\n\t\t\t>>> LISTAR TODOS OS PRODUTOS <<<\n\n\n");
                                        Listar(limpeza, alimentacao, higiene);
                                    }
                                    else
                                    {
                                        if (opcao == 2) // OPCAO 2 DO CLIENTE LISTAR PRODUTOS DE ALIMENTACAO
                                        {
                                            Console.Clear();
                                            Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                            Console.Write("\n\t\t\t>>> LISTAR PRODUTOS DE ALIMENTAÇÃO <<<\n\n\n");
                                            ListarAlimentacao(alimentacao);
                                        }
                                        else
                                        {
                                            if (opcao == 3) // OPCAO 3 DO CLIENTE LISTAR PRODUTOS HIGIENE
                                            {
                                                Console.Clear();
                                                Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                                Console.Write("\n\t\t\t>>> LISTAR PRODUTOS DE HIGIENE <<<\n\n\n");
                                                ListarHigiene(higiene);
                                            }
                                            else
                                            {
                                                if (opcao == 4) // OPCAO 4 DO CLIENTE LISTAR PRODUTOS LIMPEZA
                                                {
                                                    Console.Clear();
                                                    Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                                    Console.Write("\n\t\t\t>>> LISTAR PRODUTOS DE LIMPEZA <<<\n\n\n");
                                                    ListarHigiene(limpeza);
                                                }
                                            }
                                        }
                                    }
                                } while (opcao != 5); // OPCAO 5 VOLTA PARA O MENU PRINCIPAL
                                Console.Write("\n\n Tecle ENTER para voltar...");
                                break;

                            case 2: // CASO 2 CONSULTAR POR PRODUTO                                   
                                Console.Clear();
                                Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                Console.Write("\n\t\t\t>>> CONSULTA POR PRODUTO <<<\n\n");
                                Consultar(limpeza, higiene, alimentacao);
                                break;

                            case 3: // IMPRIMI FORMAS DE PAGAMENTOS
                                Console.Clear();
                                Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                Console.Write("\n\t\t\t>>> NOSSAS FORMAS DE PAGAMENTO <<<\n\n");
                                Console.Write("\n >>  A vista;\n\n >>  A prazo em 2x 5% de juros;\n\n >>  A prazo em 3x 10% de juros.\n");
                                Console.Write("\n\n Tecle ENTER para voltar...");
                                Console.ReadKey();
                                break;

                            case 4: // PROCEDIMENTO DE COMPRAS
                                do
                                {
                                    Console.Clear();
                                    Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                                    Console.Write("\n\t\t\t>>> PROCEDIMENTO DE COMPRAS <<<\n\n");
                                    Console.Write("\n Escolha uma das categorias abaixo para comprar.\n Na opção 4, você poderá listar todos os seus produtos e exluir do carrinho.\n");
                                    Console.Write(" Boas compras!!!\n");
                                    Console.Write("\n >> 1  Alimentação;\n\n >> 2  Higiene;\n\n >> 3  Limpeza;\n\n >> 4  Minha compra\n\n >> 5  Voltar.\n");
                                    Console.Write("\n Digite sua opção aqui => ");
                                    ValidaLetra(out opcao);
                                    Valida(ref opcao, 5);

                                    if (opcao == 1) // OPCAO 1 COMPRAR PRODUTOS DE ALIMENTACAO
                                    {
                                        ComprarAlimentacao(alimentacao, contacliente, loga, ref carrinho, dia, mes, ano);
                                    }
                                    else
                                    {
                                        if (opcao == 2) // OPCAO 2 COMPRAR PRODUTOS DE HIGIENE
                                        {
                                            ComprarHigiene(higiene, contacliente, loga, ref carrinho, dia, mes, ano);
                                        }
                                        else
                                        {
                                            if (opcao == 3) // OPCAO 3 COMPRAR PRODUTOS DE LIMPEZA
                                            {
                                                ComprarLimpeza(limpeza, contacliente, loga, ref carrinho, dia, mes, ano);
                                            }
                                            else
                                            {
                                                if (opcao == 4) // OPCAO 4 IMPRIRMI PRODUTOS COMPRADOS
                                                {
                                                    MinhaCompra(alimentacao, higiene, limpeza, contacliente, loga, ref carrinho, dia, mes, ano);
                                                }
                                            }
                                        }
                                    }
                                } while (opcao != 5);
                                Console.Write("\n\tTecle ENTER para voltar...");
                                break;
                        }
                        // fim switch

                    } while ((op != 6) && (op != 5));

                    if (op == 6) // USUARIO SAI DO PROGRAMA SEM COMPRAR NADA
                    {
                        Console.Clear();
                        Console.Write("\n\n\t\t>>> Obrigado cliente {0} pela visita!!! <<<", loga);
                        Console.Write("\n\n\t\t              VOLTE SEMPRE!!!              ");
                        File.Delete(@"C:\supermercado2\conta.txt");
                        Console.ReadKey();
                    }

                    // PROCIMENTO DE FINALIZAÇÃO DE COMPRA
                    if (op == 5) // FINALIZAÇÃO DA COMPRA O USUARIO TERÁ 3 OPCOES DE FORMAS DE PAGAMENTO
                    {
                        string horas = DateTime.Now.Hour.ToString();
                        string min = DateTime.Now.Minute.ToString();
                        string seg = DateTime.Now.Second.ToString();
                        Console.Clear();
                        Console.Write("Logado por {0} \t Seu carrinho R$ {1:F2} \t {2}/{3}/{4}\n", loga, carrinho, dia, mes, ano);
                        Console.Write("\n\t\t\t>>> FINALIZAR COMPRA <<<\n\n");
                        Console.Write("\n Escolha sua forma de pagamento.\n");
                        Console.Write("\n >> 1  A vista;\n\n >> 2  A prazo em 2x;\n\n >> 3  A prazo em 3x.\n");
                        Console.Write("\n Digite aqui sua opção => ");

                        ValidaLetra(out op);
                        ValidaEntrada(ref op, 3);

                        if (op == 1) // PAGAMENTO A VISTA
                        {
                            Console.Clear();
                            Console.Write("\n\t                      CUSPOM FISCAL                       \n");
                            Console.Write("\n\t -------------------------------------------------------- \n");
                            Console.Write("\n\t Cliente: {0}\n", loga);
                            Console.Write("\n\t Cupom fiscal gerado dia {0}/{1}/{2}\n", dia, mes, ano);
                            Console.Write("\n\t Horas: {0}:{1}:{2}\n", horas, min, seg);
                            Console.Write("\n\t -------------------------------------------------------- \n\n");
                            FileStream lista1 = new FileStream(contacliente, FileMode.Open, FileAccess.Read);
                            StreamReader cad1 = new StreamReader(lista1);

                            while (cad1.Peek() != -1)
                            {
                                linha = cad1.ReadLine();
                                string[] pos = linha.Split(';');

                                int codigo = int.Parse(pos[0]);
                                nome = pos[1];
                                double preco = double.Parse(pos[2]);
                                int qtd = int.Parse(pos[3]);

                                Console.WriteLine("\t Produto: {0}", nome);
                                Console.WriteLine("\t Preço {1:F2} \t\t\t Quantidade: {2}", nome, preco, qtd);
                                Console.WriteLine();
                            }

                            Console.Write("\n\t -------------------------------------------------------- \n");
                            Console.Write("\n\t Valor total: {0:F2}                                      \n", carrinho);
                            Console.Write("\n\t Forma de pagamento a vista                               \n");
                            Console.Write("\n\t -------------------------------------------------------- \n");

                            cad1.Close();
                            lista1.Close();
                            File.Delete(@"C:\supermercado2\conta.txt");

                            Console.Write("\n\n COMPRA FINALIZADA!!");
                            Console.Write("\n\n AGRADECEMOS A PREFERENCIA!!");
                            carrinho = carrinho - carrinho;
                            Console.ReadKey();
                        }
                        else
                        {
                            if (op == 2) // OPCAO 2 PAGAMENTO EM 2 VEZES
                            {
                                Console.Clear();
                                double prazo = carrinho / 2 * 1.05; // CALCULO PARA PAGAMENTO A PRAZO
                                double prazototal = carrinho * 1.05;
                                Console.Write("\n\t                      CUSPOM FISCAL                       \n");
                                Console.Write("\n\t -------------------------------------------------------- \n");
                                Console.Write("\n\t Cliente: {0}\n", loga);
                                Console.Write("\n\t Cupom fiscal gerado dia {0}/{1}/{2}\n", dia, mes, ano);
                                Console.Write("\n\t Horas: {0}:{1}:{2}\n", horas, min, seg);
                                Console.Write("\n\t -------------------------------------------------------- \n\n");
                                FileStream lista1 = new FileStream(contacliente, FileMode.Open, FileAccess.Read);
                                StreamReader cad1 = new StreamReader(lista1);

                                while (cad1.Peek() != -1)
                                {
                                    linha = cad1.ReadLine();
                                    string[] pos = linha.Split(';');

                                    int codigo = int.Parse(pos[0]);
                                    nome = pos[1];
                                    double preco = double.Parse(pos[2]);
                                    int qtd = int.Parse(pos[3]);

                                    Console.WriteLine("\t Produto: {0}", nome);
                                    Console.WriteLine("\t Preço {1:F2} \t\t\t Quantidade: {2}", nome, preco, qtd);
                                    Console.WriteLine();
                                }

                                Console.Write("\n\t -------------------------------------------------------- \n");
                                Console.Write("\n\t Valor total: {0:F2}\n", carrinho);
                                Console.Write("\n\t Valor total a prazo: {0:F2}\n", prazototal);
                                Console.Write("\n\t Forma de pagamento em 2 vezes\n");
                                Console.Write("\n\t -------------------------------------------------------- \n");
                                Console.Write("\n\t Juros de 1,05\n");
                                Console.Write("\n\t 1ª parcela: {0:F2}\n", prazo);
                                Console.Write("\n\t 2ª parcela: {0:F2}\n", prazo);
                                Console.Write("\n\t -------------------------------------------------------- \n");

                                cad1.Close();
                                lista1.Close();
                                File.Delete(@"C:\supermercado2\conta.txt");

                                Console.Write("\n\n COMPRA FINALIZADA!!");
                                Console.Write("\n\n AGRADECEMOS A PREFERENCIA!!");
                                carrinho = carrinho - carrinho;
                                Console.ReadKey();
                            }
                            else
                            {
                                // OPCAO 3 PAGAMENTO EM 3 VEZES
                                Console.Clear();
                                double prazo = carrinho / 3 * 1.10;
                                double prazototal = carrinho * 1.10;
                                Console.Write("\n\t                      CUSPOM FISCAL                       \n");
                                Console.Write("\n\t -------------------------------------------------------- \n");
                                Console.Write("\n\t Cliente: {0}\n", loga);
                                Console.Write("\n\t Cupom fiscal gerado dia {0}/{1}/{2}\n", dia, mes, ano);
                                Console.Write("\n\t Horas: {0}:{1}:{2}\n", horas, min, seg);
                                Console.Write("\n\t -------------------------------------------------------- \n\n");
                                FileStream lista1 = new FileStream(contacliente, FileMode.Open, FileAccess.Read);
                                StreamReader cad1 = new StreamReader(lista1);

                                while (cad1.Peek() != -1)
                                {
                                    linha = cad1.ReadLine();
                                    string[] pos = linha.Split(';');

                                    int codigo = int.Parse(pos[0]);
                                    nome = pos[1];
                                    double preco = double.Parse(pos[2]);
                                    int qtd = int.Parse(pos[3]);

                                    Console.WriteLine("\t Produto: {0}", nome);
                                    Console.WriteLine("\t Preço {1:F2} \t\t\t Quantidade: {2}", nome, preco, qtd);
                                    Console.WriteLine();
                                }

                                Console.Write("\n\t -------------------------------------------------------- \n");
                                Console.Write("\n\t Valor total: {0:F2}\n", carrinho);
                                Console.Write("\n\t Valor total a prazo: {0:F2}\n", prazototal);
                                Console.Write("\n\t Forma de pagamento em 3 vezes\n");
                                Console.Write("\n\t -------------------------------------------------------- \n");
                                Console.Write("\n\t Juros de 1,10\n");
                                Console.Write("\n\t 1ª parcela: {0:F2}\n", prazo);
                                Console.Write("\n\t 2ª parcela: {0:F2}\n", prazo);
                                Console.Write("\n\t 3ª parcela: {0:F2}\n", prazo);
                                Console.Write("\n\t -------------------------------------------------------- \n");

                                cad1.Close();
                                lista1.Close();
                                File.Delete(@"C:\supermercado2\conta.txt");

                                Console.Write("\n\n COMPRA FINALIZADA!!");
                                Console.Write("\n\n AGRADECEMOS A PREFERENCIA!!");
                                carrinho = carrinho - carrinho;
                                Console.ReadKey();
                            }
                        }
                    }// FIM DO PROCEDIMENTO DE FINALIZAÇÃO DE COMPRA                                                                           
                }
            }
        }// FIM DO PROGRAMA PRINCIPAL
    }
}