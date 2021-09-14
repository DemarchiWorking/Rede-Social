using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    public class Comentario
    {
        public Guid Id { get; set; }
        public string TextoComentario { get; set; }
        public Postagem Postagem { get; set; }
        public DateTime Data { get; set; }
        public Perfil PerfilComentario { get; set; }
    }
}

