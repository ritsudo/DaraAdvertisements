namespace DaraAds.API.Dto.Advertisement
{
    public sealed class GetByCategoryRequest{
        
        public int CategoryId { get; set;}
        
        public int Limit { get; set; } = 10;
        
        public int Offset { get; set; } = 0;
    }
}