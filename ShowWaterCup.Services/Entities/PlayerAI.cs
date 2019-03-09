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
    
    public partial class PlayerAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerAI()
        {
            this.PlayerAISteps = new HashSet<PlayerAIStep>();
            this.Players = new HashSet<Player>();
        }
    
        public int AiId { get; set; }
        public int PlayerId { get; set; }
    
        public virtual Player Player { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerAIStep> PlayerAISteps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
