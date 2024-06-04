namespace GroupsApp.Payload.DTO
{
    public class TagDTO
    {
        private Guid tagId;
        private string tagName;

        public Guid TagId { get => tagId; set => tagId = value; }
        public string TagName { get => tagName; set => tagName = value; }
    }
}
