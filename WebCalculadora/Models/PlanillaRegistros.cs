﻿namespace WebCalculadora.Models
{
    public class PlanillaRegistros 
    {
        public int Id { get; set; }
        public List<string>? Registros_Json { get; set; }
        public int cabecera_id { get; set; }
    }
}
