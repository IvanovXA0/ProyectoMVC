//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Juegos
    {
        public int JuegoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> GeneroID { get; set; }
        public Nullable<int> PlataformaID { get; set; }
        public Nullable<int> EstudioID { get; set; }
        public Nullable<int> DistribuidorID { get; set; }
        public Nullable<int> AnioPublicacion { get; set; }
        public Nullable<int> MotorID { get; set; }
        public string UrlPortada { get; set; }
    
        public virtual Distribuidores Distribuidores { get; set; }
        public virtual Estudios Estudios { get; set; }
        public virtual Generos Generos { get; set; }
        public virtual Motores Motores { get; set; }
        public virtual Plataformas Plataformas { get; set; }
    }
}
