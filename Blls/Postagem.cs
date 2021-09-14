using System;
using System.Collections.Generic;

namespace Blls
{
    public class Postagem
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime Data { get; set; }
        public Perfil Perfil { get; set; }
    }
}