namespace SectorSelection.Dtos
{
    public class SectorDto
    {
        public int SectorId { get; set; }

        public int Value { get; set; }

        public int? ParentId { get; set; }

        public string SectorName { get; set; }

        public bool IsActive { get; set; }
    }
}