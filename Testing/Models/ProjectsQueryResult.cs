using System;

namespace Testing.Models
{
    public class ProjectsQueryResult
    {
        public string Number { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        public string QuickBooksID { get; set; }
        public bool ExportToQuickbooks { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
        public int Id { get; set; }
        public int? LibraryId { get; set; }
        public string QBClass { get; set; }
        public int? ManagerId { get; set; }
        public string ClientName { get; set; }
        public string ManagerName { get; set; }
        public string ClientAndNumber { get; set; }
    }
}
