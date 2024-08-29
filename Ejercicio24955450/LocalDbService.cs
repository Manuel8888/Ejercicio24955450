using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio24955450
{
    public class LocalDbService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Numero>().Wait();
        }

        public async Task<List<Numero>> GetNumeros()
        {
            return await _connection.Table<Numero>().ToListAsync();
        }

        public async Task<Numero> GetById(int id)
        {
            return await _connection.Table<Numero>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Numero numero)
        {
            numero.Signo = DeterminarSigno(numero.Valor);
            await _connection.InsertAsync(numero);
        }

        public async Task Update(Numero numero)
        {
            numero.Signo = DeterminarSigno(numero.Valor);
            await _connection.UpdateAsync(numero);
        }

        public async Task Delete(Numero numero)
        {
            await _connection.DeleteAsync(numero);
        }

        private string DeterminarSigno(int valor)
        {
            if (valor > 0)
            {
                return "Positivo";
            }
            else if (valor < 0)
            {
                return "Negativo";
            }
            else
            {
                return "Nulo";
            }
        }
    }
}

