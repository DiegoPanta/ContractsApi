using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContratosApi.Models {
    public class Contract {
        
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Code { get; set; }
        
        [MaxLength(ErrorMessage = "Este campo deve conter ate 100 caracteres")]
        public string Bank { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int NumInstallments { get; set; }
        
        public ICollection<Installment> Installments { get; set; }
    }
}