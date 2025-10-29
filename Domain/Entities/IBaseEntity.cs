using System;

namespace SOneWeb.Domain.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        DateTime? DeletedAt { get; set; }
    }
}
