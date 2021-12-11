namespace TaskTracker.Models;

public interface IBaseEntity
{
	DateTime CreatedAt { get; set; }
	string   IdCreatedBy { get; set; }
	DateTime UpdatedAt { get; set; }
	string   IdUpdatedBy { get; set; }
}

public class BaseEntity : IIdentify, IBaseEntity, IDescribe
{
	[System.Text.Json.Serialization.JsonPropertyName("id")]
	public Guid Id { get; set; }
	[System.Text.Json.Serialization.JsonPropertyName("title")]
	public string Title       { get; set; }
	[System.Text.Json.Serialization.JsonPropertyName("description")]
	public string? Description { get; set; }
	#region IBaseEntity Members

	public string   IdCreatedBy { get; set; }
	public DateTime CreatedAt { get; set; }
    public ApplicationUser CreatedBy { get; set; }
	public string   IdUpdatedBy { get; set; }
	public DateTime UpdatedAt { get; set; }
    public ApplicationUser UpdatedBy { get; set; }

    #endregion
}