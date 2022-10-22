﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CarroDTO
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "ID inválido.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode estar vazio.")]
        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "Digite um nome válido.", MinimumLength = 2)]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo 'Modelo' não pode estar vazio.")]
        [Display(Name = "Modelo")]
        [StringLength(50, ErrorMessage = "Digite um modelo válido.", MinimumLength = 2)]
        public string Modelo { get; set; }
    }
}
