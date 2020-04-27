using System;
using System.ComponentModel.DataAnnotations;

namespace ContratosApi.Models {
    public class Installment {

        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int ContractId { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public int NumInstallment { get; set; }

        [Required (ErrorMessage = "Este campo é obrigatório")]
        public decimal Value { get; set; }

        [DataType (DataType.Date)]
        [DisplayFormat (ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PayDay { get; set; }

        public Contract Contract { get; set; }
    }
}