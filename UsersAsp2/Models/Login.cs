//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UsersAsp2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Login
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public bool LoginSuccessful { get; set; }
        public string Note { get; set; }
    
        public virtual User User { get; set; }
    }
}
