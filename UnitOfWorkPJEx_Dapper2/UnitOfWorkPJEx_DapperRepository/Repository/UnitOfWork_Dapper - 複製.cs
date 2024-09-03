using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using UnitOfWorkPJEx_DapperRepository.Interface;

namespace UnitOfWorkPJEx_DapperRepository.Repository
{
    public class UnitOfWork_Dapper : IUnitOfWork_Dapper, IDisposable
    {
        private IConfiguration _config ;
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public IUserUnitRepository Users
        { get; }

        public IDbConnection Connection => _connection;
        public IDbTransaction Transaction => _transaction;

        public UnitOfWork_Dapper (IConfiguration config, IDbConnection connection, IUserUnitRepository userunitRepository)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Users = userunitRepository ?? throw new ArgumentNullException(nameof(userunitRepository));

            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }


        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        //~UnitOfWork_Dapper()
        //{
        //    Dispose(false);
        //}

    }
}
