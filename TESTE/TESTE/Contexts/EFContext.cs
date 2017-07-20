
using TESTE.Models;
using System.Data.Entity;
namespace TESTE.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Tarefa> Tarefas { get; set; }       
    }
}