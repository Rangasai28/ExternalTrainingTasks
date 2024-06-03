namespace WebApiFiltersTask.Models;

public class RoleBasedAction
{
    public int Id { get; set; }
    public int RoleId { get; set; }

    public string ActionName { get; set; }
}
