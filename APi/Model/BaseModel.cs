using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APi.Model;

public abstract class BaseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;


    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdatedOn { get; set; }

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    //public DateTime LastAccessed { get; set; }

    public bool IsDeleted { get; set; }

    public string Naciolanidad { get; set; } = "n/d";
}

