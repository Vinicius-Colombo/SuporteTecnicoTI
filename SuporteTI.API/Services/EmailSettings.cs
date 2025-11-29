namespace SuporteTI.API.Services
{
    public class EmailSettings
    {
        public string? ConnectionString { get; set; }     
        public string? FromEmail { get; set; }            
        public string? FromName { get; set; } = "SuporteTI"; 
    }
}
