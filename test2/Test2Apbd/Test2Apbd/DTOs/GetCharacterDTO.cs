namespace Test2Apbd.DTOs
{
    public class GetCharacterDTO
    {
        public string FirstName = string.Empty;
        public string LastName = string.Empty;
        public int CurrentWeight { get; set; }
        public int MaxWeight { get; set; }

        public ICollection<GetItemsDto> backpackItems { get; set; } = null!;
        public ICollection<GetTitleDto> Titles { get; set; } = null!;
    }

    public class GetItemsDto
    {
        public string ItemName { get; set; } = string.Empty;
        public int ItemWeight { get; set; } 
        public int Amount { get; set; }
    }

    public class GetTitleDto
    {
        public string Title { get; set; } = string.Empty;
        public DateTime AcquiredAt { get; set; }
    }
}

