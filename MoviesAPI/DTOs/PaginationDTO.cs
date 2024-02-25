namespace MoviesAPI.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; }

        private int recordsPerPage = 10;
        private readonly int maxRecordsPerPage = 50;

        public int RecordsPerPage
        {
            get
            { 
                return recordsPerPage;
            }
            set
            { 
                recordsPerPage = (value> maxRecordsPerPage)?maxRecordsPerPage:value;
            }
            
        }
    }
}
