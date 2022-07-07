# Sobre

Esta api é utilizada para a prova de front-end. Ela retorna as oportunidades e os itens necessários para criar a aplicação web.

# Requisitos

* [Docker](https://www.docker.com/get-started/)

# Como rodar o projeto

* Acesse a pasta raiz do projeto
* Execute o comando abaixo no terminal para subir a api e o banco de dados. Certifique-se que o docker esteja instalado.

    ```sh
    docker-compose up --build
    ```

* Se tudo ocorrer certo deverá está rodando dois containers. São eles: api-teste_api-auction e api-teste_api-auction.
  Para visualizar os containers execute o comando abaixo no terminal.

    ```sh
    docker ps
    ```

* A API estará disponível em http://localhost:8099

* Você conseguirá acessar a documentação [aqui](http://localhost:8099/swagger/index.html)

