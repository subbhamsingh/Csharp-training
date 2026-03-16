namespace AssetMangementWebApi.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; } 
        public decimal Value {  get; set; }
        
        // added assigned to property 
        public string? AssignedTo {  get; set; }
    }
}
