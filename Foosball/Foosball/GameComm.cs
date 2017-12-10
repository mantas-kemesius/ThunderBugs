namespace Foosball
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GameComm")]
    public partial class GameComm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Time { get; set; }
    }
}
