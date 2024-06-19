
using MongoDB.Bson;
namespace MongoApp.Models;
public class Movie
{
    public ObjectId _id { get; set; }
    public string? title { get; set; }
    public string? rated { get; set; }
    public string? plot { get; set; }
}