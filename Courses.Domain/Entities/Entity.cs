namespace Courses.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { set; get; }

        public string CreatedBy { set; get; } = string.Empty;

        public DateTime DateCreated { set; get; }

        public string ModifiedBy { set; get; } = string.Empty;

        public DateTime DateModified { set; get; }

    }
}