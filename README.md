# LINQ-Lambda-EmployeeSearch

# Exemplo de Projeto LINQ e Lambda para Manipulação de Dados de Funcionários

Este projeto é uma aplicação em C# que demonstra o uso de LINQ e expressões lambda para buscar e manipular dados em uma lista de funcionários. A aplicação permite filtrar, ordenar e realizar cálculos com base em critérios como idade, anos de serviço, salário e a letra inicial do nome. É ideal para demonstrar como simplificar consultas de dados em uma lista usando LINQ.

## Funcionalidades

- Carrega uma lista de funcionários a partir de um arquivo de texto.
- Filtra e calcula:
  - Soma dos salários dos funcionários cujos nomes começam com uma letra específica.
  - E-mails dos funcionários com salário acima de um determinado valor.
  - Nomes dos funcionários com mais anos de serviço do que um valor especificado.
  - Nomes dos funcionários mais jovens do que uma idade especificada.
  
## Estrutura do Arquivo de Entrada

O arquivo de entrada deve conter informações dos funcionários no seguinte formato CSV:
Nome,Email,Salario,Data de Nascimento, Data de Admissaão.

## Exemplo de Entrada:

Alice,alice@example.com,2000.00,1990-01-15,2015-06-20
Bob,bob@example.com,3000.00,1985-08-12,2012-05-10


## Como Usar

1. Clone este repositório e abra o projeto no Visual Studio ou no editor de sua preferência.
2. Compile e execute o projeto.
3. Ao iniciar, o programa solicitará algumas entradas:
   - **Caminho do arquivo**: Informe o caminho completo do arquivo de entrada com os dados dos funcionários.
   - **Idade para busca**: Insira uma idade para filtrar funcionários mais jovens que este valor.
   - **Anos de serviço**: Defina um número para separar funcionários com mais tempo de empresa.
   - **Letra para busca**: Especifique uma letra para buscar funcionários cujos nomes começam com essa letra.
   - **Salário mínimo**: Insira um valor mínimo para listar os e-mails dos funcionários com salário acima deste valor.

### Exemplo de Execução

Para um arquivo com os dados acima e as seguintes entradas:

- Caminho do arquivo: `C:\dados\funcionarios.csv`
- Idade: `35`
- Anos de serviço: `5`
- Letra para busca: `A`
- Salário mínimo: `2500.00`

A saída será algo como:

-Sum of salaries for employees whose name starts with 'A': 2000.00

-Emails of employees with salary above 2500.00: bob@example.com

-Employees with more than 5 years of service: Alice Bob

-Employees younger than 35: Alice


