
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Domain
{
    public class Categoria
    {
        private int codCategoria;
        private string descripcion;

        public Categoria()
        {
            // Constructor vacío
        }

        public Categoria(int codCategoria, string descripcion)
        {
            this.codCategoria = codCategoria;
            this.descripcion = descripcion;
        }

        public int CodCategoria { get => codCategoria; set => codCategoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}


