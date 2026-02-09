using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using AnimalShelter.Api.Models.Enums;

namespace AnimalShelter.Api.Extensions
{
    internal static class NpgsqlEnumMappingExtensions
    {
        public static NpgsqlDbContextOptionsBuilder MapPostgresEnums(this NpgsqlDbContextOptionsBuilder builder)
        {
            // Register all Postgres enums used by the application in one place.
            builder.MapEnum<AdoptionState>("adoption_state");
            builder.MapEnum<AnimalState>("animal_state");
            builder.MapEnum<AnimalType>("animal_type");
            builder.MapEnum<UserRol>("user_rol");
            builder.MapEnum<UserState>("user_state");

            return builder;
        }
    }
}
