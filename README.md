# MongoDB Example

Este projeto utiliza Docker Compose para subir uma instância do MongoDB e importar uma coleção de filmes.

## Subindo o MongoDB com Docker Compose

Execute o comando abaixo na raiz do projeto:

```powershell
docker compose up -d
```

## Acessando o MongoDB

Você pode acessar o MongoDB via Compass com a seguinte URI:

```powershell
mongodb://localhost:27017/
```

E nomear como MongoExample.

## Selecionando o banco de dados

No shell do MongoDB, execute:

```js
use MongoReview
```

## Criando a coleção e inserindo os dados

Crie a coleção `movies`:

```js
db.createCollection("movies")
```

e insira os dados abaixo:

```js
db.movies.insertMany([
  {
    "title": "Inception",
    "director": "Christopher Nolan",
    "year": 2010,
    "genres": ["Action", "Sci-Fi", "Thriller"],
    "rating": 8.8
  },
  {
    "title": "The Matrix",
    "director": "Lana Wachowski, Lilly Wachowski",
    "year": 1999,
    "genres": ["Action", "Sci-Fi"],
    "rating": 8.7
  },
  {
    "title": "Interstellar",
    "director": "Christopher Nolan",
    "year": 2014,
    "genres": ["Adventure", "Drama", "Sci-Fi"],
    "rating": 8.6
  }
])
```

## Observações

```powershell
docker compose down
Esta aplicação tem finalidade exclusivamente didática e não segue as melhores práticas recomendadas para ambientes produtivos.

- Esta aplicação tem finalidade exclusivamente didática e não segue as melhores práticas recomendadas para ambientes produtivos.