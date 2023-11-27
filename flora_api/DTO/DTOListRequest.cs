namespace api_flora.DTO
{
    public class DTOListRequest
    {
        public int? Page {  get; set; }

        public int? PageSize { get; set; }

        public string? Query { get; set; }

        public string? OrderBy { get; set; }
    }
}
