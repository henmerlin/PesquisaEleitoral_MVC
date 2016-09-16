using Microsoft.AspNet.Identity.EntityFramework;
using PesquisaEleitoral.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PesquisaEleitoral_MVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required, Column(TypeName = "Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [ForeignKey("Bairro"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? BairroId { get; set; }
        public Bairro Bairro { get; set; }

        [ForeignKey("Voto"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? VotoId { get; set; }
        public Candidato Voto { get; set; }

        [DefaultValue(false)]
        public bool Admin { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}