//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShowWaterCup.Services.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Action
    {
        public int ActionId { get; set; }
        public int PlayerId { get; set; }
        public int ActionTypeId { get; set; }
        public string Target { get; set; }
        public int RoundId { get; set; }
    
        public virtual ActionType ActionType { get; set; }
        public virtual Player Player { get; set; }
        public virtual Round Round { get; set; }
    }
}
