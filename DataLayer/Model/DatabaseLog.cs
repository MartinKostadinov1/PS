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

    public DateTime DateTime { get; set; }

    public DatabaseLog()
    {
        DateTime = DateTime.Now;
    }
    
    
    public DatabaseLog(string message, string additionalInformation)
    {
        Message = message;
        AdditionalInformation = additionalInformation;
        DateTime = DateTime.Now;
    }
    
    
    
}