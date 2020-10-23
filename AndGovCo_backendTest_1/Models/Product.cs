using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndGovCo_backendTest_1.Models
{
    public class Product 
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo Nombre de estar entre 3 y 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo Descripción es requerido.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "El campo Descripción de estar entre 3 y 500 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo Serial es requerido.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo Serial de estar entre 3 y 20 caracteres.")]
        public string Serial { get; set; }

        [Required(ErrorMessage = "El campo Valor de compra es requerido.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal PurchaseValue { get; set; }
        
        [DataType(DataType.Date)]        
        [Required(ErrorMessage = "El campo Fecha de compra es requerido.")]
        public DateTime PurchaseDate { get; set; }
            
        [Required(ErrorMessage = "El campo Estado es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Estado es requerido.")]            
        public int ProductStateID { get; set; }

        [Required(ErrorMessage = "El campo Tipo es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Tipo es requerido.")]
        public int ProductTypeID { get; set; }

        [Required(ErrorMessage = "El campo Área es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Área es requerido.")] 
        public int AreaID { get; set; }

        public ProductState ProductState { get; set; }
        public ProductType ProductType { get; set; }
        public Area Area { get; set; }
        
    }
}