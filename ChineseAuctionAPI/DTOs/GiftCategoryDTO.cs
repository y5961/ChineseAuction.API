namespace ChineseAuctionAPI.DTOs
{
    public class GiftCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CreateGiftCategoryDTO
    {
        public string Name { get; set; }
    }

    public class UpdateGiftCategoryDTO
    {
        public string Name { get; set; }
    }
}

