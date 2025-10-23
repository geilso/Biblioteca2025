namespace Core.Datatable
{
    public class DatatableRequest
    {
        // Propriedades mínimas para funcionar
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
