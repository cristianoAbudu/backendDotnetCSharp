using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backendCSharp.Entity
{
	public class Colaborador
	{
        public int Id { get; set; }

        public String? Nome { get; set; }

        public String? Senha { get; set; }

        [Column("id_chefe")]
        public int? chefe { get; set; }

    }
}

