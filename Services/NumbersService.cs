using Dapper;
using Microsoft.Data.Sqlite;
using Parcial1_P4_Stiven.Models;

namespace Parcial1_P4_Stiven.Services;

public class NumbersService
{
    private readonly string _connectionString;

    public NumbersService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task InitializeAsync()
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = @"
            CREATE TABLE IF NOT EXISTS NumberRecords (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Fecha TEXT NOT NULL,
                Numero REAL NOT NULL,
                Resultado REAL NOT NULL
            );";
        await connection.ExecuteAsync(sql);
    }

    public async Task<int> SaveAsync(NumberRecord record)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = @"
            INSERT INTO NumberRecords (Fecha, Numero, Resultado) 
            VALUES (@Fecha, @Numero, @Resultado); 
            SELECT last_insert_rowid();";
        return await connection.ExecuteScalarAsync<int>(sql, record);
    }

    public async Task<int> UpdateAsync(NumberRecord record)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = @"
            UPDATE NumberRecords 
            SET Fecha = @Fecha, Numero = @Numero, Resultado = @Resultado 
            WHERE Id = @Id;";
        return await connection.ExecuteAsync(sql, record);
    }

    public async Task<NumberRecord?> GetByIdAsync(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = "SELECT * FROM NumberRecords WHERE Id = @Id;";
        return await connection.QuerySingleOrDefaultAsync<NumberRecord>(sql, new { Id = id });
    }

    public async Task<IEnumerable<NumberRecord>> GetListAsync()
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = "SELECT * FROM NumberRecords ORDER BY Fecha DESC;";
        return await connection.QueryAsync<NumberRecord>(sql);
    }
}