namespace CarsApi.Application
{
    public class AppExceptions
    {
         public static Exception InvalidId(string entityName = "Entidade") =>
            new ArgumentException($"{entityName}: ID inválido ou menor que zero.");

        public static Exception NotFound(string entityName = "Entidade") =>
            new KeyNotFoundException($"{entityName} não encontrada.");

        public static Exception InvalidField(string fieldName = "Campo") =>
            new ArgumentNullException(fieldName, $"{fieldName} está vazio ou inválido.");

        public static Exception BusinessRule(string message = "Regra de negócio violada.") =>
            new InvalidOperationException(message);

        public static Exception Conflict(string entityName = "Entidade") =>
            new InvalidOperationException($"{entityName} já existe ou está em conflito.");

        public static Exception Unauthorized(string action = "ação") =>
            new UnauthorizedAccessException($"Usuário não autorizado para {action}.");
    }
}