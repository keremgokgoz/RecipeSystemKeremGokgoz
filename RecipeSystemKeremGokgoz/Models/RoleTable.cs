//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeSystemKeremGokgoz.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleTable
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual UsersTable UsersTable { get; set; }
    }
}
