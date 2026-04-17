using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace app.ActVJorge.common.DTOs
{
    public class DireccionClienteDTO
    {
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public string? Provincia { get; set; }

        [Required]
        public string? Ciudad { get; set; }

        [Required]
        public string? Direccion { get; set; }

        public string? CodigoPostal { get; set; }

        public bool Estado { get; set; }
    }
}
