using System;
using System.ComponentModel.DataAnnotations;

namespace BlogWebApp.DAL.DbEntities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}