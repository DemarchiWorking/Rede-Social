using Blls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.Api.Data
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Comentario> Comentarios { get;set; }
        public DbSet<Postagem> Postagens { get;set; }
        public DbSet<Perfil> Perfis { get;set; }
    }
}
