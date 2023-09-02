using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backendCSharp.Entity
{

    public class Colaborador
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Identity indicates auto-increment
        public int Id { get; set; }

        public String? Nome { get; set; }

        public String? Senha { get; set; }

        [Column("id_chefe")]
        public int? IdChefe { get; set; }

        [NotMapped]
        public Colaborador chefe { get; set; }

    }
}

