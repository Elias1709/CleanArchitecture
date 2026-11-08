using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureUserApi.Domain.Common;

namespace CleanArchitectureUserApi.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nombres { get; private set; }

        public string Apellidos { get; private set; }

        public string Telefono { get; private set; }

        public string Email { get; private set; }

        public string Direccion { get; private set; }

        private User()
        {
        }

        public User(
            string nombres,
            string apellidos,
            string telefono,
            string email,
            string direccion)
        {
            Id = Guid.NewGuid();

            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;

            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateAddress(string direccion)
        {
            Direccion = direccion;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePhone(string telefono)
        {
            Telefono = telefono;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(
        string nombres,
        string apellidos,
        string telefono,
        string email,
        string direccion)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;

            UpdatedAt = DateTime.UtcNow;
        }

    }
}
