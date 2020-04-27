using ContratosApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContractsApi.Models
{
    public static class ContractMap
    {
        public static void Map(this EntityTypeBuilder<Contract> entity)
        {
            entity.ToTable("Contrato", "pagamento");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.Code).HasColumnName("Codigo").IsRequired();
            entity.Property(p => p.Bank).HasColumnName("Banco").HasMaxLength(100).IsRequired();
            entity.Property(p => p.Value).HasColumnName("Valor").HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(p => p.NumInstallments).HasColumnName("NumParcelas").IsRequired();

            entity.HasMany(p => p.Installments).WithOne(p => p.Contract).HasForeignKey(p => p.ContractId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}