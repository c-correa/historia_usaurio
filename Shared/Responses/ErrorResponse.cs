using System;
using System.Text.Json.Serialization;

namespace SOneWeb.Shared.Responses
{
    public class ErrorResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }

        [JsonPropertyName("stack")]
        public string? Stack { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; } = 500;

        // 🔹 Constructor rápido para errores comunes
        public static ErrorResponse FromException(Exception ex, int status = 500)
        {
            return new ErrorResponse
            {
                Name = ex.GetType().Name,
                Message = ex.Message,
                Stack = ex.StackTrace,
                Status = status
            };
        }

        // 🔹 Constructor específico para PostgresException (si usas Npgsql)
        public static ErrorResponse FromPostgres(Npgsql.PostgresException ex)
        {
            return new ErrorResponse
            {
                Name = ex.GetType().Name,
                Message = ex.MessageText,
                Detail = ex.Detail,
                Status = 500
            };
        }
    }
}
