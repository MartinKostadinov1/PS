using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model;

public class DatabaseLog
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }
    
    public string Message { get; set; }
    
    public string AdditionalInformation { get; set; }
    
    public DatabaseLog()
    {
    }
    
    
    public DatabaseLog(string message, string additionalInformation)
    {
        Message = message;
        AdditionalInformation = additionalInformation;
    }
    
    
    
}