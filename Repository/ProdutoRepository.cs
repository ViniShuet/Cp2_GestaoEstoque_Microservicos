using Dapper;
using Domain;
using MySqlConnector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddAsync(Produto produto)
        {
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            string sql = @"
                INSERT INTO produtos (nome, perecivel, precoUnitario, estoqueAtual, qtdMin, dataValidade, dataCriacao)
                VALUES (@Nome, @Perecivel, @PrecoUnitario, @EstoqueAtual, @QtdMin, @DataValidade, @DataCriacao);
                SELECT LAST_INSERT_ID();
            ";

            return await conn.ExecuteScalarAsync<int>(sql, produto);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            await using var conn = new MySqlConnection(_connectionString);
            string sql = @"UPDATE produtos SET 
                            estoqueAtual = @EstoqueAtual, 
                            qtdMin = @QtdMin 
                          WHERE codigoSKU = @CodigoSKU;";
            await conn.ExecuteAsync(sql, produto);
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            await using var conn = new MySqlConnection(_connectionString);
            string sql = "SELECT * FROM produtos WHERE codigoSKU = @id;";
            return await conn.QueryFirstOrDefaultAsync<Produto>(sql, new { id });
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            await using var conn = new MySqlConnection(_connectionString);
            string sql = "SELECT * FROM produtos;";
            return await conn.QueryAsync<Produto>(sql);
        }
    }
}
