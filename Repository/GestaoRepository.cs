using MySqlConnector;
using Domain;
using Dapper;

namespace Repository
{
    public class GestaoRepository : IGestaoRepository
    {
        private readonly MySqlConnection _connection;
        public GestaoRepository(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public async Task<IEnumerable<Produto>> GetAllProdutosAsync()
        {
            await _connection.OpenAsync();
            string sql = "";
            var produto = await _connection.QueryAsync<Produto>(sql);
            await _connection.CloseAsync();
            return produto;
        }
    }
}
