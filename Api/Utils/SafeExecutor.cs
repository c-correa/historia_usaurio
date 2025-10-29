using Npgsql;
using SOneWeb.Shared.Responses;

namespace SOneWeb.Api.Utils
{
    public static class SafeExecutor
    {
        public static object Execute(Func<object> func)
        {
            try
            {
                return func();
            }
            catch (PostgresException pgEx)
            {
                return ErrorResponse.FromPostgres(pgEx);
            }
            catch (Exception ex)
            {
                return ErrorResponse.FromException(ex);
            }
        }
    }
}
