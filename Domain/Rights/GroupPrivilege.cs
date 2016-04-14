namespace Domain.Rights
{
    public class GroupPrivilege
    {
        public int GroupPrivilegeId { get; set; }
  
        public int PrivilegeId { get; set; }
        public virtual Privilege Privilege { get; set; }
    }
}
