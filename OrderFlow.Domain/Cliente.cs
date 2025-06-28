
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderFlow.Domain
{
    public class Cliente
    {
        private int clienteId;
        private string nombreCompania;
        private string nombreContacto;
        private string apellidoContacto;
        private string puestoContacto;
        private string direccion;
        private string ciudad;
        private string provincia;
        private string codigoPostal;
        private string pais;
        private string telefono;
        private string numFax;

        public Cliente()
        {
            // Constructor vacío
        }

        public Cliente(int clienteId, string nombreCompania, string nombreContacto, string apellidoContacto, string puestoContacto, string direccion, string ciudad, string provincia, string codigoPostal, string pais, string telefono, string numFax)
        {
            this.clienteId = clienteId;
            this.nombreCompania = nombreCompania;
            this.nombreContacto = nombreContacto;
            this.apellidoContacto = apellidoContacto;
            this.puestoContacto = puestoContacto;
            this.direccion = direccion;
            this.ciudad = ciudad;
            this.provincia = provincia;
            this.codigoPostal = codigoPostal;
            this.pais = pais;
            this.telefono = telefono;
            this.numFax = numFax;
        }

        public int ClienteId { get => clienteId; set => clienteId = value; }
        public string NombreCompania { get => nombreCompania; set => nombreCompania = value; }
        public string NombreContacto { get => nombreContacto; set => nombreContacto = value; }
        public string ApellidoContacto { get => apellidoContacto; set => apellidoContacto = value; }
        public string PuestoContacto { get => puestoContacto; set => puestoContacto = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        public string CodigoPostal { get => codigoPostal; set => codigoPostal = value; }
        public string Pais { get => pais; set => pais = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string NumFax { get => numFax; set => numFax = value; }
    }
}
