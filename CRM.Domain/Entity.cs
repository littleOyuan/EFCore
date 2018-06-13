namespace CRM.Domain
{
    /// <summary>
    /// 泛型实体
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class Entity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }

    public abstract class Entity : Entity<int>
    {

    }
}
