using ContratosApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContractsApi.Models
{
    public static class InstallmentMap
    {
        public static void Map(this EntityTypeBuilder<Installment> entity)
        {
            entity.ToTable("Parcela", "pagamento");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            entity.Property(p => p.ContractId).HasColumnName("IdContrato").IsRequired();
            entity.Property(p => p.NumInstallment).HasColumnName("NumParcela").IsRequired();
            entity.Property(p => p.Value).HasColumnName("Valor").HasColumnType("decimal(10,2)").IsRequired();
            entity.Property(p => p.PayDay).HasColumnName("DataPagamento");

            entity.HasOne(p => p.Contract).WithMany(p => p.Installments).HasForeignKey(p => p.ContractId).OnDelete(DeleteBehavior.Restrict).IsRequired();
        }
        
    }
}