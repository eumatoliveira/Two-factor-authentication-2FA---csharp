using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== 2FA (com expiração e limite de tentativas) ===\n");

        string usuarioCorreto = "matheus";
        string senhaCorreta = "1234";

        Console.Write("Usuário: ");
        string usuario = Console.ReadLine();

        Console.Write("Senha: ");
        string senha = Console.ReadLine();

        if (usuario == usuarioCorreto && senha == senhaCorreta)
        {
            // Gera OTP seguro
            string otp = GerarOtp(6);
            DateTime dataGeracao = DateTime.UtcNow;
            TimeSpan validade = TimeSpan.FromMinutes(2); // código válido por 2 minutos

            EnviarCodigoSimulado(usuario, otp); // enviar (simulado)

            // validação com limite de tentativas
            int tentativasMax = 3;
            bool autenticado = false;

            for (int tentativa = 1; tentativa <= tentativasMax; tentativa++)
            {
                Console.Write($"\nDigite o código (tentativa {tentativa}/{tentativasMax}): ");
                string codigoDigitado = Console.ReadLine();

                // Verifica expiração
                if (DateTime.UtcNow - dataGeracao > validade)
                {
                    Console.WriteLine("❌ Código expirado. Por favor reenvie/login novamente.");
                    break;
                }

                if (codigoDigitado == otp)
                {
                    autenticado = true;
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Código incorreto.");
                }
            }

            if (autenticado)
                Console.WriteLine("\n✅ Autenticado com sucesso!");
            else
                Console.WriteLine("\n🔒 Falha na autenticação 2FA.");
        }
        else
        {
            Console.WriteLine("\n❌ Usuário ou senha incorretos.");
        }

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    // Gera um OTP numérico com RandomNumberGenerator (mais seguro que Random)
    static string GerarOtp(int digitos)
    {
        byte[] bytes = new byte[4];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(bytes);
        }

        // converte para inteiro positivo e formata com zeros à esquerda
        uint valor = BitConverter.ToUInt32(bytes, 0) % (uint)Math.Pow(10, digitos);
        return valor.ToString().PadLeft(digitos, '0');
    }

    // Simula envio do código (aqui só exibe; substitua por envio real)
    static void EnviarCodigoSimulado(string usuario, string codigo)
    {
        Console.WriteLine($"\n[SIMULAÇÃO] Enviando código para {usuario}...");
        Console.WriteLine($"[SIMULAÇÃO] Código: {codigo}");
    }
}
