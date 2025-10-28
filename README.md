# 🔐 Autenticação de Dois Fatores (2FA) via Terminal — C#

Um projeto simples e didático que demonstra como implementar **autenticação em dois fatores (2FA)** usando **C# no terminal (console app)**.  
Ideal para quem está aprendendo **segurança, autenticação e lógica de back-end**.

---

## 🚀 Funcionalidades

- ✅ Login com usuário e senha  
- 🔢 Geração de código 2FA (OTP) com 6 dígitos  
- ⏳ Expiração automática do código (2 minutos)  
- ⚠️ Limite de tentativas (3)  
- 🔒 Uso de `RandomNumberGenerator` para gerar código seguro  
- 🧠 Código limpo, comentado e fácil de entender  

---

## 🧩 Tecnologias Utilizadas

- **C# (.NET 6+)**
- **System.Security.Cryptography** → geração segura de código OTP
- **Console Application**

---

## 📂 Estrutura do Projeto

2FA-Console/
│
├── Program.cs # Código principal
├── README.md # Este arquivo


---

## 💻 Como Executar

1. **Clone o repositório**
   ```bash
   git clone https://github.com/seuusuario/2FA-Console.git

2.**Acesse a pasta do projeto

cd 2FA-Console

3.**Compile e execute

dotnet run

# 🔧 Exemplo de Uso

=== 2FA (com expiração e limite de tentativas) ===

Usuário: matheus
Senha: 1234

[SIMULAÇÃO] Enviando código para matheus...
[SIMULAÇÃO] Código: 472918

Digite o código (tentativa 1/3): 472918
✅ Autenticado com sucesso!

# 🧱 Estrutura Interna

GerarOtp(int digitos)
Cria um código numérico de 6 dígitos usando RandomNumberGenerator (criptograficamente seguro).

EnviarCodigoSimulado(string usuario, string codigo)
Simula o envio do código por SMS/e-mail.
👉 Você pode substituir essa função por uma integração com MailKit, Twilio ou outro serviço.

Expiração e Tentativas
O código expira após 2 minutos e o usuário tem 3 tentativas antes do bloqueio.

# 🔐 Boas Práticas

Nunca salve senhas em texto plano → use hash seguro (BCrypt, PBKDF2, Argon2)

Sempre use HTTPS/TLS em produção

Limite as tentativas de login e 2FA

Evite exibir o código OTP no console em produção

Registre logs apenas de tentativas (nunca do código gerado)

# 📜 Licença

Este projeto é de uso educacional e está sob a licença MIT.
Sinta-se à vontade para modificar, estudar e aprimorar.

👨‍💻 Autor

Matheus Oliveira
Especialista em Tecnologia, Dados e Automação

